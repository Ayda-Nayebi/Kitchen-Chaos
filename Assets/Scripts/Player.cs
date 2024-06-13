using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    public event EventHandler <OnSelectedChangedEventArgs> OnSelectedChanged;
    public class OnSelectedChangedEventArgs: EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking;
    private Vector3 lastInteractDirection;
    private ClearCounter selectedCounter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inputManager.OnInteractAction += InputManager_OnInteractAction;
    }

    private void InputManager_OnInteractAction(object sender, System.EventArgs e)
    {
       if(selectedCounter != null)
        {
            selectedCounter.Interact();
        }
    }

    private void Update()
    {
        HandleMovment();
        HandleIntraction();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleIntraction()
    {
        Vector2 vectorInput = inputManager.GetMovmentVectorNormalized();

        Vector3 moveDirection = new Vector3(vectorInput.x, 0f, vectorInput.y);

        if(moveDirection != Vector3.zero )
        {
            lastInteractDirection = moveDirection;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, moveDirection, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // has clear counter
               if(clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
                 
                }

            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }

    }
    private void HandleMovment()
    {

        Vector2 vectorInput = inputManager.GetMovmentVectorNormalized();

        Vector3 moveDirection = new Vector3(vectorInput.x, 0f, vectorInput.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRaduce = 0.7f;
        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduce, moveDirection, moveDistance);

        if (!canMove)
        {
            // cannot move towards move direction
            // attempt only x movment

            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduce, moveDirectionX, moveDistance);

            if (canMove)
            {
                // can move only on the x

                moveDirection = moveDirectionX;
            }
            else
            {
                // cannot move only on the x
                // attempt only z movement

                Vector3 moveDrectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduce, moveDrectionZ, moveDistance);

                if (canMove)
                {
                    // can move only on the z

                    moveDirection = moveDrectionZ;
                }

                else
                {
                    // cannot move any directon
                }
            }
        }

        if (canMove)
        {

            transform.position += moveDirection * moveDistance;

        }

        isWalking = moveDirection != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedChanged?.Invoke(this, new OnSelectedChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }


}

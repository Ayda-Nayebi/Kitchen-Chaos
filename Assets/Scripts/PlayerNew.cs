using System;
using UnityEngine;
using static Player;

public class PlayerNew : MonoBehaviour , IKitchenObjectParent
{
    [SerializeField] private float speed = 7;
    [SerializeField] float rotationSpeed = 720f;

    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    [SerializeField] private InputManager inputManager;

    private Rigidbody rb;
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;


    public bool IsWalking => rb.velocity != Vector3.zero;

    public event Action<BaseCounter> OnSelectedChanged;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager.OnInteractAction += InputManager_OnInteractAction;
    }

    private void InputManager_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    void FixedUpdate()
    {
        HandleMovment();
        HandleIntraction();
    }

    private void HandleMovment() 
    {
        // Get input from WASD keys
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleIntraction()
    {
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                // has clear counter
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);

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

    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedChanged?.Invoke(selectedCounter);
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void CLearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}

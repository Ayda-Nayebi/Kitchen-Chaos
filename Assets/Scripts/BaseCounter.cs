using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
 
    [SerializeField] private Transform counterTopPoint;


    private KitchenObject kitchenObject;

    public virtual void Interact(Player player)
    {
        Debug.LogError("Base Counter Interact");
    }

    public virtual void Interact(PlayerNew player)
    {
        Debug.LogError("Base Counter Interact");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
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

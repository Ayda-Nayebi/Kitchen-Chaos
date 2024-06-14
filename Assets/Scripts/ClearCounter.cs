using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour , IKitchenObjectParent
{

    [SerializeField] private KitechenObjectSo kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
  

    private KitchenObject kitchenObject;

   
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
        else
        {
            // Give the object to player
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject=kitchenObject;
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

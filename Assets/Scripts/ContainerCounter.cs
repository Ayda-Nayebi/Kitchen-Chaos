using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter 
{
    public event EventHandler onPlayerGrabbedObject;

    [SerializeField] private KitechenObjectSo kitchenObjectSo;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSo.prefab);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            onPlayerGrabbedObject?.Invoke(this , EventArgs.Empty);
        }
        
    }

    public override void Interact(PlayerNew player)
    {
        if (!HasKitchenObject())
        {
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSo.prefab);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            onPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }

    }
}


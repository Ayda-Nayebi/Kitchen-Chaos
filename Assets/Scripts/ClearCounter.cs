using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitechenObjectSo kitchenObjectSo;
   

   
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object here

            if (player.HasKitchenObject())
            {
                // player is carrying somthing
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // player is carrying nothing
            }
        }
        else
        {
            // there is a kitchen object
            if (player.HasKitchenObject())
            {
                // player is carrying somthing
            }

            else
            {
                // palyer is carrying nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        }
    }


  //  public override void Interact(PlayerNew player)
   // {
 //   }



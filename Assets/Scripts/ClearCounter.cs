using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitechenObjectSo kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
    public void Interact()
    {
        Transform KitchenObjectTransform =   Instantiate (kitchenObjectSo.prefab, counterTopPoint);
        KitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(KitchenObjectTransform.GetComponent<KitchenObject>().GetKitechenObjectSo().objectName);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitechenObjectSo KitechenObjectSo;

    public KitechenObjectSo GetKitechenObjectSo()
    {
        return KitechenObjectSo;
    }
}

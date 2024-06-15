using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
   
    private void Start()
    {
        // Player.Instance.OnSelectedChanged += Player_OnSelectedChanged;

        FindAnyObjectByType<PlayerNew>().OnSelectedChanged += Player_OnSelectedChanged;
    }

    private void Player_OnSelectedChanged(BaseCounter selectedCounter)
    {
        if (selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    //private void Player_OnSelectedChanged(object sender, Player.OnSelectedChangedEventArgs e)
    //{
    //    if (e.selectedCounter == baseCounter )
    //    {
    //        Show();
    //    }
    //    else
    //    {
    //        Hide();
    //    }
    //}

    private void Show()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray) { 
        visualGameObject.SetActive(false);
    }
    }
}

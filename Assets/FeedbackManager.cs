using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class FeedbackManager : MonoBehaviour
{
    private void OnEnable()
    {
        Observer.OnPieceDrop.AddListener(SpawnTextForMoney);
    }
    private void OnDisable()
    {
        Observer.OnPieceDrop.RemoveListener(SpawnTextForMoney);
    }
    private void SpawnTextForMoney(Vector3 position)
    {
        GameObject item = ObjectPool.instance.GetObject("moneyText", position);
        item.SetActive(true);
    }


}

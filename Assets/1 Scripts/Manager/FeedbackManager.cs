using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using SaveSystem;
namespace FeedbackSystem
{
    public class FeedbackManager : MonoBehaviour
    {
        public GameObject[] confetties;
        public GameObject moneyBlast;
        private void OnEnable()
        {
            Observer.OnPieceDrop.AddListener(SpawnTextForMoney);
            Observer.OnShapeOver.AddListener(OpenConfettiesAsync);
            Observer.OnShapeOver.AddListener(BlastMoney);
            Observer.OnCarSold.AddListener(GiveMoney);
        }

        private void GiveMoney(int price)
        {
            int totalPrice = price * SavedData.Instance.playerData.currentSellLevel;
        }

        private void OnDisable()
        {
            Observer.OnPieceDrop.RemoveListener(SpawnTextForMoney);
            Observer.OnShapeOver.RemoveListener(OpenConfettiesAsync);
            Observer.OnShapeOver.RemoveListener(BlastMoney);
        }
        private void SpawnTextForMoney(Vector3 position)
        {
            GameObject item = ObjectPool.instance.GetObject("moneyText", position);
            item.SetActive(true);
        }
        private void BlastMoney(bool sold)
        {
            if (sold)
            {
                moneyBlast.SetActive(false);
                moneyBlast.SetActive(true);
            }
        }

        private void OpenConfettiesAsync(bool sold)
        {
            if (!sold) StartCoroutine(OpenAsync());
        }
        IEnumerator OpenAsync()
        {
            foreach (var item in confetties)
            {
                item.SetActive(true);
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(1.7f);
            foreach (var item in confetties)
            {
                item.SetActive(false);
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

namespace FeedbackSystem
{
    public class FeedbackManager : MonoBehaviour
    {
        public GameObject[] confetties;
        public GameObject moneyBlast;
        private void OnEnable()
        {
            Observer.OnShapeOver.AddListener(OpenConfettiesAsync);
            Observer.OnShapeOver.AddListener(BlastMoney);
            Observer.OnCarSold.AddListener(GiveMoney);
        }
        private void OnDisable()
        {
            Observer.OnShapeOver.RemoveListener(OpenConfettiesAsync);
            Observer.OnShapeOver.RemoveListener(BlastMoney);
            Observer.OnCarSold.RemoveListener(GiveMoney);
        }
        private void GiveMoney(int price)
        {
            int totalPrice = Mathf.RoundToInt(price * UpgradeManager.Instance.currentSellBonus);
            Economy.Instance.Add(totalPrice);

            GameObject item = ObjectPool.instance.GetObject("moneyText");
            TextMeshProUGUI itemTMP = item.GetComponent<TextMeshProUGUI>();
            item.SetActive(true);
            itemTMP.text = "+" + totalPrice + "$";
            itemTMP.DOFade(0, 0.2f).SetDelay(0.3f);
            item.transform.DOMoveY(100, 0.5f).SetRelative().OnComplete(() =>
            {
                item.SetActive(false);
                item.transform.position -= Vector3.up * 100;
                itemTMP.DOFade(1, 0);
            });
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
            foreach (var item in confetties) item.SetActive(false);
        }
    }
}

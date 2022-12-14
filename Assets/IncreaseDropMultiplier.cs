using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class IncreaseDropMultiplier : MonoBehaviour
{
    public static int dropMultiplier = 1;
    public Image buttonBackground;
    public TextMeshProUGUI feedbackMSG;
    public bool isActive;
    public void IncreaseDrop()
    {
        if (isActive) return;
        isActive = true;

        dropMultiplier = 2;
        DOVirtual.Float(1f, 0f, 10.0f, (x) =>
        {
            buttonBackground.fillAmount = x;
        }).OnComplete(() =>
        {
            dropMultiplier = 1;
            isActive = false;
        });

        feedbackMSG.gameObject.SetActive(true);
        feedbackMSG.transform.DOScale(Vector3.one * 1.2f, 0.2f).OnComplete(() =>
        {
            feedbackMSG.transform.DOScale(Vector3.one, 0.1f);
        });
        feedbackMSG.DOFade(0, 0.2f).SetDelay(0.6f);
        feedbackMSG.transform.DOMoveY(80, 0.5f).SetRelative().SetDelay(0.3f).OnComplete(() =>
        {
            feedbackMSG.gameObject.SetActive(false);
            feedbackMSG.transform.position -= Vector3.up * 80;
            feedbackMSG.DOFade(1, 0f);
        });


    }
}

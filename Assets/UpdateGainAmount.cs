using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UpdateGainAmount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gainTMP;
    Tween animTween, fadeTween, animTween2;
    public void OnEnable()
    {
        gainTMP.DOFade(1, 0);
        int amount = (SaveSystem.SavedData.Instance.playerData.currentEarningLevel * 2) + SaveSystem.SavedData.Instance.playerData.currentEarningLevel % 2;
        gainTMP.text = "+" + amount.ToString() + "$";
        Economy.Instance.Add(amount);
        animTween = transform.parent.DOMoveY(0.6f, 0.8f).SetRelative();
        animTween2 = transform.parent.DOMoveY(0.3f, 0.2f).SetRelative().SetDelay(0.8f);
        fadeTween = gainTMP.DOFade(0, 0.2f).SetDelay(0.8f).OnComplete(() =>
        {
            transform.parent.gameObject.SetActive(false);
        });
    }
    private void OnDisable()
    {
        animTween.Kill();
        animTween2.Kill();
        fadeTween.Kill();
    }
}

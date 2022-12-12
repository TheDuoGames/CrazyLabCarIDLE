using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MoneyUpdater : MonoBehaviour
{
    TextMeshProUGUI _moneyTextMesh;
    TextMeshProUGUI MoneyTextMesh => (_moneyTextMesh == null) ? _moneyTextMesh = GetComponent<TextMeshProUGUI>() : _moneyTextMesh;
    [SerializeField] private int valueHolder;
    Tween bounceTween;
    Tween tween;
    private void Start()
    {
        MoneyTextMesh.text = valueHolder.ToString();
        UpdateCurrentValue();
    }
    private void OnEnable()
    {
        Economy.OnMoneyChange.AddListener(UpdateCurrentValue);
    }
    private void OnDisable()
    {
        Economy.OnMoneyChange.RemoveListener(UpdateCurrentValue);
    }
    private void UpdateCurrentValue()
    {
        tween.Kill();
        bounceTween.Kill();
        int startValue = valueHolder;
        int desiredValue = Economy.Instance.CurrentCount();
        if (desiredValue > startValue)
        {
            bounceTween = MoneyTextMesh.transform.DOScale(Vector3.one * 1.2f, 0.1f).OnComplete(() =>
            {
                MoneyTextMesh.transform.localScale = Vector3.one;
            });
        }
        tween = DOVirtual.Int(startValue, desiredValue, 0.5f, (a) => { MoneyTextMesh.text = a.ToString() + "$"; valueHolder = a; });
    }
}

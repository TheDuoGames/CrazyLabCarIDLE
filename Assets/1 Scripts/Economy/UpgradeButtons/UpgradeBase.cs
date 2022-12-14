using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UpgradeBase : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI costTMP;
    [ReadOnly] public int currentLevel;
    [ReadOnly] public int cost;
    public abstract void GetCurrentLevelAndCost();
    public abstract void UpgradeTargetData();
    public void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        GetCurrentLevelAndCost();
        costTMP.text = cost + "$";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Buy);
    }
    public void Buy()
    {
        if (!Economy.Instance.IsEnough(cost))
        {
            SoundManager.Instance.Play("buttonClickFailed");
            return;
        }

        SoundManager.Instance.Play("buttonClick");
        UpgradeTargetData();
        Economy.Instance.Remove(cost);
        UpgradeManager.Instance.Save();
        UpgradeManager.Instance.AssignTMPValues();
        Initialize();
    }
}

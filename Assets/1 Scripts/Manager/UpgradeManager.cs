using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-2000)]
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    private const string saveKey = "playerData_CrazyLab";
    public SavedData SavedData;
    public float currentSellBonus => 1 + (SavedData.currentSellLevel - 1) * 0.1f;
    public float currentEarningBonus => 1 + (SavedData.currentEarningLevel - 1) + Mathf.CeilToInt(SavedData.currentEarningLevel / 5);
    public float currentSpeedBonus => 1 + (SavedData.currentSellLevel - 1) * 0.1f;

    public TextMeshProUGUI sellBonusTMP;
    public TextMeshProUGUI earningBonusTMP;
    public TextMeshProUGUI speedBonusTMP;


    public void AssignTMPValues()
    {
        earningBonusTMP.text = currentEarningBonus.ToString();
        speedBonusTMP.text = currentSpeedBonus + "x";
        sellBonusTMP.text = currentSellBonus + "x";
    }

    private void Awake()
    {
        Instance = this;
        Load();
        AssignTMPValues();
    }
    #region SaveMethods
    [Button]
    public void Save() => ES3.Save(saveKey, SavedData);

    [Button]
    public void Load()
    {
        if (ES3.KeyExists(saveKey)) SavedData = ES3.Load(saveKey, SavedData);
    }
    [Button]
    public void Clear() => ES3.DeleteKey(saveKey);
    #endregion
}
[System.Serializable]
public class SavedData
{
    public int gameLevel;
    public int currentEarningLevel;
    public int currentSpeedLevel;
    public int currentSellLevel;
}

using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class UpgradeData : Singleton<UpgradeData>
{
    private const string saveKey = "upgradeData_CrazyLab";
    public PlayerData playerData;
    #region SaveMethods
    [Button]
    public void Save() => ES3.Save(saveKey, playerData);

    [Button]
    public void Load()
    {
        if (ES3.KeyExists(saveKey)) playerData = ES3.Load(saveKey, playerData);
    }
    [Button]
    public void Clear() => ES3.DeleteKey(saveKey); 
    #endregion
}


[System.Serializable]
public class PlayerData
{
    public int currentDropLevel;
    public int currentEarningLevel;
    public int currentSpeedLevel;
}

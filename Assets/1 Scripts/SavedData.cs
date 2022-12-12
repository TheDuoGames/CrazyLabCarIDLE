using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
namespace SaveSystem
{
    [DefaultExecutionOrder(-2000)]
    public class SavedData : Singleton<SavedData>
    {
        private const string saveKey = "playerData_CrazyLab";
        public PlayerData playerData;
        private new void Awake()
        {
            base.Awake();
            Load();
        }
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
        public int gameLevel;
        public int currentDropLevel;
        public int currentEarningLevel;
        public int currentSpeedLevel;
    }

}
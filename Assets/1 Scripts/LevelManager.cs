using UnityEngine;
using TMPro;
using SaveSystem;
using System.Collections.Generic;
using System;
using System.Collections;

public class LevelManager : Singleton<LevelManager>
{
    public bool testMode;
    public int currentLevel;
    public List<CarData> cars = new List<CarData>();
    public BuildableCar activeCarInScene;
    private WaitForSeconds nextLevelDelay = new WaitForSeconds(0.5f);
    private new void Awake()
    {
        base.Awake();
        if (testMode) return;
        SpawnLevel();
    }
    public void SpawnLevel()
    {
        var lastLevel = SavedData.Instance.playerData.gameLevel >= cars.Count ? UnityEngine.Random.Range(0, cars.Count) : SavedData.Instance.playerData.gameLevel;
        Instantiate(cars[lastLevel].levelPrefab);
    }
    public void CallNext()
    {
        StartCoroutine(CallNextAsync());
    }
    public IEnumerator CallNextAsync()
    {
        if (activeCarInScene.gameObject != null)
        {
            Destroy(activeCarInScene.gameObject, 0.5f);
        }
        yield return nextLevelDelay;
        // Confettie
        SavedData.Instance.playerData.gameLevel++;
        SavedData.Instance.Save();
        SpawnLevel();
        Observer.OnShapeOver.Invoke();
    }
}
#region Structures
[System.Serializable]
public class CarData
{
    public GameObject levelPrefab;
    public GameObject onePiecePrefab;
}
public enum NodeState
{
    Blank,
    Hidden,
    Left,
    Mid,
    Right
} 
#endregion
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
    private WaitForSeconds nextLevelDelay = new WaitForSeconds(0.1f);
    private new void Awake()
    {
        base.Awake();
        if (testMode) return;
        SpawnLevel();
    }
    private void OnEnable()
    {
        Observer.OnShapeOver.AddListener(SpawnLevel);
    }
    private void OnDisable()
    {
        Observer.OnShapeOver.RemoveListener(SpawnLevel);
    }
    public void SpawnLevel()
    {
        int lastLevel = SavedData.Instance.playerData.gameLevel;
        if (lastLevel >= cars.Count)
        {
            lastLevel = UnityEngine.Random.Range(0, cars.Count);
        }
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
            Destroy(activeCarInScene.gameObject, 0.09f);
        }
        yield return nextLevelDelay;
        // Confettie
        SavedData.Instance.playerData.gameLevel++;
        SavedData.Instance.Save();
        Observer.OnShapeOver.Invoke();
    }
}
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
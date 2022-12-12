using UnityEngine;
using TMPro;
using SaveSystem;
using System.Collections.Generic;

public class LevelManager : Singleton<LevelManager>
{
    public bool testMode;
    public int currentLevel;
    public List<CarData> cars = new List<CarData>();
    public BuildableCar activeCarInScene;
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
        Instantiate(cars[lastLevel].levelPrefab);
    }

}
[System.Serializable]
public class CarData
{
    public GameObject levelPrefab;
    public GameObject onePiecePrefab;
}
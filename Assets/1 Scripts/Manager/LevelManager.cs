using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;

public class LevelManager : Singleton<LevelManager>
{
    public bool testMode;
    public int currentLevel;
    public List<CarData> cars = new List<CarData>();
    public BuildableCar activeCarInScene;
    [ReadOnly] public int spawnedLevelIndex;
    public WaitForSeconds nextLevelDelay = new WaitForSeconds(2.0f);
    private new void Awake()
    {
        base.Awake();
        if (testMode) return;
        SpawnLevel();
    }
    public void SpawnLevel()
    {
        spawnedLevelIndex = UpgradeManager.Instance.SavedData.gameLevel >= cars.Count ? UnityEngine.Random.Range(0, cars.Count) : UpgradeManager.Instance.SavedData.gameLevel;
        Instantiate(cars[spawnedLevelIndex].levelPrefab);
    }
    public void CallNext()
    {
        StartCoroutine(CallNextAsync());
    }
    public IEnumerator CallNextAsync()
    {
        UpgradeManager.Instance.SavedData.gameLevel++;
        UpgradeManager.Instance.Save();
        Observer.OnShapeOver.Invoke(false);

        yield return nextLevelDelay;

        activeCarInScene.transform.SetParent(ProgressEnvironment.instance.transform);
        activeCarInScene.Dispose(cars[spawnedLevelIndex].onePiecePrefab);

        spawnedLevelIndex = UpgradeManager.Instance.SavedData.gameLevel >= cars.Count ? UnityEngine.Random.Range(0, cars.Count) : UpgradeManager.Instance.SavedData.gameLevel;
        ProgressEnvironment.instance.JoinNewCar(cars[spawnedLevelIndex].levelPrefab);
        Observer.OnShapeOver.Invoke(true);
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
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
[DefaultExecutionOrder(-1950)]
public class Economy : MonoBehaviour
{
    public static UnityEvent OnMoneyChange = new UnityEvent();
    [SerializeField] int money;
    private const string moneyKey = "moneySaveKey";
    public static Economy Instance;
    private void Awake()
    {
        Instance = this;
        Load();
    }
    public int CurrentCount() => money;
    public bool IsEnough(int count) => money - count >= 0;
    public void Add(int count)
    {
        money += count;
        OnMoneyChange.Invoke();
        Save();
    }
    public void Remove(int count)
    {
        money -= count;
        OnMoneyChange.Invoke();
        Save();
    }


    [Button] public void Cheat() => Add(2000);
    [Button] private void Load() { if (ES3.KeyExists(moneyKey)) money = ES3.Load<int>(moneyKey, 0); }
    [Button] private void Save() => ES3.Save(moneyKey, money);
    [Button] public void Clear()
    {
        money = 0;
        Add(50);
        ES3.DeleteKey(moneyKey);
    }

    private void OnApplicationQuit() => ES3.Save<int>(moneyKey, money);
    private void OnApplicationPause(bool pause) => ES3.Save<int>(moneyKey, money);
}

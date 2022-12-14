using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
[DefaultExecutionOrder(-1950)]
public class Economy : Singleton<Economy>
{
    public static UnityEvent OnMoneyChange = new UnityEvent();
    [ReadOnly] [SerializeField] int money;
    private const string moneyKey = "moneySaveKey";
    private new void Awake()
    {
        base.Awake();
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

    [Button] private void Load() { if (ES3.KeyExists(moneyKey)) money = ES3.Load<int>(moneyKey, 0); }
    [Button] private void Save() => ES3.Save(moneyKey, money);
    [Button] private void Delete() => ES3.DeleteKey(moneyKey);
    private void OnApplicationQuit() => ES3.Save<int>(moneyKey, money);
    private void OnApplicationPause(bool pause) => ES3.Save<int>(moneyKey, money);
}

using UnityEngine.Events;

public static class Observer
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent<int> OnLevelStart = new UnityEvent<int>();
    public static UnityEvent<bool> OnLevelEnd = new UnityEvent<bool>();
    public static UnityEvent OnFirstTap = new UnityEvent(); 
}

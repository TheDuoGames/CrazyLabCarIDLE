using UnityEngine.Events;

public static class Observer
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnPieceDrop = new UnityEvent();


    public static UnityEvent OnShapeOver = new UnityEvent();

}

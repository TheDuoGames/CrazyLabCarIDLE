using UnityEngine;
using UnityEngine.Events;

public static class Observer
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent<Vector3> OnPieceDrop = new UnityEvent<Vector3>();


    public static UnityEvent OnShapeOver = new UnityEvent();

}

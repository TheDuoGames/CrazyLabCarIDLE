using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class ProgressEnvironment : MonoBehaviour
{
    public static ProgressEnvironment instance;
    public void Awake() => instance = this;
    public void JoinNewCar(GameObject newCarPrefab)
    {
        transform.DORotate(Vector3.up * 120, 1.5f,RotateMode.LocalAxisAdd).SetRelative().OnComplete(() =>
        {
            Instantiate(newCarPrefab);
        });
    }
}

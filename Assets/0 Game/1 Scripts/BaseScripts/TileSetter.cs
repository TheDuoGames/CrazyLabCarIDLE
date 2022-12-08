using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetter : MonoBehaviour
{
    public bool refresh;
    public Vector3 axes;
    public float distance;
    void OnValidate()
    {
        if (refresh)
        {
            Vector3 startPos = Vector3.zero;
            Transform[] array = transform.GetComponentsInChildren<Transform>();
            for (int i = 1; i < array.Length; i++)
            {
                var item = array[i];
                item.localPosition = startPos;
                item.localPosition += axes * distance * i;
            }
        }
    }
}

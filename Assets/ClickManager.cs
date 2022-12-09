using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public static UnityEvent OnDropAvaible = new UnityEvent();
    private float dropRate = 0.25f;
    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dropRate)
        {
            timer = 0;
            OnDropAvaible.Invoke();
        }


        if (Input.GetMouseButtonDown(0))
        {
            timer = 0;
            OnDropAvaible.Invoke();
        }
    }
}

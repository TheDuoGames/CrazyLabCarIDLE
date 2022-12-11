using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[DefaultExecutionOrder(-2000)]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool pcInput;
    public bool tap { get { if (pcInput) { return Input.GetMouseButtonDown(0); } else { if (Input.touchCount > 0) { return true; } } return false; } }
    private void Awake()
    {
        instance = this;
    }
}

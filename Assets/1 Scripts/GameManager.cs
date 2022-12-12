using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace GameCore
{
    [DefaultExecutionOrder(-2000)]
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        Camera _camera;
        public Camera Camera { get { return (_camera == null) ? _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() : _camera; } }
        private void Awake()
        {
            instance = this;
        }
    }
}

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FeedbackSystem
{
    public class LocalCanvas : MonoBehaviour
    {
        public Canvas canvas;
        public bool lookAt;
        /// <summary>
        /// This is important for optimization, if world camera is empty Unity will request everyframe to find it
        /// </summary>
        private void OnEnable()
        {
            if (canvas.worldCamera == null && canvas != null)
            {
                canvas.worldCamera = GameManager.instance.Camera;
            }
        }
        public void LateUpdate()
        {
            if (lookAt) transform.LookAt(transform.position + GameManager.instance.Camera.transform.forward);
        }
    } 
}

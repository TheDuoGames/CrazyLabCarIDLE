using System.Collections;
using System.Collections.Generic;
using GameCore;
using UnityEngine;
using DG.Tweening;

public class ChangeCameraView : MonoBehaviour
{

    public List<Transform> views;
    private int currentIndex = 0;
    private bool onTransition;
    public float transitionTime = 0.33f;
    public void ChangeView()
    {
        SoundManager.Instance.Play("buttonClick");
        if (onTransition) return;
        onTransition = true;

        currentIndex++;
        if (currentIndex > views.Count - 1) currentIndex %= views.Count;

        Transform camTransform = GameManager.instance.Camera.transform;
        camTransform.DOMove(views[currentIndex].position, transitionTime);
        camTransform.DORotateQuaternion(views[currentIndex].rotation, transitionTime).OnComplete(() =>
        {
            onTransition = false;
        });

    }
}

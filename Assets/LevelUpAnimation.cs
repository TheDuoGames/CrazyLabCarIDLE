using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelUpAnimation : MonoBehaviour
{
    public int level;
    public Transform left, mid, right, hidden;
    public TextMeshProUGUI leftTMP, midTMP, rightTMP, hiddenTMP;
    Vector3 initPosLeft, initPosMid, initPosRight, initPosHidden;
    Vector3 initScaleLeft, initScaleMid, initScaleRight, initScaleHidden;
    private void Awake()
    {
        initPosLeft = left.transform.position;
    }
    private void OnEnable()
    {
        Observer.OnShapeOver.AddListener(AnimateAndRefresh);
    }
    private void OnDisable()
    {
        Observer.OnShapeOver.RemoveListener(AnimateAndRefresh);
    }

    private void AnimateAndRefresh()
    {
        level++;
        
    }
}

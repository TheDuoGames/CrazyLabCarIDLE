using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CoreInput;
using NaughtyAttributes;
using SaveSystem;
using System;

[DefaultExecutionOrder(-500)]
public class BuildableCar : MonoBehaviour
{
    public List<Transform> pieces = new List<Transform>();
    public AnimationCurve dropCurve;
    [ReadOnly] public int currentIndex = 0;
    [ReadOnly] public int totalPieceAmount;
    [Button]
    public void SetupChilds()
    {
        pieces = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        pieces.RemoveAt(0);
        totalPieceAmount = pieces.Count;
    }
    private void Awake()
    {
        foreach (Transform item in pieces)
        {
            item.transform.localPosition += Vector3.up * 8;
            item.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        LevelManager.Instance.activeCarInScene = this;
        ClickManager.OnDropAvaible.AddListener(DropNextPart);
    }

    private void OnDisable()
    {
        ClickManager.OnDropAvaible.RemoveListener(DropNextPart);
    }
    private void DropNextPart()
    {

        for (int i = 0; i < SavedData.Instance.playerData.currentDropLevel; i++)
        {
            if (currentIndex > (totalPieceAmount - 1))
            {
                LevelManager.Instance.CallNext();
                enabled = false;
                return;
            }
            int index = currentIndex;
            pieces[currentIndex].gameObject.SetActive(true);
            pieces[currentIndex].transform.DOLocalMoveY(-8, 2.0f).SetRelative().SetEase(dropCurve).OnComplete(() =>
            {
                Observer.OnPieceDrop.Invoke(pieces[index].position);
            });
            currentIndex++;
        }
    }

    public float CurrentRate() => (float)currentIndex / (float)totalPieceAmount;

    private void OnDestroy()
    {
        foreach (var item in pieces)
        {
            item.transform.DOKill();
        }
    }
}

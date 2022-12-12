using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CoreInput;
using NaughtyAttributes;
using SaveSystem;

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

    public void OnEnable()
    {
        LevelManager.Instance.activeCarInScene = this;
        ClickManager.OnDropAvaible.AddListener(DropNextPart);
    }

    public void OnDisable()
    {
        ClickManager.OnDropAvaible.RemoveListener(DropNextPart);
    }
    public void DropNextPart()
    {

        for (int i = 0; i < SavedData.Instance.playerData.currentDropLevel; i++)
        {
            if (currentIndex > (totalPieceAmount - 1))
            {
                Observer.OnShapeOver.Invoke();
                enabled = false;
                return;
            }
            pieces[currentIndex].gameObject.SetActive(true);
            pieces[currentIndex].transform.DOLocalMoveY(-8, 1.0f).SetRelative().SetEase(dropCurve).OnComplete(() =>
            {
                Observer.OnPieceDrop.Invoke();
            });
            currentIndex++;
        }

    }
}

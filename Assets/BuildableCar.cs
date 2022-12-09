using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BuildableCar : MonoBehaviour
{
    public List<Transform> pieces = new List<Transform>();
    public int currentIndex = 0;
    public AnimationCurve dropCurve;
    public void Start()
    {
        pieces = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        pieces.RemoveAt(0);
        foreach (Transform item in pieces)
        {
            item.transform.localPosition += Vector3.up * 8;
            item.gameObject.SetActive(false);
        }
    }

    public void OnEnable()
    {
        ClickManager.OnDropAvaible.AddListener(DropNextPart);
    }

    public void OnDisable()
    {
        ClickManager.OnDropAvaible.RemoveListener(DropNextPart);
    }
    public void DropNextPart()
    {
        if (currentIndex > pieces.Count - 1)
        {
            Debug.LogWarning("Shape Over");
            ClickManager.OnDropAvaible.RemoveListener(DropNextPart);
            return;
        }
        pieces[currentIndex].gameObject.SetActive(true);
        pieces[currentIndex].transform.DOLocalMoveY(-8, 1.0f).SetRelative().SetEase(dropCurve);
        currentIndex++;
    }
}

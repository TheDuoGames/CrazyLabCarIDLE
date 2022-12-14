using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CoreInput;
using NaughtyAttributes;
[DefaultExecutionOrder(-500)]
public class BuildableCar : MonoBehaviour
{
    public List<Transform> pieces = new List<Transform>();
    public AnimationCurve dropCurve;
    public int finalPrice;
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

        for (int i = 0; i < IncreaseDropMultiplier.dropMultiplier; i++)
        {
            if (currentIndex > (totalPieceAmount - 1))
            {
                LevelManager.Instance.CallNext();
                enabled = false;
                return;
            }
            pieces[currentIndex].gameObject.SetActive(true);
            Economy.Instance.Add(Mathf.RoundToInt(UpgradeManager.Instance.currentEarningBonus));
            pieces[currentIndex].transform.DOLocalMoveY(-8, 2.0f).SetRelative().SetEase(dropCurve);
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

    public void Dispose(GameObject onePiecePrefab)
    {
        Observer.OnCarSold.Invoke(finalPrice);
        GameObject spawnedOnePiece = Instantiate(onePiecePrefab, transform.position, transform.rotation, null);
        spawnedOnePiece.transform.SetParent(transform.parent);
        spawnedOnePiece.AddComponent<MoveAndDisappear>().Animate();
        Destroy(gameObject);
    }
}

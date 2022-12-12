using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SaveSystem;
using DG.Tweening;

public class LevelNode : MonoBehaviour
{
    public NodeState currentState;
    public TextMeshProUGUI levelTMP;
    public int CurrentLevel => SavedData.Instance.playerData.gameLevel + 1;
    private float leftPosX = -220.0f;
    private float rightPosX = 220.0f;
    public void Awake()
    {
        AssignValues();
    }
    private void OnEnable()
    {
        Observer.OnShapeOver.AddListener(MoveNextNode);
    }
    private void OnDisable()
    {
        Observer.OnShapeOver.RemoveListener(MoveNextNode);
    }
    public void AssignValues()
    {
        switch (currentState)
        {
            case NodeState.Blank:
                break;
            case NodeState.Hidden:
                levelTMP.text = (CurrentLevel + 2).ToString();
                break;
            case NodeState.Left:
                levelTMP.text = (CurrentLevel - 1).ToString();
                break;
            case NodeState.Mid:
                levelTMP.text = CurrentLevel.ToString();
                break;
            case NodeState.Right:
                levelTMP.text = (CurrentLevel + 1).ToString();
                break;
            default:
                break;
        }
    }
    public void MoveNextNode()
    {
        NodeState nextNode = GetNextNode();
        currentState = nextNode;
        switch (nextNode)
        {
            case NodeState.Blank:
                Debug.LogWarning("An Unexpected Error Occured in Level Node System", this);
                break;
            case NodeState.Hidden:
                transform.DOScale(Vector3.zero, 0.1f).OnComplete(() =>
                {
                    transform.DOMoveX(rightPosX, 0);
                    levelTMP.text = (CurrentLevel + 1).ToString();
                });
                break;
            case NodeState.Left:
                transform.DOScale(Vector3.one * 2, 0.1f);
                transform.DOMoveX(leftPosX, 0.1f);
                break;
            case NodeState.Mid:
                transform.DOScale(Vector3.one * 3, 0.1f);
                transform.DOMoveX(0, 0.1f);

                break;
            case NodeState.Right:
                transform.DOScale(Vector3.one * 2, 0.1f);
                transform.DOMoveX(rightPosX, 0.1f);
                break;
            default:
                break;
        }
    }
    public NodeState GetNextNode()
    {
        switch (currentState)
        {
            case NodeState.Hidden:
                return NodeState.Right;
            case NodeState.Left:
                return NodeState.Hidden;
            case NodeState.Mid:
                return NodeState.Left;
            case NodeState.Right:
                return NodeState.Mid;
            default:
                return NodeState.Blank;
        }
    }
}

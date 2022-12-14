using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Transform textTransform;
    public Transform finger;
    public Transform tutorialParent;

    public void OnEnable()
    {
        StartCoroutine(WaitForTap());
        TextAnimation();
        FingerAnimation();
    }

    public void TextAnimation()
    {
        textTransform.DOScale(Vector3.one * 1.2f, 1.0f).OnComplete(() =>
        {
            textTransform.DOScale(Vector3.one * 1.2f, 0.5f).OnComplete(TextAnimation);
        });
    }
    public void FingerAnimation()
    {
        finger.transform.DORotate(Vector3.right * 15.0f, 0.3f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
    }

    IEnumerator WaitForTap()
    {
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        tutorialParent.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveAndDisappear : MonoBehaviour
{
    private bool canAnimate;
    private float speed = 24.0f;
    void Update()
    {
        if (canAnimate)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
    }

    public void Animate()
    {
        StartCoroutine(AnimateAsync());
    }

    public IEnumerator AnimateAsync()
    {
        yield return LevelManager.Instance.nextLevelDelay;
        canAnimate = true;
        transform.DORotate(Vector3.up * -30, 0.2f, RotateMode.LocalAxisAdd).SetRelative().SetDelay(0.1f).OnComplete(() =>
        {
            speed *= 1.5f;
        });
        Destroy(gameObject, 3.0f);
    }
}

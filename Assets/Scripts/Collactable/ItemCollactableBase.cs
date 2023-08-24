using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollactableBase : MonoBehaviour
{
    [Header("Animation Setup")]
    public float jumpScaleY = 0;
    public float jumpScaleX = 0;
    public float animationJumpDuration = 0.3f;
    public Ease ease = Ease.OutBack;
    public string compareTag = "Player";
    public CircleCollider2D coinCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        HandleScale();
        StartCoroutine(DestroyCoin());
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }

    private void HandleScale()
    {
        transform.DOScaleY(jumpScaleY, animationJumpDuration).SetEase(ease);
        transform.DOScaleX(jumpScaleX, animationJumpDuration).SetEase(ease);
    }

    private IEnumerator DestroyCoin()
    {
        coinCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}

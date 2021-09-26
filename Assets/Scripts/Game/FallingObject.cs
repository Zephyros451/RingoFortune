using UnityEngine;
using DG.Tweening;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;

    private readonly float speed = -0.1f;
    private readonly float scale = 0.22f;
    private bool shouldFall = false;

    private float leftCorner;
    private float rightCorner;

    private void FixedUpdate()
    {
        if (shouldFall)
        {
            transform.Translate(new Vector3(0, speed, 0f));
        }
    }

    public void Initialize(float leftCorner, float rightCorner)
    {
        this.leftCorner = leftCorner;
        this.rightCorner = rightCorner;
    }

    public void Reset()
    {
        transform.position = new Vector3(Random.Range(leftCorner, rightCorner), 12f, 0);
        transform.DOScale(scale, 0f);
        shouldFall = false;
    }

    public void Release()
    {
        shouldFall = true;
        collider.enabled = true;
    }

    public void Shrink()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0, 0.2f));
        sequence.AppendCallback(Reset);

        collider.enabled = false;
    }
}

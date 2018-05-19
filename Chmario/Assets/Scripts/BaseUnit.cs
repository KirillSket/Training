using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField]
    protected float moveSpid = 1f;

    protected bool isDead = false;
    [SerializeField]
    protected float dieAnimationTime = 1.5f;
    [SerializeField]
    public int hp = 1;

    protected tk2dSprite bodySprite;
    protected tk2dSpriteAnimator bodyAnimator;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        bodySprite = GetComponentInChildren<tk2dSprite>();
        bodyAnimator = GetComponentInChildren<tk2dSpriteAnimator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Jerk()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 1f, ForceMode2D.Impulse);
    }
    public virtual void TakeDamage(bool toDeath)
    {
        if (toDeath) hp = 0;
        else hp--;
        if (!isDead) Jerk();
        if (hp <= 0) StartCoroutine(Die(dieAnimationTime));
        if (hp > 0 && this is Player) bodyAnimator.Play("hurt");
    }
    protected virtual IEnumerator Die(float dieAnimationTime)
    {
        isDead = true;
        bodyAnimator.Play("death");
        rb.Sleep();
        rb.isKinematic = true;
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);
    }
}

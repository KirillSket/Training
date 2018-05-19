using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Monster : BaseUnit
{
    [SerializeField]
    private bool lookUnderFeet = true;
    private Vector3 dirRight;

    private void Start()
    {
        dirRight = transform.right;
    }

    private void Update()
    {
        if (!isDead) SimpleMove();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        BaseUnit unit = coll.GetComponent<BaseUnit>();

        if (unit && unit is Player && !isDead)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.15f)
            {
                unit.Jerk();
                TakeDamage(false);
            }
            else unit.TakeDamage(false);
        }
    }

    private void SimpleMove()
    {
        Collider2D[] onEmptinessColliders = Physics2D.OverlapCircleAll(transform.position + (dirRight * 0.25f) + (transform.up * -0.3f), 0.1f);
        Collider2D[] onWallsColliders = Physics2D.OverlapCircleAll(transform.position + (dirRight * 0.18f), 0.01f);

        bool chet = false;
        if (lookUnderFeet) chet = onEmptinessColliders.Length <= 0;
        else chet = false;

        if (chet || onWallsColliders.Length > 0 && onWallsColliders.All(x => !x.GetComponent<Player>()))
        {
            bodySprite.scale = new Vector3(bodySprite.scale.x * -1, 1, 0);
            BoxCollider2D bc = GetComponent<BoxCollider2D>();
            bc.offset = new Vector2(bc.offset.x * -1, bc.offset.y);
            dirRight *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dirRight, moveSpid * Time.deltaTime);
    }
}

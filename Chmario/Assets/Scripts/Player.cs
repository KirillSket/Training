using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
    [SerializeField]
    private float jumpForse = 1f;
    private bool isGrounded = false;
    private int jumpCount = 1;

    private bool jump_offPlatform = false;

    private CapsuleCollider2D myCapsColl;
    private void Start()
    {
        myCapsColl = GetComponent<CapsuleCollider2D>();
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float translation = Input.GetAxis("Horizontal") * moveSpid * Time.deltaTime;
            transform.Translate(translation, 0, 0);

            if (translation > 0) bodySprite.scale = new Vector3(1, 1, 0);
            else bodySprite.scale = new Vector3(-1, 1, 0);
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetButtonDown("Vertical") && jumpCount < 2)
        {
            jumpCount++;
            rb.AddForce(transform.up * jumpForse);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            // добавить логику присажывания
            jump_offPlatform = true;
        }
        else if (Input.GetAxis("Vertical") >= 0) jump_offPlatform = false;
        AnimDistributor();
    }
    private void AnimDistributor()
    {
        if(Input.GetAxis("Vertical") < 0) bodyAnimator.Play("crouch");
        else
        {
            if(!isGrounded) bodyAnimator.Play("jump");
            else
            {
                if(Input.GetAxis("Horizontal") == 0) bodyAnimator.Play("idle");
                else bodyAnimator.Play("run");
            }
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update ()
    {
        if(!isDead)
        Move();

        if (transform.position.y < -1000)
        {
            StartCoroutine(Die(dieAnimationTime));
        }
    }

    private void CheckGround()
    {
        Vector2 colPosition = new Vector2(transform.position.x, transform.position.y - 0.16f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(colPosition, 0.01f);
        if (colliders.Length > 1)
        {
            jumpCount = 1;
            isGrounded = true;
        }
        else isGrounded = false;

        foreach(Collider2D c in colliders)
        {
            if(c.tag == "Platform" && !jump_offPlatform)
            {
                c.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}

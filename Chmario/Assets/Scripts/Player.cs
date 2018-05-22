using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BaseUnit
{
    [SerializeField]
    private float jumpForse = 1f;
    private bool isGrounded = false;
    private int jumpCount = 1;

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float translation = Input.GetAxis("Horizontal") * moveSpid * Time.deltaTime;
            transform.Translate(translation, 0, 0);

            if (translation > 0) bodySprite.scale = new Vector3(1, 1, 0);
            else bodySprite.scale = new Vector3(-1, 1, 0);
        }

        //bool imJumpNow = false;
        if (Input.GetButtonDown("Vertical"))
        {
            float ver = Input.GetAxis("Vertical");
            if (ver > 0 && jumpCount < 2)
            {
                //imJumpNow = true;
                jumpCount++;
                rb.AddForce(transform.up * jumpForse);
                bodyAnimator.Play("jump");
            }
        }
        if (Input.GetButton("Vertical")/* && isGrounded*/)
        {
            float ver = Input.GetAxis("Vertical");
            if (ver < 0)
            {
                bodyAnimator.Play("crouch");
            }
        }
        else if (Input.GetAxis("Horizontal") != 0 && isGrounded) bodyAnimator.Play("run");

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") >= 0 && isGrounded && !bodyAnimator.IsPlaying("hurt"))
            bodyAnimator.Play("idle");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update ()
    {
        if(!isDead)
        Move();

        if(transform.position.y < -100)
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
    }

    protected void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }

}

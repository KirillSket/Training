using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseUnit : MonoBehaviour
{
    [SerializeField]
    protected int hp = 5;
    [SerializeField]
    protected float moveSpid = 1f;

    protected void Die()
    {
        Destroy(gameObject);
    }

    protected void Move()
    {
        float translation = Input.GetAxis("Horizontal") * moveSpid * Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    void Update ()
    {
        Move();

        if(transform.position.y < -1)
        {
            Die();
            SceneManager.LoadScene(0);
        }		
	}
}

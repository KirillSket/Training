using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBar : MonoBehaviour
{
    private Player player;

    private int pointCount = 0;
    private tk2dTextMesh myText;

    private Vector3 curScale;

    private void Awake()
    {
        myText = GetComponent<tk2dTextMesh>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curScale = new Vector3(0.007f, 0.007f, 1f);
    }

    private void FixedUpdate()
    {
        if (player.point != pointCount)
        {
            myText.text = player.point + "";
            pointCount = player.point;
        }

        if (transform.localScale != curScale) transform.localScale = curScale;
    }
}

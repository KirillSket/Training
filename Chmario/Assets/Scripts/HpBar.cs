using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private int pixelIconX = 21;
    [SerializeField]
    private int pixelIconY = 21;

    private int hpCount = 0;
    private tk2dTiledSprite mySprite;

    private void Awake()
    {
        mySprite = GetComponent<tk2dTiledSprite>();
    }

    private void FixedUpdate()
    {
        if(player.hp != hpCount)
        {
            mySprite.dimensions = new Vector2(pixelIconX * player.hp, pixelIconY);
            hpCount = player.hp;
        }
    }
}

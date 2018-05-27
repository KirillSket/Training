using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatform : MonoBehaviour
{
    BoxCollider2D bColl;
    void Start()
    {
        bColl = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!bColl.isTrigger)
            bColl.isTrigger = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private bool itsPoint = true;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        BaseUnit unit = coll.GetComponent<BaseUnit>();

        if (unit && unit is Player)
        {
            if (itsPoint) unit.point++;
            else unit.hp++;
            Destroy(gameObject);
        }
    }
}

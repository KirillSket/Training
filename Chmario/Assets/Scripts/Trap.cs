using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private bool toDeath = true;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        BaseUnit unit = coll.GetComponent<BaseUnit>();

        if(unit)
        {
            unit.TakeDamage(toDeath);
        }
    }
}

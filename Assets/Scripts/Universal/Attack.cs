using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("基本參數")]
    public int damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Character>()?.takeDamage(this);
    }
}

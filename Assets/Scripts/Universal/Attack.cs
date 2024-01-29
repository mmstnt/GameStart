using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("基本參數")]
    public int damage;
    private bool attackPrepare;
    private bool attackDamage;
    public float attackPrepareTime;
    public float attackDamageTime;
    public float attackTime;
    private float attackDuration;

    private void OnEnable()
    {
        attackPrepare = true;
        attackDamage = true;
        attackDuration = attackTime;
    }

    private void Update()
    {
        attackDuration -= Time.deltaTime;
        if (attackPrepare && (attackDuration < attackTime - attackPrepareTime))
        {
            attackPrepare = false;
        }
        else if(attackDamage && (attackDuration < attackTime - attackDamageTime)) 
        {
            attackDamage = false;
        }
        else if (attackDuration <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackPrepare)
            return;
        if(attackDamage)
            collision.GetComponent<Character>()?.takeDamage(this);
    }


}

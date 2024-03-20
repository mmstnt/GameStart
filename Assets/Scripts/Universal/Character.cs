using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("屬性")]
    public int maxHp;
    public int currentHp;
    [Header("受傷無敵")]
    public float invincibleTime;
    private float invincibleDuration;
    public bool invincible;
    [Header("事件")]
    public UnityEvent<Transform> onTakeDamage;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void Update()
    {
        if (invincible) 
        {
            invincibleDuration -= Time.deltaTime;
            if (invincibleDuration <= 0 ) 
                invincible = false;
        }
    }

    public void takeDamage(Attack attacker)
    {
        if (invincible)
            return;
        if (currentHp - attacker.damage > 0)
        {
            //扣血無敵
            currentHp -= attacker.damage;
            if (!invincible)
            {
                invincibleDuration = invincibleTime;
                invincible = true;
            }
            //執行受傷
            onTakeDamage?.Invoke(attacker.transform);
        }
        else 
        {
            currentHp = 0;
            //死亡程式(尚未製作)
        }
    }
}

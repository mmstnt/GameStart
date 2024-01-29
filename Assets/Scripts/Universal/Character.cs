using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("�ݩ�")]
    public int maxHp;
    public int currentHp;
    [Header("�L��")]
    public float invincibleTime;
    private float invincibleDuration;
    public bool invincible;

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
        if (currentHp - attacker.damage <= 0)
        {
            currentHp = 0;
            //���`�{��(�|���s�@)
        }
        else 
        {
            //����L��
            currentHp -= attacker.damage;
            if (!invincible) 
            {
                invincibleDuration = invincibleTime;
                invincible = true;
            }
        }
    }
}

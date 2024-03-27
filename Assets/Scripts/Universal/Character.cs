using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("�ݩ�")]
    public float maxHp;
    public float currentHp;
    [Header("���˵L��")]
    public float invincibleTime;
    private float invincibleDuration;
    public bool invincible;
    [Header("�ƥ�")]
    public UnityEvent<Transform> onTakeDamage;
    public UnityEvent<Character> onHealthChange;
    private void Start()
    {
        currentHp = maxHp;
        onHealthChange?.Invoke(this);
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
            //����L��
            currentHp -= attacker.damage;
            if (!invincible)
            {
                invincibleDuration = invincibleTime;
                invincible = true;
            }
            //�������
            onTakeDamage?.Invoke(attacker.transform);
        }
        else 
        {
            currentHp = 0;
            //���`�{��(�|���s�@)
        }
        onHealthChange?.Invoke(this);
    }
}

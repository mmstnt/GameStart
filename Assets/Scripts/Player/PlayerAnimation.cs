using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rd;
    private PhysicsCheck physicsCheck;
    private PlayerController playerController;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rd = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        physicsCheck = transform.parent.gameObject.GetComponent <PhysicsCheck>();
        playerController = transform.parent.gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        setAnimation();
    }

    private void setAnimation() 
    {
        ani.SetFloat("velocityX", Mathf.Abs(rd.velocity.x));
        ani.SetFloat("velocityY", rd.velocity.y);
        ani.SetBool("isGround", physicsCheck.isGround);
        ani.SetBool("isAttack", playerController.isAttack);
        ani.SetBool("isFall",ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerFall"));
    }

    public void playerHurt() 
    {
        ani.SetTrigger("isHurt");
    }

    public void playerInterrupt() 
    {
        ani.SetTrigger("isInterrupt");
    }
}

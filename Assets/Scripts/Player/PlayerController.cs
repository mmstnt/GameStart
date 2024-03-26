using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.Events;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControl inputControl;
    private Vector2 inputDirection;
    private Rigidbody2D rd;
    private PhysicsCheck physicsCheck;
    private Animator ani;
    [Header("把计")]
    public float speed;
    public float jumpForce;
    public float hurtForce;
    public bool isHurt;
    public bool isAttack;
    public bool isFall;
    public UnityEvent playerInterrupt;
    //╬把计
    private int faceDir;
    private bool action;

    private void Awake()
    {
        //莉じン
        rd = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        ani = transform.Find("Ani").GetComponent<Animator>();
        //龄砞竚
        inputControl = new PlayerInputControl();
        inputControl.GamePlay.Move.started += AttackInterrupt;
        inputControl.GamePlay.Jump.started += jump;
        inputControl.GamePlay.Attack.started += attack;
        //莉ン
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        isFall = ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerFall");
        action = isAttack || isHurt || isFall;
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move() 
    {
        if (action)
            return;
        rd.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rd.velocity.y);
        faceDir = inputDirection.x != 0 ? (inputDirection.x > 0 ? 1 : -1) : (int)transform.localScale.x;
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void jump(InputAction.CallbackContext obj)
    {
        if (physicsCheck.isGround)
            rd.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void attack(InputAction.CallbackContext obj)
    {
        if (isAttack)
            return;
        isAttack = true;
    }

    private void AttackInterrupt(InputAction.CallbackContext obj)
    {
        if(!isAttack)
            return;
        isAttack = false;
        playerInterrupt?.Invoke();
    }

    public void getHurt(Transform attacker) 
    {
        isHurt = true;
        rd.velocity = Vector3.zero;
        Vector2 dirForce = new Vector2(transform.position.x - attacker.position.x,0).normalized;
        rd.AddForce(dirForce * hurtForce, ForceMode2D.Impulse);
    }
}

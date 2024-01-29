using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControl inputControl;
    private Vector2 inputDirection;
    private Rigidbody2D rd;
    private PhysicsCheck physicsCheck;
    [Header("參數")]
    public float speed;
    public float jumpForce;
    [Header("子物件")]
    public GameObject atk01;
    //私人參數
    private int faceDir;
    private bool action;
    private bool atk;

    [System.Obsolete]
    private void Awake()
    {
        //獲取元件
        rd = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        //按鍵功能設置
        inputControl = new PlayerInputControl();
        inputControl.GamePlay.Move.started += moveAttackInterrupt;
        inputControl.GamePlay.Jump.started += jump;
        inputControl.GamePlay.Attack.started += attack;
        //獲取子物件
        atk01 = transform.Find("Atk01").gameObject;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    [System.Obsolete]
    private void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        atk = atk01.active;
        action = atk;
        if (atk && physicsCheck.isGround)
            rd.velocity = new Vector2(0, rd.velocity.y);
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

    [System.Obsolete]
    private void attack(InputAction.CallbackContext obj)
    {
        if (atk)
            return;
        atk01.SetActive(true);
    }

    private void moveAttackInterrupt(InputAction.CallbackContext obj)
    {
        if(!atk)
            return;
        atk01.SetActive(false);
    }
}

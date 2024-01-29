using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isGround;
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask groundLayer;

    private void Update() 
    {
        checkGround();
    }

    private void checkGround() 
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position+bottomOffset,checkRaduis,groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        //ø�s�a���I���I
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
}

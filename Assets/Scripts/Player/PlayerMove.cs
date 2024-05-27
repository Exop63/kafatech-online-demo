using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    public float speed = 1;


    [SyncVar]
    [HideInInspector] public Vector2 direction;

    public bool IsMoving => direction.sqrMagnitude > 0;
    [Command]
    public void CmdSetDirectin(Vector2 dir)
    {
        direction = dir;
        transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position + dir.normalized, Time.deltaTime * speed);
    }
}

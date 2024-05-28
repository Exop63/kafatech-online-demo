
using Mirror;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    public float speed = 1;
    private Vector2 bounds = Vector2.one;

    [SyncVar]
    [HideInInspector] public Vector2 direction;

    public bool IsMoving => direction.sqrMagnitude > 0;


    private void Awake()
    {
        var characterBounds = GetComponentInChildren<SpriteRenderer>().bounds.size;
        bounds = Utils.GetScreenBounds() - (Vector2)characterBounds * .5f;
    }
    [Command]
    public void CmdSetDirectin(Vector2 dir)
    {
        direction = dir;
        transform.position = Vector2.Lerp(transform.position, Utils.ScreenClamp((Vector2)transform.position + dir.normalized, bounds), Time.deltaTime * speed);

    }
}

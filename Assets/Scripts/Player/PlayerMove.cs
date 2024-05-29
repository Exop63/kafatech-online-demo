
using Mirror;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    public float speed = 1;
    [SyncVar]
    public Vector2 bounds = Vector2.zero;

    [SyncVar]
    [HideInInspector] public Vector2 direction;

    public bool IsMoving => direction.sqrMagnitude > 0;


    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        var characterBounds = GetComponentInChildren<SpriteRenderer>().bounds.size;
        var tmpBounds = Utils.GetScreenBounds() - (Vector2)characterBounds * .5f;
        CmdBound(tmpBounds, NetworkServer.active && NetworkClient.active);
    }
    public void SetDirection(Vector2 dir)
    {
        CmdSetDirectin(dir);
    }
    private void Update()
    {
        if (!isServer) return;
        transform.position = Utils.ScreenClamp((Vector2)transform.position + direction.normalized * Time.deltaTime * speed, GameManager.Instance.ServerBounds);
    }
    [Command]
    public void CmdSetDirectin(Vector2 dir)
    {
        direction = dir;
    }

    [Command]
    private void CmdBound(Vector2 bounds, bool isHost)
    {
        this.bounds = bounds;
        if (isHost) GameManager.Instance.ServerBounds = bounds;
    }

}

using System;
using Mirror;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [SyncVar]
    public float current;

    public float max;
    public Hud hudPrefab;

    public bool IsDeath => current == 0;

    private Hud hudObject;

    public override void OnStartClient()
    {
        base.OnStartClient();
        hudObject = Instantiate(hudPrefab, GameObject.Find("Canvas").transform);
        hudObject.Setup(this);
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        current = max;
    }

    private void OnDestroy()
    {

        if (hudObject != null)
        {
            DestroyImmediate(hudObject);
        }
    }
    [ServerCallback]
    public virtual void TakeDamage(float damage)
    {
        current = Math.Max(0, current -= damage);
        if (IsDeath)
        {
            Death();
        }
    }
    [ServerCallback]
    protected virtual void Death()
    {
        RpcDeath();

    }
    [ClientRpc]
    public virtual void RpcDeath() { }
}

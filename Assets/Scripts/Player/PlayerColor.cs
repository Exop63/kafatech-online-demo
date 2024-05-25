using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerColor : NetworkBehaviour
{
    public SpriteRenderer spriteRenderer;
    public override void OnStartClient()
    {
        base.OnStartClient();
        spriteRenderer.color = Color.red;
        if (isLocalPlayer)
        {
            spriteRenderer.color = Color.green;
        }
    }
}

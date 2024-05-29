using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    [SyncVar]
    public Vector2 ServerBounds = new Vector2(2.54f, 4.74f);
    public readonly Vector2 DefaultServerBounds = new Vector2(2.54f, 4.74f);

}

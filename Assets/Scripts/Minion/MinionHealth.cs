using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MinionHealth : Health
{

    protected override void Death()
    {
        NetworkServer.Destroy(gameObject);
    }

}

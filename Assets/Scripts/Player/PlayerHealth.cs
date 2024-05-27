using Mirror;
using UnityEngine;

public class PlayerHealth : Health
{
    [ClientRpc]
    public override void RpcDeath()
    {
        var endGame = FindAnyObjectByType<EndGamePanel>(FindObjectsInactive.Include);
        if (endGame != null)
        {
            endGame.GetComponent<EndGamePanel>().Show(Player.local.gameObject == gameObject);
        }
    }

}

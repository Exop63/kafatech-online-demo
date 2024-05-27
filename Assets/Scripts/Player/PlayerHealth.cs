using Mirror;
using UnityEngine;

public class PlayerHealth : Health
{
    [ClientRpc]
    public override void RpcDeath()
    {
        Debug.Log(nameof(RpcDeath));
        var endGame = FindAnyObjectByType<EndGamePanel>(FindObjectsInactive.Include);
        if (endGame != null)
        {
            endGame.GetComponent<EndGamePanel>().Show(Minion.local.gameObject == gameObject);
        }
    }

}

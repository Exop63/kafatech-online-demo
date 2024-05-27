using Mirror;
using UnityEngine;

public class MinionManager : MonoBehaviour
{

    public float reSpawnTime = 5;


    public Minion minion;


    private double spawnTime = 0;

    [ServerCallback]
    private void Update()
    {
        if (!NetworkServer.active || Minion.OnlinePlayers.Count < 2 || spawnTime > NetworkTime.time) return;
        spawnTime = NetworkTime.time + reSpawnTime;
        var minionObject = Instantiate(minion);
        NetworkServer.Spawn(minionObject.gameObject);
    }
}

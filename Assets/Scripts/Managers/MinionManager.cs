using Mirror;
using UnityEngine;

public class MinionManager : MonoBehaviour
{
    public static bool CanIntreact = true;
    public float reSpawnTime = 5;


    public Minion minion;


    private double spawnTime = 0;

    private void OnEnable()
    {
        CanIntreact = true;
    }

    [ServerCallback]
    private void Update()
    {
        if (!NetworkServer.active || spawnTime > NetworkTime.time || !CanIntreact) return;
        spawnTime = NetworkTime.time + reSpawnTime;
        var pos = Random.insideUnitSphere * 3.4f;
        pos.z = 0;
        pos.x = Mathf.Clamp(pos.x, -2.4f, 2.4f);
        var minionObject = Instantiate(minion, pos, Quaternion.identity);
        NetworkServer.Spawn(minionObject.gameObject);
    }
}

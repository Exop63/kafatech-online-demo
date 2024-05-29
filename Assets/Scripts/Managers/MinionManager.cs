using Mirror;
using UnityEngine;

public class MinionManager : MonoBehaviour
{
    public static bool CanIntreact = true;
    public float reSpawnTime = 5;


    public Minion minion;


    private double spawnTime = 0;
    private Vector2 bounds = Vector2.one;
    private void Awake()
    {
        var characterBounds = minion.GetComponentInChildren<SpriteRenderer>().bounds.size;
        bounds = Utils.GetScreenBounds() - (Vector2)characterBounds * .5f;
    }
    private void OnEnable()
    {
        CanIntreact = true;
    }

    [ServerCallback]
    private void Update()
    {

        if (!NetworkServer.active || spawnTime > NetworkTime.time || !CanIntreact) return;
        spawnTime = NetworkTime.time + reSpawnTime;
        var pos = Utils.ScreenClamp(Random.insideUnitSphere * 3.4f, bounds);
        pos.z = 0;
        var minionObject = Instantiate(minion, pos, Quaternion.identity);
        NetworkServer.Spawn(minionObject.gameObject);
    }
}

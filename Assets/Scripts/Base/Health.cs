using Mirror;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [SyncVar]
    public float current;

    public float max;
    public Hud hudPrefab;

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
}

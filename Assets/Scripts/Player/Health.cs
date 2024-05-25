using Mirror;

public class Health : NetworkBehaviour
{
    [SyncVar]
    public float current;
    public float max;

    public override void OnStartServer()
    {
        base.OnStartServer();
        current = max;
    }


}

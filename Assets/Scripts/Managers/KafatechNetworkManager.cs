using Mirror;
using UnityEngine;

public class KafatechNetworkManager : NetworkManager
{

    public override void OnStartServer()
    {
        base.OnStartServer();
        GameObject.Find("NetworkTypeSelectPanel")?.gameObject.SetActive(false);
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        GameObject.Find("NetworkTypeSelectPanel")?.gameObject.SetActive(false);

    }

    public override void OnClientError(TransportError error, string reason)
    {
        base.OnClientError(error, reason);
        Debug.LogError("reason:" + reason + " Error: " + error.ToString());
        Notify.Instance.ShowError("reason:" + reason + " Error: " + error.ToString());
    }

}

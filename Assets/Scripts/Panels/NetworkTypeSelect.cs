using Mirror;
using UnityEngine;


public enum ConnectionType
{
    Server,
    Host,
    Client
}
public class NetworkTypeSelect : MonoBehaviour
{

    public StartGamePanel startGamePanel;

    [HideInInspector] public ConnectionType ConnectionType = ConnectionType.Server;

    private void Awake()
    {
#if UNITY_ANDROID
OnClickClient();
#endif
    }

    public void OnClickServer()
    {
        ConnectionType = ConnectionType.Server;
        startGamePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClickHost()
    {
        ConnectionType = ConnectionType.Host;
        startGamePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);


    }


    public void OnClickClient()
    {
        ConnectionType = ConnectionType.Client;
        startGamePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
}

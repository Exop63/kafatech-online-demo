using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class StartGamePanel : MonoBehaviour
{
    public NetworkTypeSelect networkTypeSelect;
    public TMP_InputField input_Address;

    private void OnEnable()
    {
        input_Address.gameObject.SetActive(networkTypeSelect.ConnectionType == ConnectionType.Client);
    }
    public void OnClickStartGame()
    {
        switch (networkTypeSelect.ConnectionType)
        {
            case ConnectionType.Server:
                NetworkManager.singleton.StartServer();

                break;
            case ConnectionType.Host:
                NetworkManager.singleton.StartHost();

                break;
            case ConnectionType.Client:
                if (string.IsNullOrEmpty(input_Address.text))
                {
                    Debug.LogError("network address cannot be null or empty.");
                    Notify.Instance.ShowError("network address cannot be null or empty.");
                    return;
                }
                NetworkManager.singleton.networkAddress = input_Address.text;
                NetworkManager.singleton.StartClient();
                break;
        }

    }

    public void OnClickBack()
    {

        networkTypeSelect.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

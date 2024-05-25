using Mirror;
using UnityEngine;
using TMPro;
public class NetworkTypeSelect : MonoBehaviour
{

    public TMP_InputField txt_Address;



    public void OnClickServer()
    {
        NetworkManager.singleton.StartServer();
    }

    public void OnClickHost()
    {
        NetworkManager.singleton.StartHost();
    }


    public void OnClickClient()
    {

        if (string.IsNullOrEmpty(txt_Address.text))
        {
            Debug.LogError("network address cannot be null or empty.");
            Notify.Instance.ShowError("network address cannot be null or empty.");

            return;
        }
        NetworkManager.singleton.networkAddress = txt_Address.text;
        NetworkManager.singleton.StartClient();
    }
}

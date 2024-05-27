using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour
{
    public TextMeshProUGUI txt_Info;
    public void Show(bool isDeath)
    {
        if (isDeath)
        {
            // lost
            txt_Info.text = "<color=red> You Lost</color>";
        }
        else
        {
            // win
            txt_Info.text = "<color=green> You Won</color>";
        }
        gameObject.SetActive(true);
        MinionManager.CanIntreact = false;
    }

    public void OnClickGoToHome()
    {
        // running as a Client
        if (NetworkClient.isConnected && !NetworkServer.active)
        {
            NetworkManager.singleton.StopClient();
        }
        //running as a Host
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        SceneManager.LoadScene(0);
    }
}

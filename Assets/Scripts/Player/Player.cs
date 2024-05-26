using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{


    public PlayerMove PlayerMove
    {
        get
        {
            if (playerMove == null) playerMove = GetComponent<PlayerMove>();
            return playerMove;
        }
    }
    public PlayerHealth PlayerHealth
    {
        get
        {

            if (playerHealth == null) playerHealth = GetComponent<PlayerHealth>();
            return playerHealth;
        }
    }
    public static Player local;


    private PlayerMove playerMove;
    private PlayerHealth playerHealth;
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        local = this;

        if (GameObject.Find("SpawnPos2")?.transform.position == transform.position)
        {
            // rotate camera
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
            FindAnyObjectByType<InputManager>().invertDir = true;
        }
    }

}

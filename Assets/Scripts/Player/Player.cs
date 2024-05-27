using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Minion : NetworkBehaviour
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
    public static Minion local;

    public static readonly List<Minion> OnlinePlayers = new List<Minion>();


    private PlayerMove playerMove;
    private PlayerHealth playerHealth;

    private void Start()
    {
        if (NetworkServer.active)
            OnlinePlayers.Add(local);
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        local = this;
        if (GameObject.Find("SpawnPos2")?.transform.position == transform.position)
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
            FindAnyObjectByType<InputManager>().invertDir = true;
        }
    }
    private void OnDestroy()
    {
        if (local != null)
            OnlinePlayers.Remove(local);
    }
}

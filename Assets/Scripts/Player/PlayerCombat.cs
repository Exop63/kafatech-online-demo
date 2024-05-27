
using Mirror;
using UnityEngine;

public class PlayerCombat : CombatSystem
{
    public Bullet bullet;
    public Minion Player
    {
        get
        {
            if (player == null) player = GetComponent<Minion>();
            return player;
        }
    }
    private Minion player;

    public override void TakeDamage(float damage)
    {
        player.PlayerHealth.TakeDamage(damage);
    }
    public override bool CanCombat()
    {
        return Player.PlayerMove.IsMoving;
    }
    [ServerCallback]
    protected override void Hit(Transform target)
    {
        var bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletObject.Setup(target.position, gameObject);
        NetworkServer.Spawn(bulletObject.gameObject);
    }
}
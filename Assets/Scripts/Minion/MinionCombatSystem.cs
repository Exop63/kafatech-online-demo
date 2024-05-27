
using Mirror;
using UnityEngine;

public class MinionCombatSystem : CombatSystem
{
    public Bullet bullet;
    public Minion Minion
    {
        get
        {
            if (minion == null) minion = GetComponent<Minion>();
            return minion;
        }
    }
    private Minion minion;
    [ServerCallback]
    protected override void Hit(Transform target)
    {
        var bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletObject.Setup(target.position, gameObject);
        NetworkServer.Spawn(bulletObject.gameObject);
    }
    public override void TakeDamage(float damage)
    {
        Minion.MinionHealth.TakeDamage(damage);
    }
    public override bool CanCombat()
    {
        return MinionManager.CanIntreact;
    }
}

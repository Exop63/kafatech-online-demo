using System;
using Mirror;
using UnityEngine;

public class CombatSystem : NetworkBehaviour
{

    public float hitRange = 5;
    public float shotTime = 1f;
    private double coolDown = 0;


    private Health health;
    public Health Health
    {
        get
        {
            if (health == null) health = GetComponent<Health>();
            return health;
        }
    }

    [ServerCallback]
    private void Update()
    {
        if (!CanCombat() || !isServer) return;
        HitControl();

    }
    [ServerCallback]
    private void HitControl()
    {

        if (coolDown > NetworkTime.time || Health.IsDeath) return;
        var targets = Physics2D.OverlapCircleAll(transform.position, hitRange);
        // ilk olarak bizi bulacaktır.
        if (targets == null || targets.Length < 2) return;
        for (int i = 0; i < targets.Length; i++)
        {
            var target = targets[i];
            if (target.gameObject != gameObject &&
                target.TryGetComponent<CombatSystem>(out var enemy) &&
                enemy.TryGetComponent<Health>(out var health) &&
                !health.IsDeath)
            {
                Hit(target.transform);
            }
        }
        coolDown = NetworkTime.time + shotTime;
    }

    protected virtual void Hit(Transform transform) { }

    public virtual void TakeDamage(float damage) { }
    public virtual bool CanCombat() { return true; }
}

using System;
using Mirror;
using UnityEngine;

public class CombatSystem : NetworkBehaviour
{

    public float hitRange = 5;
    private double coolDown = 0;


    [ServerCallback]
    private void Update()
    {
        if (IsMoving() || !isServer) return;
        HitControl();

    }
    [ServerCallback]
    private void HitControl()
    {

        if (coolDown > NetworkTime.time) return;


        var targets = Physics2D.OverlapCircleAll(transform.position, hitRange);
        // ilk olarak bizi bulacaktır.
        if (targets == null || targets.Length < 2) return;
        for (int i = 0; i < targets.Length; i++)
        {
            var target = targets[i];
            if (target.gameObject != gameObject && target.TryGetComponent<CombatSystem>(out var enemy))
            {
                Hit(target.transform);
            }
        }

        coolDown = NetworkTime.time + 1;

    }

    protected virtual void Hit(Transform transform)
    {
        throw new NotImplementedException();
    }

    public virtual void TakeDamage(float damage)
    {

    }
    public virtual bool IsMoving()
    {
        return true;
    }
}

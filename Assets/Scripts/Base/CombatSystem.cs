using Mirror;
using UnityEngine;

public class CombatSystem : NetworkBehaviour
{

    double coolDown = 0;


    [ServerCallback]
    private void Update()
    {
        if (IsMoving()) return;

        // hit
        if (coolDown < NetworkTime.time)
        {
            coolDown = NetworkTime.time + 1;

            var overlaps = Physics2D.OverlapCircleAll(transform.position, 2);
            Debug.Log("Overlaps is null " + overlaps == null);
            if (overlaps == null) return;
            Debug.Log("overlaps.Length " + overlaps.Length);

            for (int i = 0; i < overlaps.Length; i++)
            {
                Debug.Log("overlaps[i] " + overlaps[i]);

                if (overlaps[i].TryGetComponent<CombatSystem>(out var enemy) && enemy != this)
                {
                    enemy.TakeDamage(10);
                }
            }

        }

    }
    public virtual void TakeDamage(float damage)
    {

    }
    public virtual bool IsMoving()
    {
        return true;
    }
}

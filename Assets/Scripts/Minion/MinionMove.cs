using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MinionMove : NetworkBehaviour
{
    public float speed = 2;
    [SerializeField] Player target;
    [SerializeField] private Health health;
    public Health Health
    {
        get
        {
            if (health == null) health = GetComponent<Health>();
            return health;
        }
    }
    private Vector2 bounds = Vector2.one;

    private void Awake()
    {
        var characterBounds = GetComponentInChildren<SpriteRenderer>().bounds.size;
        bounds = Utils.GetScreenBounds() - (Vector2)characterBounds * .5f;
    }
    [ServerCallback]
    private void Update()
    {
        if (!HasATarget())
            FindTarget();
        else
            Move();
    }

    private bool HasATarget()
    {
        return !(target == null || target.PlayerHealth.IsDeath);
    }

    private void Move()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < .5f) return;
        var direction = (Vector2)(target.transform.position - transform.position);
        transform.position = Vector2.Lerp(transform.position, Utils.ScreenClamp((Vector2)transform.position + direction.normalized, bounds), Time.deltaTime * speed);
    }

    private void FindTarget()
    {
        Player target = default;
        var distance = float.PositiveInfinity;
        for (int i = 0; i < Player.OnlinePlayers.Count; i++)
        {
            var player = Player.OnlinePlayers[i];
            if (player == null) continue;
            var tmpDistance = Vector3.Distance(player.transform.position, transform.position);
            if (tmpDistance < distance && tmpDistance < 2)
            {
                target = player;
            }
        }

        if (target != default) this.target = target;

    }
}

using Mirror;
using UnityEngine;

public class Bullet : NetworkBehaviour
{

    public float speed = 2;
    private Vector3 target = Vector3.zero;
    private GameObject owner;
    public void Setup(Vector3 target, GameObject owner)
    {
        this.target = target;
        this.owner = owner;
    }
    [ServerCallback]
    private void Update()
    {
        var distance = Vector3.Distance(target, transform.position);
        if (distance < .1f)
        {
            NetworkServer.Destroy(gameObject);
            return;
        }

        var dir = target - transform.position;
        dir.Normalize();
        transform.position = transform.position + dir * Time.deltaTime * speed;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.gameObject != owner &&
            other.TryGetComponent<CombatSystem>(out var enemy) &&
            enemy.TryGetComponent<Health>(out var health) &&
            !health.IsDeath)
        {
            enemy.TakeDamage(15);
            enabled = false;
            NetworkServer.Destroy(gameObject);

        }

    }


}
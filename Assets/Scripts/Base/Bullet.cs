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
            var targetObject = Physics2D.OverlapCircle(transform.position, 1);
            if (targetObject != null && targetObject.TryGetComponent<CombatSystem>(out var enemy) && enemy.gameObject != owner)
            {
                enemy.TakeDamage(10);
            }
            NetworkServer.Destroy(gameObject);
            return;
        }

        var dir = target - transform.position;
        dir.Normalize();
        transform.position = transform.position + dir * Time.deltaTime * speed;


    }



}
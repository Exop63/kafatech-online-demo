
using UnityEngine;

public class PlayerCombat : CombatSystem
{
    public Player Player
    {
        get
        {
            if (player == null) player = GetComponent<Player>();
            return player;
        }
    }
    private Player player;

    public override void TakeDamage(float damage)
    {
        player.PlayerHealth.TakeDamage(damage);
    }
    public override bool IsMoving()
    {

        Debug.Log("Is moving " + Player.PlayerMove.IsMoving);
        return Player.PlayerMove.IsMoving;
    }

}
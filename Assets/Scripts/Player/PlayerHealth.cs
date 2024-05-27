using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public void TakeDamage(float damage)
    {
        current = Math.Max(0, current -= damage);
    }

}

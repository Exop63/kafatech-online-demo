using System;
using System.Diagnostics;
using UnityEngine.UI;

public class PlayerHealth : Health
{

    public Slider slider;

    public void TakeDamage(float damage)
    {
        current = Math.Max(0, current -= damage);
    }

    void Update()
    {
        if (slider != null)
            slider.value = current / max;
    }
}

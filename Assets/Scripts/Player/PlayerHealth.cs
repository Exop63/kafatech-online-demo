using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{

    public Slider slider;

    void Update()
    {
        if (slider != null)
            slider.value = current / max;
    }
}

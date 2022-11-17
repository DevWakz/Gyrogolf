using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Slider slider;
 
    public void SetForce(int force)
    {
        slider.value = force;

    }
}

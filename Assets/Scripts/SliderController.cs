using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    public Text forceText;
    public float addedForce;

     public void OnSliderChanged(float force)
     {
        forceText.text = force.ToString();
        addedForce = force;
        
     }
}

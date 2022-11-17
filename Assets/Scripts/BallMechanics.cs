using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BallMechanics : MonoBehaviour
{

    public SliderController slider;

    public Rigidbody rb;
    internal int _intHealthPoints;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _intHealthPoints = 3;
    }


}


    


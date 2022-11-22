using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotManager : MonoBehaviour
{
    public float addedForce;
    public SliderController slider;
    public BallMechanics ballRB;
    public GameObject _goShotUI;
    public GameObject _goHUD;
    

    public void ShotClicked()
    {      
            ballRB.rb.AddForce(Vector3.right * slider.addedForce, ForceMode.Impulse);
            Invoke("ShotOver", .1f);
    }

  
    public void ShotOver()
    {
        print("entro");
        _goShotUI.SetActive(false);
        _goHUD.SetActive(true);
        slider.addedForce = 0;

    }
}

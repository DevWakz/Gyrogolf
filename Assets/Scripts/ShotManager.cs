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
    public bool _isShooting;


    private void Update()
    {
        ShotClicked();
    
    }

    public void ShotClicked()
    {
        if(_isShooting == true)
        { 
            ballRB.rb.AddForce(Vector3.right * slider.addedForce);
            Invoke("ShotOver", .3f);

        }
    }

    public void IsShooting()
    {
        _isShooting = !_isShooting;
    }

    public void ShotOver()
    {
        _goShotUI.SetActive(false);
        ballRB.rb.AddForce(Vector3.right * 0);
        IsShooting();
    }
}

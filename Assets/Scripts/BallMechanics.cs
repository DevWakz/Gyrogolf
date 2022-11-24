using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BallMechanics : MonoBehaviour
{

    public SliderController slider;
    public Rigidbody rb;
    public int boostCounter;
    public int jumpCounter;
    public GameObject boostButton;
    public GameObject jumpButton;
    public GameReferee gameReferee;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boost")
        { 
            boostCounter++;
            boostButton.SetActive(true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Jump")
        {
            jumpCounter++;
            jumpButton.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "DeathCollider")
        {
    
            gameReferee._defGameState = ActualGameState.DEFEAT;
            gameReferee._goDefeatScreen.SetActive(true);

        }
        else if (other.gameObject.tag == "WinCollider")
        {

            gameReferee._defGameState = ActualGameState.VICTORY;
            gameReferee._goVictoryScreen.SetActive(true);

        }
    }

    public void BoostActivated()
    {
        if (boostCounter >= 1)
        {
            boostCounter--;
            rb.AddForce(Vector3.right * 1000, ForceMode.Impulse);
            if (boostCounter == 0)
                boostButton.SetActive(false);
        
        }
    }
    
    public void JumpActivated()
    {
        if (jumpCounter >= 1)
        {
            jumpCounter--;
            rb.AddForce(Vector3.up * 1000, ForceMode.Impulse);
            if (jumpCounter == 0)
                jumpButton.SetActive(false);
        }
    }
}


    


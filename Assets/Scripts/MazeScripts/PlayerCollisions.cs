using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mate.Clase.Maze;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject movementManager;
    public MovementManager movementMethods;
    public Action OnScore;
    GameObject currentPlayer;

    void Start()
    {
        movementMethods = GameObject.FindObjectOfType<MovementManager>();
        currentPlayer = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Restarter")
        {
            Destroy(other.gameObject);

            movementMethods.RestarterDestroyed();
            OnScore.Invoke();
            FindObjectOfType<MazeGenerator>().Restart_Maze();
        }

        if (other.gameObject.tag == "Invisibility")
        {
            Destroy(other.gameObject);
            movementMethods.InvisibilityDestroyed();
            currentPlayer.GetComponent<Collider>().isTrigger = true;
            Invoke("RestartCollider", 5f);
        }

        if (other.gameObject.tag == "IncreaseSpeed")
        {
            Destroy(other.gameObject);
            movementMethods.SpeedDestroyed();
            currentPlayer.GetComponent<Collider>();
            if (currentPlayer.name.Contains("1"))
                movementMethods.Enable_ExtraSpeed(0);
            else
                movementMethods.Enable_ExtraSpeed(1);
            Invoke("Restart_Velocity", 5f);
        }
    }

    void RestartCollider()
    {

        currentPlayer.GetComponent<Collider>().isTrigger = false;
    }

    void Restart_Velocity()
    {
        if (currentPlayer.name.Contains("1"))
            movementMethods.Disable_ExtraSpeed(0);
        else
            movementMethods.Disable_ExtraSpeed(1);
    }
}

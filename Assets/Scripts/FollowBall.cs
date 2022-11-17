using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject ball;
    private float x, y, z;
    Vector3 gravityPosition;


    void Start()
    {
        x = ball.transform.position.x;
        z = ball.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        x = ball.transform.position.x;
        z = ball.transform.position.z;
        GravityPosition();
    }

    void GravityPosition()
    {
        gravityPosition.x = x;
        gravityPosition.y = -161f;
        gravityPosition.z = z;
    }
}

    

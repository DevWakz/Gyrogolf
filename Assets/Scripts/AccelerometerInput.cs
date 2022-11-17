using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{
    private bool isFlat = true;
    private Rigidbody rb;

    public int Thrust = 5;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rb.AddForce(tilt);

        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);

        if (Input.touchCount > 0)
        {

            rb.AddForce(transform.up * Thrust);

        }
    }


}

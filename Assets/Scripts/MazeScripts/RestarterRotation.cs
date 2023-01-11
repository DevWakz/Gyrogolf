using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestarterRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(.5f, 1 * Time.deltaTime, .6f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    const float G = 667.4f;

    public Rigidbody rb;

    private void FixedUpdate()
    {
        GravityAttractor[] attractors = FindObjectsOfType<GravityAttractor>();
        foreach (GravityAttractor attractor in attractors)
        {
            if(attractor != this)
                Attract(attractor);

        }
    }

    void Attract(GravityAttractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.sqrMagnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance;
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}

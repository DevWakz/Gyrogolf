using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroInput : MonoBehaviour
{
    Gyroscope m_Gyro;
    Vector3 rot;
    public float maxXRot, minXRot;
    public float maxZRot, minZRot;
    private Transform localTrans;

    void Start()
    {
        rot = Vector3.zero;
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        localTrans = GetComponent<Transform>();
  
    }

    protected void Update()
    {
        rot.x = -Input.gyro.rotationRateUnbiased.y;
        rot.z = -Input.gyro.rotationRateUnbiased.x;
        transform.Rotate(rot);
        LimitRot();
    }

    private void LimitRot()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, minXRot, maxXRot);

        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);

        localTrans.rotation = Quaternion.Euler(playerEulerAngles);

    }





}

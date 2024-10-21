using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAim : MonoBehaviour
{
    // Start is called before the first frame update
    static float lastActive = 0 ;
    OVRCameraRig overCameraRig;
    
    void Start()
    {
        overCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
        lastActive = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-lastActive >5){
            var cameraPosition = overCameraRig.centerEyeAnchor.position;
            var ball = GameObject.FindGameObjectWithTag("ball");
            ball.GetComponent<Rigidbody>().AddForce((Quaternion.Euler(0, 0, 0)*(cameraPosition-ball.transform.position)).normalized*1000);
            lastActive = Time.time;
        }
    }
}

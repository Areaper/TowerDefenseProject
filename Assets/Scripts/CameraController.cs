using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float s = 40f;
    public float mouseSpeed = 600f;
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(new Vector3(h * s, mouseWheel * mouseSpeed, v * s) * Time.deltaTime, Space.World);
	}
}

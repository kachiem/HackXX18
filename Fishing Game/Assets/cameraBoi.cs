using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBoi : MonoBehaviour {
    public float speedH = 12.0f;
    public float speedV = 12.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject prefab;
    private GameObject go;

	// Use this for initialization
	void Start () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


	}
}

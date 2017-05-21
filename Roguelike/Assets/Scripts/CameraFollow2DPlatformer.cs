﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour {

    public Transform target; //what the camera is following
    public float smoothing; //dapening effect

    Vector3 offset;
    Camera playerCamera;
    float lowY;


	// Use this for initialization
	void Start () {

        playerCamera = GetComponent<Camera>();
        offset = transform.position - target.position;
        lowY = transform.position.y;
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        playerCamera.orthographicSize = (Screen.height / 100f) / 1.5f;

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }	
	}
}

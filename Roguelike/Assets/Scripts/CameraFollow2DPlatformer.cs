using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour {

	public Transform target; //what the camera is following
	public float smoothing; //dapening effect

	Vector3 offset;
	Camera playerCamera;
	float lowY;

	float shake = 0;
	float shakeAmount = 0.6f;
	float decreaseFactor = 1;

	public float ShakeMe
	{
		set { shake = value; }
	}


	// Use this for initialization
	void Start () {

		playerCamera = GetComponent<Camera>();
		offset = transform.position - target.position;
		lowY = transform.position.y;
		
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.V))
		{
			ShakeMe = 1;
		}

		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		if (transform.position.y < lowY)
		{
			transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
		}

		if (shake > 0)
		{
			playerCamera.transform.position += Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;

		}
		else
		{
			shake = 0;
		}

	}
}

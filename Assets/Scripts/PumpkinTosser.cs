using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinTosser : MonoBehaviour {
	public Rigidbody pumpkin;
	public float initialSpeed = 2000f;
	private float moveSpeed = 5f;
	// Update is called once per frame
	void Update ()
	{
		//allows user to move the camera with WASD keys
		float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate(deltaX, deltaY, 0);

		if(Input.GetButtonUp("Fire1"))
		{
			Rigidbody pumpkinInstance = Instantiate(pumpkin, transform.position, transform.rotation) as Rigidbody;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			pumpkinInstance.AddForce(fwd*initialSpeed);
		}
	}
}

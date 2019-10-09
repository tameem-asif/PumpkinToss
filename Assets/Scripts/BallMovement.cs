using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	float camMoveSpeed = 5f;
	float initSpeed1 = 400f;
	float initSpeed2 = 800f;
	float initSpeed3 = 1600f;
	float initSpeed4 = 2200f;
	float initSpeed5 = 3500f;

	public GameObject ball;
	public Rigidbody rb;
	private Vector3 offset;

	public static float hitsLeft = 12f;
	public float ballsLeft;

	bool isGameOver = false;

	void Start()
	{
		rb = ball.GetComponent<Rigidbody>();
		offset = transform.position - ball.transform.position;
		ballsLeft = GameObject.FindGameObjectsWithTag("ballToKill").Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//setGameOverFlagIfAllBlocksAreDown();

		//allows user to move the camera with WASD keys
		float deltaX = Input.GetAxis("Mouse X") * camMoveSpeed;
		//float deltaY = Input.GetAxis("Mouse Y") * Time.deltaTime * camMoveSpeed;
		transform.Rotate(0, deltaX, 0);

		ballsLeft = GameObject.FindGameObjectsWithTag("ballToKill").Length;

		/*if(!isGameOver && Input.GetButtonUp("Fire1"))
		{
			Rigidbody pumpkinInstance = Instantiate(pumpkin, transform.position, transform.rotation) as Rigidbody;
			pumpkinCount++;

			/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit))
			{
				pumpkinInstance.transform.LookAt(hit.point);
				pumpkinInstance.velocity = (pumpkinInstance.transform.forward) * initialSpeed;
			}*/
			/*Vector3 fwd = transform.TransformDirection(Vector3.forward);
			pumpkinInstance.AddForce(fwd*initialSpeed);
		}*/

		if(Input.GetKeyDown("1"))
		{
			Debug.Log("I am trying to move forward");
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			rb.AddForce(fwd*initSpeed1);
			hitsLeft--;
		}
		if(Input.GetKeyDown("2"))
		{
			Debug.Log("I am trying to move forward");
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			rb.AddForce(fwd*initSpeed2);
			hitsLeft--;
		}
		if(Input.GetKeyDown("3"))
		{
			Debug.Log("I am trying to move forward");
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			rb.AddForce(fwd*initSpeed3);
			hitsLeft--;
		}
		if(Input.GetKeyDown("4"))
		{
			Debug.Log("I am trying to move forward");
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			rb.AddForce(fwd*initSpeed4);
			hitsLeft--;
		}
		if(Input.GetKeyDown("5"))
		{
			Debug.Log("I am trying to move forward");
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			rb.AddForce(fwd*initSpeed5);
			hitsLeft--;
		}

	}

	void OnGUI ()
	{
		GUIStyle gs = new GUIStyle();
		gs.richText = true;
		gs.wordWrap = true;

		if(isGameOver)
		{
			Rect rectGameOver = new Rect(10, 10, 400, 200);
			GUI.Label(rectGameOver, "<size=50>Game Over!</size?", gs);
		}
		else
		{
			Rect rect1 = new Rect(10, 10, 350, 50);
			GUI.Label(rect1, "<size=20>Hits left: "+ hitsLeft + "</size>", gs);
			Rect rect2 = new Rect(10, 70, 350, 40);
			GUI.Label(rect2, "<size=20>Balls left: " + ballsLeft + "</size>", gs);
		}
	}

	void LateUpdate()
	{
		transform.position = ball.transform.position + offset;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PumpkinTosser : MonoBehaviour {
	public Rigidbody pumpkin;
	public float initialSpeed = 1500f;

	private float moveSpeed = 5f;

	private static int pumpkinCount = 0;
	private static bool isGameOver = false;

	public Texture crosshairTexture; //make sure this texture's dimension is a power of two (e.g., 128x128)  

	/*void Start ()
	{
		crosshairTexture = Resources.Load("crosshair") as Texture;
	}*/
	void Update ()
	{
		//setGameOverFlagIfAllBlocksAreDown();

		//allows user to move the camera with WASD keys
		float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate(deltaX, deltaY, 0);

		if(!isGameOver && Input.GetButtonUp("Fire1"))
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
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			pumpkinInstance.AddForce(fwd*initialSpeed);
		}
	}
	void OnGUI()
	{
		GUIStyle gs = new GUIStyle();
		gs.richText = true;
		gs.wordWrap = true;

		if(isGameOver)
		{
			Rect rectGameOver = new Rect(10, 10, 400, 200);
			GUI.Label(rectGameOver, "<size=50>Game Over! It took you " + pumpkinCount + " pumpkins</size?", gs);
		}
		else 
		{
			Rect rect1 = new Rect(10, 10, 350, 50);
			GUI.Label(rect1, "<size=20>Aim and knowck down all the red blocks with as few pumpkins as possible</size>", gs);
			Rect rect2 = new Rect(10, 70, 350, 40);
			GUI.Label(rect2, "<size=20>" + pumpkinCount + " pumpkins fired so far</size>", gs);

			float x = Input.mousePosition.x - (crosshairTexture.width/2);       
			float y = Screen.height -(Input.mousePosition.y + (crosshairTexture.height/2));       
			Rect rectCrosshair = new Rect(x, y, crosshairTexture.width, crosshairTexture.height);       
			GUI.DrawTexture(rectCrosshair, crosshairTexture);
		}
	}

	private void setGameOverFlagIfAllBlocksAreDown()
	{
		const float thresholdForBlockBeingUp = 2.5f;
		int cntBlocksStillUp = 0;

		MeshFilter[] meshFilters = FindObjectsOfType(typeof(MeshFilter)) as MeshFilter[];
		for(int i = 0; i < meshFilters.Length; i++)
		{
			bool isBlock = (meshFilters[i].mesh.vertexCount == 24);
			if(isBlock)
			{
				if (meshFilters[i].transform.position.y > thresholdForBlockBeingUp)
				{
					cntBlocksStillUp++;
				}
			}
		}
		isGameOver = (cntBlocksStillUp == 0);
	}
}

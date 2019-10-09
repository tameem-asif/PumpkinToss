using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {


	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "hole1" || col.gameObject.name == "hole2" || col.gameObject.name == "hole3" || col.gameObject.name == "hole4")
		{
			BallMovement.hitsLeft++;
			Destroy(gameObject);
		}
	}
}

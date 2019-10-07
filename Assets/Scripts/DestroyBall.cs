using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Floor")
		Destroy(gameObject);
	}
}

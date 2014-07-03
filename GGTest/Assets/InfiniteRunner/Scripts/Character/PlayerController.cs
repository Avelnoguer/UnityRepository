using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;

	void Update() {

		Vector3 dir = Vector3.zero;
		dir.y = Input.acceleration.x;
		dir.z = 0f;
		dir.x = 0f;//Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		dir *= Time.deltaTime;
		transform.Translate(dir * speed);
	
	}
	
	
	
	
}

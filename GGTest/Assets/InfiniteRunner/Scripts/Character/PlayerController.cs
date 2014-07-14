using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float maxSize = 1.5f;
	public float minSize = 0.8f;
	public float resizingSpeed = 0.01f;

	public float maxUpperMovement = 0.4f;
	public float maxBottomMovement = -3f;



	void Update() {
		move ();
	}

	private void move(){

		Vector3 dir = Vector3.zero;
		
		float accel = Input.acceleration.x;
		dir.y = accel;
		Resize ();
		//ReSizeCharacter (accel);
		dir.z = 0f;
		dir.x = 0f;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();


		dir *= Time.deltaTime;

		transform.Translate(dir * speed);
		rigidbody2D.position = new Vector3 (0.0f,
		                                  Mathf.Clamp (transform.position.y,maxBottomMovement,maxUpperMovement),
		                                  0.0f);

	}



	/*private void ReSizeCharacter(float value){

		if (value > 0) {

			//doMaths(maxUpperMovement,minSize,true);		
		} 

		else {

			//doMaths(maxBottomMovement,maxSize,false);
		}

	}*/


	private void Resize(){

		float currentY = Mathf.Clamp(transform.position.y,maxBottomMovement,maxUpperMovement);
		float finalXYScale = Mathf.Abs((currentY * maxSize) / maxBottomMovement);
		finalXYScale = Mathf.Clamp (finalXYScale, minSize, maxSize);
		transform.localScale = new Vector3 (finalXYScale, finalXYScale, 1f);


	}

}

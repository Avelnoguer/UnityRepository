using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float maxSize = 1.5f;
	public float minSize = 0.8f;
	public float gradual = 0.01f;

	private Vector3 finalSize = new Vector3 ();

	void Start(){
	
		finalSize = transform.localScale;
	
	}

	void Update() {

		Vector3 dir = Vector3.zero;

		float accel = Input.acceleration.x;
		dir.y = accel;
		ReSizeCharacter (accel);
		dir.z = 0f;
		dir.x = 0f;//Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		dir *= Time.deltaTime;
		transform.Translate(dir * speed);
	
	}

	private void ReSizeCharacter(float value){

		Vector3 currentScale = transform.localScale;

		if (value > 0) {

			if(finalSize.x >= minSize && finalSize.y >= minSize){
				finalSize.x -= gradual;
				finalSize.y -= gradual;
				finalSize.z = 1;
			}
				
		} 

		else {

			if(finalSize.x <= maxSize && finalSize.y <= maxSize){

				finalSize.x += gradual;
				finalSize.y += gradual;
				finalSize.z = 1;
			}

		}

		transform.localScale = Vector3.Lerp(transform.localScale);

		transform.localScale = finalSize;
	}
	


}

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float speed = 5;
	

	void Update () {
	
		transform.Rotate(new Vector3(0f,0f, Time.deltaTime * speed));

	}
}

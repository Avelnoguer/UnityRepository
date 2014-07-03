using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float speed = 1000f;
	// Update is called once per frame
	void Update () {
	
		this.transform.Rotate (new Vector3 (0, 0, -(Time.deltaTime * speed)));

	}
}

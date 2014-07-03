using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public float speed = 5f;


	void Update () {
		doScroll ();
	}

	private void doScroll(){
		renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	}

}

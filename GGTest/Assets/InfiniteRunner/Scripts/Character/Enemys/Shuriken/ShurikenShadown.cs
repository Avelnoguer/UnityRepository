using UnityEngine;
using System.Collections;

public class ShurikenShadown : MonoBehaviour {

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
		//offset = this.gameObject.transform.parent.FindChild ("ShurikenSprite").transform.position;
	}
	
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("MainCharacter")) {

				GUI_Painter.PrintGameOver ();
				RetryListener.GameOver ();
				Time.timeScale = 0;
		}
	}
	
	void LateUpdate(){
		//transform.position = this.gameObject.transform.parent.FindChild ("ShurikenSprite").transform.position + offset;
	}

}

using UnityEngine;
using System.Collections;

public class ShadownController : MonoBehaviour {

	private Quaternion OrgRotation;
	private Vector3 OrgPosition;
	private Vector3 OrgScale;


	public int score = 100;
	// Use this for initialization
	void Start () {
	
		OrgRotation = transform.rotation;
		OrgPosition = transform.parent.transform.position - transform.position;

	}



	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("MainCharacter")) {
			if (this.gameObject.transform.parent.tag.Equals ("Coin")) {
				Destroy (this.gameObject.transform.parent.gameObject);
				GUI_Painter.SetScore (score);
			} else {
				GUI_Painter.PrintGameOver ();
				RetryListener.GameOver ();
				Time.timeScale = 0;
			}
			
		}
	}

	void LateUpdate(){
		transform.rotation = OrgRotation;
		//transform.position = transform.parent.position - OrgPosition;

	}

}

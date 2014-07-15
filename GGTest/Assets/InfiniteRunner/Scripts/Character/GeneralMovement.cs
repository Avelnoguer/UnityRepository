using UnityEngine;
using System.Collections;

public class GeneralMovement : MonoBehaviour {

	public float speed = 2f;
	public float lifeTime = 5f;
	public int score = 100;
	public float maxSize = 1f;
	public float minSize = 0.5f;

	public float collitionRange = 0.5f;

	private GameObject character;
	private SpriteRenderer sprite;

	private float maxUpperMovement = 0.4f;
	private float maxBottomMovement = -3f;

	private bool canHitThePlayer =  false;





	void Start(){
		character = GameObject.FindGameObjectWithTag ("MainCharacter");



		sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		Destroy (this.gameObject, lifeTime);


	}

	// Update is called once per frame
	void Update () {

	
		ChangeLayer ();
		transform.position += (Vector3.left * Time.deltaTime)* speed;
		Resize ();
	}


	private void Resize(){
		
		float currentY = Mathf.Clamp(transform.position.y,maxBottomMovement,maxUpperMovement);
		float finalXYScale = Mathf.Abs((currentY * maxSize) / maxBottomMovement);
		finalXYScale = Mathf.Clamp (finalXYScale, minSize, maxSize);
		transform.localScale = new Vector3 (finalXYScale, finalXYScale, 1f);

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (canHitThePlayer) {
						if (other.gameObject.tag.Equals ("MainCharacter")) {
								if (this.gameObject.tag.Equals ("Coin")) {
										PlayEffect ();
										Destroy (this.gameObject);
										GUI_Painter.SetScore (score);
								} else {
										GUI_Painter.PrintGameOver ();
										RetryListener.GameOver ();
										Time.timeScale = 0;
								}
		
						}
				}
	}

	private void ChangeLayer(){


		if (transform.position.y > character.transform.position.y) {

			sprite.sortingOrder = -1;
		} 
		else {
			sprite.sortingOrder = 1;

		}
	
	}

	/*private void SetCollitionRange(){

		Debug.Log("Can:" + canHitThePlayer);
		/*Debug.Log ("character.transform.position.y = " + character.transform.position.y);
		Debug.Log ("transform.position.y + collitionRange" + (transform.position.y + collitionRange));
		Debug.Log ("transform.position.y - collitionRange" + (transform.position.y - collitionRange));

		if ((character.transform.position.y <= transform.position.y + collitionRange) || (character.transform.position.y >= transform.position.y - collitionRange)) {

			canHitThePlayer = true;
		
		} else {
			canHitThePlayer = false;
		}
	
	}*/

	private void PlayEffect(){
		this.audio.Play ();
	}
}

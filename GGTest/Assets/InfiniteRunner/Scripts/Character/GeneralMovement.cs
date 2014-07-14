using UnityEngine;
using System.Collections;

public class GeneralMovement : MonoBehaviour {

	public float speed = 2f;
	public float lifeTime = 5f;
	public int score = 100;
	public float maxSize = 1f;
	public float minSize = 0.5f;


	private float maxUpperMovement = 0.4f;
	private float maxBottomMovement = -3f;

	void Start(){

		Destroy (this.gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update () {
		//transform.position =  -((transform.forward *Time.deltaTime));
	
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
		if (other.gameObject.tag.Equals ("MainCharacter")) {
			if(this.gameObject.tag.Equals("Coin")){
				playEffect();
				Destroy(this.gameObject);
				GUI_Painter.SetScore(score);
			}else{
				GUI_Painter.PrintGameOver();
				RetryListener.GameOver();
				Time.timeScale = 0;
			}
		
		}
	}

	private void playEffect(){
		this.audio.Play ();
	}
}

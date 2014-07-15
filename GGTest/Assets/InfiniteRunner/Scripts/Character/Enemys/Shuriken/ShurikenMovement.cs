using UnityEngine;
using System.Collections;

public class ShurikenMovement : MonoBehaviour {

	public float speed = 2f;
	public float lifeTime = 5f;
	public float maxSize = 1f;
	public float minSize = 0.5f;
	

	private GameObject character;
	private SpriteRenderer [] sprite;
	
	public float maxUpperMovement = 0.4f;
	public float maxBottomMovement = -3f;
	
	
	void Start(){
		character = GameObject.FindGameObjectWithTag ("Player");
		sprite = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
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
	
	
	
	private void ChangeLayer(){
		
		
		if (transform.position.y > character.transform.position.y) {

			foreach (SpriteRenderer sr in sprite) {
				sr.sortingOrder = -1;
			}

		} 
		else {
			foreach (SpriteRenderer sr in sprite) {
				sr.sortingOrder = 1;
			}
		}
		
	}

}

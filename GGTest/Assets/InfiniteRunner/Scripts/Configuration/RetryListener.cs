using UnityEngine;
using System.Collections;

public class RetryListener : MonoBehaviour {

	private static bool gameOver;


	void Update () {
	

			if (Input.touchCount == 2) {
				if (gameOver) {
					Application.LoadLevel(Application.loadedLevel);
					resetStatus();
				}
			}

	}

	public static void GameOver(){
		gameOver = true;
	}

	private void resetStatus(){
		GUI_Painter.ResetGui ();
		gameOver = false;
		Time.timeScale = 1;
		
	}

}

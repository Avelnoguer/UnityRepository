using UnityEngine;
using System.Collections;

public class GUI_Painter : MonoBehaviour {

	public int fontSize = 50;


	private static int currentScore = 0;
	private static bool gameOver = false;
	private static int survivingTime = 0;
	private static int nextUpdate = 1;

	private static int bestScore = 0;

	GUIStyle gs = new GUIStyle();
	GUIStyle gsBestScore = new GUIStyle();
	void Start(){
		Font myFont = (Font)Resources.Load("Fonts/Black-coffee-shadow", typeof(Font));
		gs.font = myFont;
		gs.normal.textColor = Color.blue;
		gs.fontSize = fontSize;
		gs.wordWrap = true;

		gsBestScore.font = myFont;
		gsBestScore.normal.textColor = Color.magenta;
		gsBestScore.fontSize = 20;

	}

	void Update(){
	
		if (Time.time > nextUpdate) {
			survivingTime += 1;
			nextUpdate = Mathf.RoundToInt(Time.time) + 1;
		}

	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 20), "Score: " + currentScore,gs);
		GUI.Label(new Rect((Screen.width)-100, 10, 100, 20), "Surviving Time: " + survivingTime,gs);
		if (gameOver) 
			GUI.Label(new Rect((Screen.width/2)-50, (Screen.height/2), 200, 100), "Game Over, Tab with two finger to play again!!",gs);
		if(bestScore > 0 )
			GUI.Label(new Rect(10, 50, 200, 20), "Best Score: " + bestScore,gsBestScore);

	}

	public static void SetScore(int score){

		currentScore += score;
	}

	public static void PrintGameOver(){
		gameOver = true;
	}

	public static void ResetGui(){
		int realScore = currentScore + (survivingTime * 5);
		if (realScore > bestScore) {
			bestScore = realScore;
		}
		currentScore = 0;
		survivingTime = 0;
		gameOver = false;
	}
}

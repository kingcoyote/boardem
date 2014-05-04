using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	public GameScript MainGame;
	private GUIText _score;
	private GUIText _timer;
	private GUIText _health;
	private GUIText _gameover;

	// Use this for initialization
	void Start () {
		foreach (var text in GetComponentsInChildren<GUIText>()) {
			switch (text.gameObject.name) {
				case "score":
					_score = text;
					break;
				case "timer":
					_timer = text;
					break;
				case "health":
					_health = text;
					break;
				case "gameover":
					_gameover = text;
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		_score.text = "Score: " + MainGame.Score;
		_timer.text = "Time: " + MainGame.Timer ().ToString ("00.00") + "s";
		_health.text = "Health: " + MainGame.Health;
		_gameover.text = MainGame.IsGameOver ? "Game Over!" : "";

		if (MainGame.Timer() < MainGame.TimeLimit * 0.2)       _timer.color = Color.red;
		else if (MainGame.Timer() < MainGame.TimeLimit * 0.5)  _timer.color = Color.yellow;
		else                                                   _timer.color = Color.white;

		if (MainGame.Health < 3)       _health.color = Color.red;
		else if (MainGame.Health < 6)  _health.color = Color.yellow;
	}
}

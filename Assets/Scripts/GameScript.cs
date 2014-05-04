using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

	public int Score;
	public int Health = 10;
	public float TimeLimit = 10;
	public bool IsGameOver = false;
	public Transform TokenPrefab;
	public List<GeyserScript> Geysers = new List<GeyserScript>(16);

	private float _timer;

	// Use this for initialization
	void Start () {
		foreach (var g in Geysers) {
			g.Disable ();
		}
		SpawnToken (transform);
		_timer = TimeLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (_timer < 0)	_timer = 0;
		if (Health < 0)	Health = 0;

		if (IsGameOver)	return;
		_timer -= Time.deltaTime;
		if (_timer <= 0) GameOver ();
	}

	private void GameOver() {
		IsGameOver = true;
		foreach (var g in Geysers) {
			g.Disable ();
		}


	}

	void OnGUI() {
		if (!IsGameOver) return;

		const int buttonWidth = 84;
		const int buttonHeight = 60;

		if (GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Restart!"
			)) {
			Application.LoadLevel ("game");
		}
	}

	public void PlayerHit(BulletScript shot) {

		var explosion = Instantiate (shot.Explosion) as Transform;
		explosion.position = shot.transform.position;
		Destroy (explosion.gameObject, 2);

		Health -= 1;
		if (Health <= 0) {
			GameOver ();
		}

		Destroy (shot.gameObject);
	}

	public void TokenPickup(TokenScript token) {
		Score += 1;
		SpawnToken (token.transform.parent);

		var s = Instantiate (token.Pickup) as Transform;
		s.position = token.transform.position;
		Destroy (s.gameObject, 1);
		Destroy (token.gameObject);

		foreach (var g in Geysers) {
			if (Random.Range (0, 100) < Score) {
				g.Enable ();
			} else { 
				g.Disable ();
			}
		}
		_timer = TimeLimit;
	}

	public float Timer() {
		return _timer;
	}

	private void SpawnToken(Transform parent) {
		var token = Instantiate (TokenPrefab) as Transform;
		token.parent = parent;
		token.transform.position = new Vector3 (Random.Range (-180, 180) / 100f, Random.Range (-150, 180) / 100f, 0);
	}
}

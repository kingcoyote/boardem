using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float Speed = 1.5f;
	private Vector2 _direction;
	public GameScript MainGame;
	
	// Use this for initialization
	void Update () {
		if (MainGame.IsGameOver == true) {
			_direction = new Vector2(0, 0);
			return;
		}
		var inputX = Input.GetAxis ("Horizontal");
		var inputY = Input.GetAxis ("Vertical");
		_direction = new Vector2 (inputX * Speed, inputY * Speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = _direction;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<TokenScript> () != null) {
			MainGame.TokenPickup (other.gameObject.GetComponent<TokenScript>());
		} else if (other.gameObject.GetComponent<BulletScript> () != null) {
			MainGame.PlayerHit (other.gameObject.GetComponent<BulletScript>());
		}
	}
}

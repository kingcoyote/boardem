using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public Vector2 Direction;
	public float Speed;
	public Transform Explosion;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(Direction.x * Speed, Direction.y * Speed);
	}
}

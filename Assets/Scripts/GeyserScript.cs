using UnityEngine;
using System.Collections;

public class GeyserScript : MonoBehaviour {

	public Transform Bullet;
	public int Firerate = 500;
	public Sprite EnabledSprite;
	public Sprite DisabledSprite;

	private int _cooldown;
	private bool _enabled = false;
	private SpriteRenderer _sprite;

	// Use this for initialization
	void Start () {
		_sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
	}

	public void Enable() {
		_enabled = true;
		_cooldown = Random.Range (0, Firerate);
		_sprite.sprite = EnabledSprite;
	}

	public void Disable() {
		_enabled = false;
		if (_sprite != null && _sprite.sprite != null) { 
			_sprite.sprite = DisabledSprite;
		}
	}

	// Update is called once per frame
	void Update () {
		if (_enabled == false || _cooldown > 0) {
			_cooldown -= (int)(Time.deltaTime * 1000);
			return;
		}

		_cooldown = Firerate;
		var b = Instantiate (Bullet) as Transform;
		b.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.1f);
		b.GetComponentInChildren<BulletScript> ().Direction = this.transform.up;
	}


}

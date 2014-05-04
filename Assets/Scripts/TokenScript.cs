using UnityEngine;
using System.Collections;

public class TokenScript : MonoBehaviour {

	public Transform Spawn;
	public Transform Pickup;

	// Use this for initialization
	void Start () {
		var s = Instantiate (Spawn) as Transform;
		s.position = transform.position;
		Destroy (s.gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDestroy() {

	}

}

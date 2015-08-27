using UnityEngine;
using System.Collections;

public class SimpleShotScript : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	new Transform transform;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		rb.velocity = transform.up * speed;
	}

	void PlayFireSound() {
		GetComponent<AudioSource>().Play();
	}
}

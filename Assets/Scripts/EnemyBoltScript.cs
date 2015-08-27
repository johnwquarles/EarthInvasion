using UnityEngine;
using System.Collections;

public class EnemyBoltScript : MonoBehaviour {
	
	public float speed;
	private Rigidbody rb;
	new Transform transform;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		rb.velocity = transform.up * (-1 * speed);
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.tag == "PlayerWeapon") {
			Destroy (trigger.gameObject);
			Destroy (gameObject);
		}
	}
}

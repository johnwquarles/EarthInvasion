using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienScript : MonoBehaviour {

	public float startingAnimationSpeed;
	public GameObject explosion;
	public GameObject weapon;
	public Transform weaponSpawn;	
	private Animator anim;
	private new Transform transform;
	private GameObject player;
	private GameObject levelManager;
	private GameObject shot;

	public void IncrementAnimSpeed(float factor) {
		anim.speed += factor;
	}

	void Start () {
		levelManager = GameObject.Find ("LevelManager");
		transform = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
		player = GameObject.Find ("Player");
		anim.speed = startingAnimationSpeed;
	}

	void Update() {
		if (transform.position.y < -7.5) {
			if (player.activeSelf == true) {
				player.SendMessage("playerDeath");
				levelManager.SendMessage("gameOver");
			}
		}
	}

	public void Fire() {
		shot = (GameObject)Instantiate(weapon, weaponSpawn.position, Quaternion.identity);
		levelManager.GetComponent<LevelManagerScript>().waveShots.Add (shot);
	}

	void OnTriggerEnter(Collider trigger)
	{
		if (trigger.tag != "Boundary" && trigger.tag != "EnemyWeapon" && trigger.tag != "ScreenEdge") {
			Destroy (trigger.gameObject);
			Destroy (gameObject);
			Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
		}
	}

	// Only called for Phys aliens. Scripts are now united; only difference is that the alien GameObject itself will have its box collider *not* as a trigger,
	// hence collisions with a player shot become a physical collision, not a trigger entrance.
	void OnCollisionEnter(Collision collision) {
		Destroy (collision.gameObject);
		Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
	}
	
}

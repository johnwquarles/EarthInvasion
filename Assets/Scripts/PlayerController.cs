using UnityEngine;
using System.Collections;
using System;
using Pixel3D;

public class PlayerController : MonoBehaviour {

	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax;
	}
	
	public float speed;
	public Boundary boundary;
	public float respawnTime;
	public float invincibleTime;
	public float blinkRate;
	
	public GameObject explosion;
	public GameObject weapon;
	public Transform weaponSpawn;
	public float fireRate;
	
	private float nextFire;
	private Rigidbody rb;
	private GameObject levelManager;
	new private Transform transform;
	private LevelManagerScript camScript;
	private Sprite3D pixelScript;
	private SpriteRenderer sprite;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		levelManager = GameObject.Find ("LevelManager");
		camScript = levelManager.GetComponent<LevelManagerScript> ();
		pixelScript = GetComponent<Sprite3D> ();
		sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject fire = (GameObject)Instantiate(weapon, weaponSpawn.position, Quaternion.identity);
			fire.SendMessage("PlayFireSound");
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.velocity = movement * speed;
		rb.position = new Vector3
		(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), -7.5f, -20f
		);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "EnemyWeapon") {
			Destroy (other.gameObject);
			playerDeath();
			if (levelManager.GetComponent<LevelManagerScript>().lives < 1) {
				levelManager.SendMessage("gameOver");
			}
			else {
				Invoke ("Respawn", respawnTime);
			}
		}
	}

	void playerDeath() {
		gameObject.SetActive(false);
		Instantiate(explosion, transform.position, Quaternion.identity);
		levelManager.SendMessage("loseLife");

		int[] firstPerCams = {3, 4, 5};
		if (Array.IndexOf(firstPerCams, camScript.currentCam) > -1) {
			camScript.camWas = camScript.currentCam;
			camScript.setCamera(6);
		}
	}

	void Respawn() {
		
		Vector3 basePos = new Vector3(0f, -7.5f, -20f);
		transform.position = basePos;
		gameObject.SetActive(true);
		GetComponent<BoxCollider> ().enabled = false;
		if (camScript.currentCam == 6) {
			camScript.setCamera(camScript.camWas);
		}
		Invoke ("ColliderOn", invincibleTime);
		StartCoroutine (Blink ());
	}

	void ColliderOn() {
		GetComponent<BoxCollider> ().enabled = true;
	}

	IEnumerator Blink() {
		float endTime = Time.time + invincibleTime;
		while (Time.time < endTime) {
			pixelScript.enabled = false;
			sprite.enabled = false;
			yield return new WaitForSeconds (blinkRate);
			pixelScript.enabled = true;
			sprite.enabled = true;
			yield return new WaitForSeconds (blinkRate);
		}

	}
}

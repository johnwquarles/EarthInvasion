using UnityEngine;
using System.Collections;

public class WaveShotDoubleScript : MonoBehaviour {
	
	public float speed;
	public float amplitude;
	public GameObject bulletObject;
	private GameObject bullet1;
	private GameObject bullet2;
	new Transform transform;
	private float timeFired;
	private float timeNow;
	
	void Start () {
		timeFired = Time.time;
		transform = GetComponent<Transform> ();
		bullet1 = (GameObject)Instantiate(bulletObject, transform.position, Quaternion.identity);
		bullet2 = (GameObject)Instantiate(bulletObject, transform.position, Quaternion.identity);
	}
	
	void FixedUpdate() {
		timeNow = Time.time;
		if (bullet1 != null) bullet1.GetComponent<Rigidbody> ().position += new Vector3(Mathf.Sin(((speed/2) * Mathf.PI)*(timeNow - timeFired)) * amplitude, Time.deltaTime * speed, 0);
		if (bullet2 != null) bullet2.GetComponent<Rigidbody> ().position += new Vector3(-Mathf.Sin(((speed/2) * Mathf.PI)*(timeNow - timeFired)) * amplitude, Time.deltaTime * speed, 0);
	}

	void PlayFireSound() {
		GetComponent<AudioSource>().Play();
	}
}

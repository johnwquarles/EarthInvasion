using UnityEngine;
using System.Collections;

public class MultiShotScript : MonoBehaviour {
	
	public float speed;
	public int numberOfBullets; //odd # please
	public GameObject bulletObject;
	public float bulletGap; //put in a fraction;
	private GameObject bullet;
	new Transform transform;

	void Start () {
		transform = GetComponent<Transform> ();

		for (int i = -(numberOfBullets/2); i < (numberOfBullets/2) + 1; i++) {
			bullet = (GameObject)Instantiate(bulletObject, transform.position, Quaternion.identity);
			bullet.GetComponent<Rigidbody> ().position += new Vector3((float)i * bulletGap, Mathf.Cos((float)i * bulletGap) - 2F, 0);
			bullet.GetComponent<Rigidbody> ().velocity = bullet.GetComponent<Transform> ().up * speed;

			//bullet.GetComponent<Rigidbody>().transform.Rotate (0, 0, startAtDegrees + (degreesPer * i));
			//bullet.GetComponent<Rigidbody>().velocity = transform.up * speed;
		}

//		bullet.GetComponent<Rigidbody>().transform.Rotate (0, 0, startAtDegrees + (degreesPer * i));
//		bullet.GetComponent<Rigidbody>().velocity = transform.up * speed;

		//rb.transform.Rotate (0, 0, 35);
	}

	void PlayFireSound() {
		GetComponent<AudioSource>().Play();
	}
}

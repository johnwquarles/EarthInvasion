using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerExit(Collider other)
	{
		// layer 9 is "Enemy"
		if (other.gameObject.layer == 9) {
			Instantiate (explosion, other.GetComponent<Transform> ().position, Quaternion.identity);
		}
		Destroy (other.gameObject);
	}
	
}

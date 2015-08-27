using UnityEngine;
using System.Collections;

public class rotateEarth : MonoBehaviour {

	private new Transform transform;
	public float rotationSpeed;

	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, Time.deltaTime * rotationSpeed, 0, Space.World);
	}
}

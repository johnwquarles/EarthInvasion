using UnityEngine;
using System.Collections;

public class AlienGroupScript : MonoBehaviour {

	// initial speed
	public float speed;
	// speed increase each time group hits the edge of the screen
	public float speedIncrement;
	// 1 is right, -1 is left.
	public int direction;
	public float stepDownIncrement;
	public float animationIncrement;

	private new Transform transform;

	// when the alien group hits the screen edge boundary (isn't technically accurate depending on the camera)
	public void hitEdge() {
		// change direction
		direction *= -1;
		// increment speed
		speed += speedIncrement;
		// move all aliens down by a factor of stepDownIncrement (using the group's transform)
		float newY = transform.position.y;
		newY -= stepDownIncrement;
		transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
		// and increase all child alien animation speeds by a factor of animationIncrement.
		// We access child gameObjects via the alien group's transform, which has within it all of the child alien's transforms
		// (which we get at with the "x in y" syntax for iteration, which I guess means that it's an array).
		foreach (Transform child in transform) {
			child.gameObject.GetComponent<AlienScript>().SendMessage("IncrementAnimSpeed", animationIncrement);
		}
	}

	void Start () {
		transform = GetComponent<Transform>();
		// aliens start out moving left
	}

	void FixedUpdate () {
		float newX = transform.position.x;
		newX += direction * speed * Time.deltaTime;
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}
}

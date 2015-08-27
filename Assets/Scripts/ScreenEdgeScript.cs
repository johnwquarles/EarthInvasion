using UnityEngine;
using System.Collections;

public class ScreenEdgeScript : MonoBehaviour {

	void OnTriggerEnter(Collider trigger) {
		trigger.transform.parent.SendMessage("hitEdge");
	}
}

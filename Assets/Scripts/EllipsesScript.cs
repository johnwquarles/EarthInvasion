using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EllipsesScript : MonoBehaviour {

	private Text text;
	[HideInInspector]
	public string originalText;

	public void start() {
		text = GetComponent<Text>();
		originalText = text.text;
		StartCoroutine (animate ());
	}

	public bool isGoing() {
		return GetComponent<EllipsesScript> ().enabled;
	}

	// Update is called once per frame
	IEnumerator animate () {
		while (isGoing()) {
			if (!isGoing()) break;
			text.text += ".";
			yield return new WaitForSeconds (1);
			if (!isGoing()) break;
			text.text += ".";
			yield return new WaitForSeconds (1);
			if (!isGoing()) break;
			text.text += ".";
			yield return new WaitForSeconds (1);
			if (!isGoing()) break;
			text.text = originalText;
			yield return new WaitForSeconds (1);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelManagerScript : MonoBehaviour {

	public Camera[] cameras;
	public GameObject[] music;
	public GameObject[] playerWeapons;
	public GameObject[] backgroundElements;
	public GameObject player;
	public float intFireRate;
	public float fasterFireRate;
	public float newWaveDelay;
	//public float smokeClearingDelay;
	public Text livesText;
	public Text restartText;
	public Text msgText;
	public int startLives;
	public int offerRestartTime;
	[HideInInspector]
	public int lives;
	[HideInInspector]
	public int currentCam;
	[HideInInspector]
	public int camWas;
	public List<GameObject> waveShots;

	private GameObject currentWave;
	private int waveCount;
	private bool isGameOver;


	// if music is set in start(), it won't ever change loop (bug with the loopMGR?)
	void Start () {
		Time.timeScale = 1f;
		waveShots = new List<GameObject> ();
		setLives (startLives);
		restartText.text = "";
		msgText.text = "";
		msgTextEllipses (false);
		setFireRate (intFireRate);
		waveCount = 0;
		setPlayerWeapon (0);
		setCamera (0);
		currentWave = (GameObject)Instantiate (Resources.Load ("Waves/WaveA"));

	}

	void Update ()
	{
		if (isGameOver)
		{
			if (Input.GetButton ("Fire1"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void waveFinished() {
		clearWaveShots ();
		waveCount += 1;
		msgText.text = "";
		msgText.color = Color.white;
		switch (waveCount) {
		case 1:
			StartCoroutine (startWave2());
			break;
		case 2:
			StartCoroutine (startWave3());
			break;
		case 3:
			StartCoroutine (startWave4());
			break;
		case 4:
			StartCoroutine (startWave5());
			break;
		case 5:
			StartCoroutine (startWave6());
			break;
		case 6:
			StartCoroutine (startWave7());
			break;
		case 7:
			StartCoroutine (startWave8());
			break;
		case 8:
			StartCoroutine (startWave9());
			break;
		case 9:
			StartCoroutine (startWave10());
			break;
		case 10:
			StartCoroutine (startWave11());
			break;
		case 11:
			StartCoroutine (startWave12());
			break;
		default:
			StartCoroutine(victory());
			break;
		}
	}

	IEnumerator startWave2() {
		setMusic (1);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveB"));
	}

	IEnumerator startWave3() {
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setBackgroundElement (1);
		setCamera (1);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveC"));
		msgText.text = "preparing rapid fire cannon";
		msgTextEllipses (true);
	}

	IEnumerator startWave4() {
		msgTextEllipses (false);
		setMusic (2);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setCamera (4);
		setFireRate (fasterFireRate);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveD"));
		msgText.text = "rapid fire cannon deployed!";
		msgText.color = Color.green;
	}

	IEnumerator startWave5() {
		setMusic (3);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveE"));
		msgText.text = "preparing triple-shot";
		msgTextEllipses (true);
	}

	IEnumerator startWave6() {
		msgTextEllipses (false);
		setMusic (4);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setCamera (1);
		setFireRate (intFireRate);
		setPlayerWeapon (1);
		yield return new WaitForSeconds (newWaveDelay);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveF"));
		msgText.text = "triple-shot deployed!";
		msgText.color = Color.green;
	}

	IEnumerator startWave7() {
		setMusic (5);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveG"));
		msgText.text = "preparing wave cannon";
		msgTextEllipses (true);
	}

	IEnumerator startWave8() {
		msgTextEllipses (false);
		setMusic (6);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setCamera (5);
		setPlayerWeapon (4);
		yield return new WaitForSeconds (newWaveDelay);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveH"));
		msgText.text = "wave cannon deployed!";
		msgText.color = Color.green;
	}

	// put very few enemies on this one; don't want the loop to play more than once
	// (poor loop, but should be in the track).
	IEnumerator startWave9() {
		msgTextEllipses (false);
		setMusic (7);
		setFireRate (fasterFireRate);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setBackgroundElement (0);
		setCamera (0);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveI"));
		msgText.text = "rapid-fire wave cannon deployed!";
		msgText.color = Color.green;
	}

	IEnumerator startWave10() {
		setMusic (8);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setBackgroundElement (1);
		setCamera (2);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveJ"));
		livesText.color = Color.black;
		msgText.text = "preparing spread shot";
		msgText.color = new Color(0f, 0.4f, 0f);
		msgTextEllipses (true);
	}
	
	IEnumerator startWave11() {
		msgTextEllipses (false);
		setMusic (9);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setFireRate (intFireRate);
		setPlayerWeapon (2);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveK"));
		livesText.color = Color.black;
		msgText.text = "spread-shot deployed!";
		msgText.color = new Color (0f, 0.4f, 0f);
	}

	IEnumerator startWave12() {
		setMusic (10);
		//yield return new WaitForSeconds (smokeClearingDelay);
		yield return new WaitForSeconds (newWaveDelay);
		setBackgroundElement (0);
		setCamera (0);
		setFireRate (fasterFireRate);
		currentWave = (GameObject)Instantiate(Resources.Load("Waves/WaveL"));
		livesText.color = Color.white;
		msgText.text = "rapid fire spread shot deployed!";
		msgText.color = Color.green;
	}

	IEnumerator victory() {
		setMusic (11);
		yield return new WaitForSeconds (3);
		restartText.text = "and thus\n" + "the earth\n\n";
		yield return new WaitForSeconds (3);
		restartText.text += "was saved\n\n";
		yield return new WaitForSeconds (3);
		restartText.text += "thank you\n" + "for\n" + "playing!";
	}
	
	public void setCamera(int i)
	{
		foreach (Camera camera in cameras) {
			camera.enabled = false;
		}
		cameras [i].enabled = true;
	
		currentCam = i;
	}

	private void setPlayerWeapon(int i) {
		player.GetComponent<PlayerController> ().weapon = playerWeapons [i];
	}

	private void setFireRate(float i) {
		player.GetComponent<PlayerController> ().fireRate = i;
	}

	private void setMusic(int i) {
		music[i].GetComponent<MusicArea>().activate();
	}

	private void setBackgroundElement(int i) {
		foreach (GameObject element in backgroundElements) {
			element.SetActive(false);
		}
		backgroundElements [i].SetActive (true);
	}

	private void setLives(int i) {
		lives = i;
		if (lives == 1) {
			livesText.text = "last cannon";
		} 
		else {
			livesText.text = lives + " cannons remain";
		}
	}

	private void loseLife() {
		setLives (lives - 1);
	}

	private void gameOver() {
		setMusic (11);
		Destroy (currentWave);
		livesText.text = "";
		msgText.text = "";
		Invoke ("offerRestart", offerRestartTime);
	}

	private void offerRestart() {
		restartText.text = "press fire button \n" +  "to retry";
		isGameOver = true;
	}

	private void msgTextEllipses(bool which) {
		if (which) {
			msgText.GetComponent<EllipsesScript> ().enabled = true;
			msgText.GetComponent<EllipsesScript> ().start();
		} else {
			msgText.GetComponent<EllipsesScript> ().enabled = false;
		}
	}

	private void clearWaveShots() {
		foreach (GameObject shot in waveShots) {
			Destroy(shot);
		}
	}
}

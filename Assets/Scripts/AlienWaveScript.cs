using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienWaveScript : MonoBehaviour {

	private GameObject levelManager;
	private List<GameObject> livingAliens = new List<GameObject>();
	private float firingTimer;
	private float initialAlienTotal;
	// minimum (base amount of) time after each alien shot to wait
	// ie, this will be the delay when only the last alien remains.
	public float fireDelay;
	// maximum additional delay; at 100% when all aliens are present, goes down to 0 when only one is left.
	public float proportionalDelay;
	
	void Start () {
		levelManager = GameObject.Find ("LevelManager");
		Debug.Log (levelManager);
		updateLivingAliensList ();
		initialAlienTotal = livingAliens.Count;
		// just in case there's a wave with one alien, so that we don't divide by 0 when calculating its firing rate.
		if (initialAlienTotal == 1)
			initialAlienTotal = 2;
		// so that the aliens don't fire immediately when a new wave is spawned
		firingTimer = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () {
		updateLivingAliensList ();
		if (livingAliens.Count != 0 && Time.time > firingTimer) randomAlienFires ();
		if (livingAliens.Count == 0) {
			levelManager.SendMessage("waveFinished");
			Destroy (gameObject);
		}
	}

	private void updateLivingAliensList() {
		// put all (individual) aliens into array
		livingAliens = new List<GameObject>();
		foreach (Transform alienRowTransform in transform) {
			foreach (Transform alienTransform in alienRowTransform) {
				livingAliens.Add(alienTransform.gameObject);
			}
		}
	}

	private void thisAlienFires(int i) {
		livingAliens [i].gameObject.SendMessage ("Fire");
	}

	private int randomAlienIndex() {
		int rInt = Random.Range (0, livingAliens.Count);
		return rInt;
	}

	// note that waves are gonna need to be bigger than one alien!
	private void randomAlienFires() {
		thisAlienFires (randomAlienIndex ());
		firingTimer = Time.time + fireDelay + (proportionalDelay * ( (livingAliens.Count - 1) / (initialAlienTotal - 1) ) );
	}
}

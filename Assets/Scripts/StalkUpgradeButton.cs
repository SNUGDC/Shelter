using UnityEngine;
using System.Collections;

public class StalkUpgradeButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.UpgradeStalk();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

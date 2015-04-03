using UnityEngine;
using System.Collections;

public class outerCoatingUpgradeButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.UpgradeOuterCoating();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

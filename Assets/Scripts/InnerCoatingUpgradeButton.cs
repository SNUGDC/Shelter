using UnityEngine;
using System.Collections;

public class InnerCoatingUpgradeButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.UpgradeInnerCoating();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

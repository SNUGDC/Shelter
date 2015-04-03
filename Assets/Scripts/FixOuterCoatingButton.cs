using UnityEngine;
using System.Collections;

public class FixOuterCoatingButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.FixOuterCoating();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

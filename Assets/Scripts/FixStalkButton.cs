using UnityEngine;
using System.Collections;

public class FixStalkButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.FixStalk();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

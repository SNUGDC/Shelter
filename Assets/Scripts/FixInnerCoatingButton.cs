using UnityEngine;
using System.Collections;

public class FixInnerCoatingButton : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.FixInnerCoating();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

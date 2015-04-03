using UnityEngine;
using System.Collections;

public class ExchangeNutrientToFood : MonoBehaviour {

	public ShelterStats ShelterStats;

	void OnMouseDown()
	{
		ShelterStats.ExchangeNutrientToFood();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

using UnityEngine;
using System.Collections;

public class Nutrient : MonoBehaviour {

	int nutrient;
	int level;

	public void SetNutrient(int newValue)
	{
		nutrient = newValue;
	}
	public void Upgrade()
	{
		level++;
	}

	public int GetNutrient()
	{
		return nutrient;
	}
	public int GetLevel()
	{
		return level;
	}

	// Use this for initialization
	void Start () {
		nutrient = 0;
		level = 1;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "영양분 : " + nutrient;

	}
}

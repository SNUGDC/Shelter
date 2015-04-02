using UnityEngine;
using System.Collections;

public class Nutrient : MonoBehaviour {

	const int nutrientOfBaseLevel = 3;

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

	public void GainNutrientAtEndTurn()
	{
		nutrient += CalculateGainNutrientEachTurn(level);
	}

	int CalculateGainNutrientEachTurn(int level)
	{
		return nutrientOfBaseLevel + level;
	}

	// Use this for initialization
	void Start () {
		nutrient = nutrientOfBaseLevel;
		level = 1;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "영양분 : " + nutrient;
	}
}

using UnityEngine;
using System.Collections;

public class ShelterStats : MonoBehaviour {

	public Nutrient Nutrient;

	const int defaultFood = 2;
	const int requireNutrientToFix = 2;

	int outerCoating;
	int innerCoating;
	int food;
	int stalk;

	int outerCoatingLevel;
	int innerCoatingLevel;
	int feedingLevel;
	int stalkLevel;

	public void SetOuterCoating(int newValue)
	{
		outerCoating = newValue;
	}
	public void SetInnerCoating(int newValue)
	{
		innerCoating = newValue;
	}
	public void SetFood(int newValue)
	{
		food = newValue;
	}
	public void SetStalk(int newValue)
	{
		stalk = newValue;
	}

	public void FixOuterCoating()
	{
		if (Nutrient.GetNutrient() >= requireNutrientToFix && CalculateOuterCoatingFromLevel(outerCoatingLevel) > outerCoating)
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - requireNutrientToFix);
			SetOuterCoating(GetOuterCoating() + 1);
			Debug.Log("Fix OuterCoating");
		}
	}

	public void FixInnerCoating()
	{
		if (Nutrient.GetNutrient() >= requireNutrientToFix && CalculateInnerCoatingFromLevel(innerCoatingLevel) > innerCoating)
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - requireNutrientToFix);
			SetInnerCoating(GetInnerCoating() + 1);
			Debug.Log("Fix InnerCoating");
		}
	}

	public void ExchangeNutrientToFood()
	{
		if (Nutrient.GetNutrient() > 0)
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - 1);
			SetFood(GetFood() + CalculateFeedingFromLevel(feedingLevel));
			Debug.Log("Exchange Nutrient to Food");
		}
	}

	public void FixStalk()
	{
		if (Nutrient.GetNutrient() >= requireNutrientToFix && CalculateStalkFromLevel(stalkLevel) > stalk)
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - requireNutrientToFix);
			SetStalk(GetStalk() + 1);
			Debug.Log("Fix Stalk");
		}
	}

	public void UpgradeOuterCoating()
	{
		if (outerCoatingLevel < 5 && Nutrient.GetNutrient() >= CalculateUpgradeOuterCoatingNutrient(outerCoatingLevel))
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - CalculateUpgradeOuterCoatingNutrient(outerCoatingLevel));
			outerCoatingLevel++;
			SetOuterCoating(CalculateOuterCoatingFromLevel(outerCoatingLevel));
			Debug.Log("OuterCoating upgrade");
		}
	}
	public void UpgradeInnerCoating()
	{
		if (innerCoatingLevel < 5 && Nutrient.GetNutrient() >= CalculateUpgradeInnerCoatingNutrient(innerCoatingLevel))
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - CalculateUpgradeInnerCoatingNutrient(innerCoatingLevel));
			innerCoatingLevel++;
			SetInnerCoating(CalculateInnerCoatingFromLevel(innerCoatingLevel));
			Debug.Log("InnerCoating upgrade");
		}	}
	public void UpgradeFeeding()
	{
		//
	}
	public void UpgradeStalk()
	{
		if (stalkLevel < 5 && Nutrient.GetNutrient() >= CalculateUpgradeStalkNutrient(stalkLevel))
		{
			Nutrient.SetNutrient(Nutrient.GetNutrient() - CalculateUpgradeStalkNutrient(stalkLevel));
			stalkLevel++;
			SetStalk(CalculateStalkFromLevel(stalkLevel));
			Debug.Log("Stalk upgrade");
		}
	}

	public int GetOuterCoating()
	{
		return outerCoating;
	}
	public int GetInnerCoating()
	{
		return innerCoating;
	}
	public int GetFood()
	{
		return food;
	}
	public int GetStalk()
	{
		return stalk;
	}

	public void EatFoodAtTurnEnd()
	{
		food--;
	}

	void StatInitialize()
	{
		outerCoating = outerCoatingLevel;
		innerCoating = innerCoatingLevel * 3;
		food = defaultFood;
		stalk = stalkLevel * 2;
	}

	int CalculateUpgradeOuterCoatingNutrient(int presentOuterCoatingLevel)
	{
		return presentOuterCoatingLevel + 1;
	}

	int CalculateUpgradeInnerCoatingNutrient(int presentInnerCoatingLevel)
	{
		if (presentInnerCoatingLevel == 1)
		{
			return 3;
		}
		else
		{
			return CalculateUpgradeInnerCoatingNutrient(presentInnerCoatingLevel - 1) + presentInnerCoatingLevel;
		}
	}

	int CalculateUpgradeStalkNutrient(int presentStalkLevel)
	{
		return (presentStalkLevel) * 2;
	}

	int CalculateOuterCoatingFromLevel(int outerCoatingLevel)
	{
		int result = (outerCoatingLevel - 1) * 3;
		if (result == 0)
		{
			result = 1;
		}
		return result;
	}

	int CalculateInnerCoatingFromLevel(int innerCoatingLevel)
	{
		if (innerCoatingLevel == 1)
		{
			return 3;
		}
		else
		{
			return CalculateInnerCoatingFromLevel(innerCoatingLevel - 1) + innerCoatingLevel;
		}
	}

	int CalculateFeedingFromLevel(int feedingLevel)
	{
		return feedingLevel * 3;
	}

	int CalculateStalkFromLevel(int stalkLevel)
	{
		return stalkLevel * 2;
	}

	// Use this for initialization
	void Start () {
		outerCoatingLevel = 1;
		innerCoatingLevel = 1;
		feedingLevel = 1;
		stalkLevel = 1;

		StatInitialize();
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text =
			"겉껍질 : 내구도 " + outerCoating + "/" + CalculateOuterCoatingFromLevel(outerCoatingLevel) + " (레벨 " + outerCoatingLevel + ")\n" +
			"속껍질 : 내구도 " + innerCoating + "/" + CalculateInnerCoatingFromLevel(innerCoatingLevel) + " (레벨 " + innerCoatingLevel + ")\n" +
			"양분 : " + food + " (" + CalculateFeedingFromLevel(feedingLevel) + "/영양분) (레벨 " + feedingLevel + ")\n" +
			"꼭지 : 내구도 " + stalk + "/" + CalculateStalkFromLevel(stalkLevel) + " (레벨 " + stalkLevel + ")\n";
	}
}

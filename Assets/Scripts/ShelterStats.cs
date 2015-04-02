using UnityEngine;
using System.Collections;

public class ShelterStats : MonoBehaviour {

	int outerCoating;
	int innerCoating;
	int feeding;
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
	public void SetFeeding(int newValue)
	{
		feeding = newValue;
	}
	public void SetStalk(int newValue)
	{
		stalk = newValue;
	}

	public void UpgradeOuterCoating()
	{
		outerCoatingLevel++;
	}
	public void UpgradeInnerCoating()
	{
		innerCoatingLevel++;
	}
	public void UpgradeFeeding()
	{
		feedingLevel++;
	}
	public void UpgradeStalk()
	{
		stalkLevel++;
	}

	public int GetOuterCoating()
	{
		return outerCoating;
	}
	public int GetInnerCoating()
	{
		return innerCoating;
	}
	public int GetFeeding()
	{
		return feeding;
	}
	public int GetStalk()
	{
		return stalk;
	}

	void StatInitialize()
	{
		outerCoating = outerCoatingLevel;
		innerCoating = innerCoatingLevel * 3;
		feeding = feedingLevel * 3;
		stalk = stalkLevel * 2;
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
			"양분 : " + CalculateFeedingFromLevel(feedingLevel) + "/영양분 (레벨 " + feedingLevel + ")\n" +
			"꼭지 : 내구도 " + stalk + "/" + CalculateStalkFromLevel(stalkLevel) + " (레벨 " + stalkLevel + ")\n";
	}
}

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
		GetComponent<TextMesh>().text = "겉껍질 : " + outerCoating + " (레벨 " + outerCoatingLevel + ")\n" +
										"속껍질 : " + innerCoating + " (레벨 " + innerCoatingLevel + ")\n" +
										"양분 : " + feeding + " (레벨 " + feedingLevel + ")\n" +
										"꼭지 : " + stalk + " (레벨 " + stalkLevel + ")\n";
	}
}

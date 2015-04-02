using UnityEngine;
using System.Collections;

public class Calender : MonoBehaviour {

	public enum Half
	{
		First,
		Second,
		Default
	}

	int month;
	Half halfMonth;

	string ToString(int month, Half halfMonth)
	{
		if (halfMonth == Half.First)
		{
			return month + "개월, 상반기";
		}
		else if (halfMonth == Half.Second)
		{
			return month + "개월, 하반기";
		}
		else
			return month + "개월";
	}

	// Use this for initialization
	void Start () {
		month = 1;
		halfMonth = Half.First;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = ToString(month, halfMonth);
	}
}

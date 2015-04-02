using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		TitleManager.GetTitleManagerInstance().ContinueGame();
	}
}

using UnityEngine;
using System.Collections;

public class TurnEndButton : MonoBehaviour {

	void OnMouseDown()
	{
		GameManager.GetGameManagerInstance().EndTurn();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

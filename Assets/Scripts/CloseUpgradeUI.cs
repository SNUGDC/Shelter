using UnityEngine;
using System.Collections;

public class CloseUpgradeUI : MonoBehaviour {

	public GameObject upgradeUI;

	void OnMouseDown()
	{
		upgradeUI.SetActive(false);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

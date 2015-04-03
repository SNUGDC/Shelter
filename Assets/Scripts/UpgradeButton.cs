using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {

	public GameObject upgradeUI;

	void OnMouseDown()
	{
		upgradeUI.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		upgradeUI.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}
}

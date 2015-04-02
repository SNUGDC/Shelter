using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager UIManagerInstance = null;

	public GameObject Calender;
	public GameObject Nutrient;
	public GameObject ShelterStats;
	public GameObject TurnEndButton;
	public GameObject UpgradeButton;

	public GameManager.CameraPosition cameraPosition = GameManager.CameraPosition.Default;

	void Awake()
	{
		UIManagerInstance = this;
	}

	public static UIManager GetUIManagerInstance()
	{
		return UIManagerInstance;
	}

	// Use this for initialization
	void Start () {
		UpdateAppearUI();
	}

	void UpdateAppearUI()
	{
		cameraPosition = GameManager.GetGameManagerInstance().GetCameraPosition();
		if (cameraPosition == GameManager.CameraPosition.Out)
		{
			Calender.GetComponent<MeshRenderer>().enabled = true;
			Nutrient.GetComponent<MeshRenderer>().enabled = false;
			ShelterStats.GetComponent<MeshRenderer>().enabled = false;
			TurnEndButton.SetActive(false);
			UpgradeButton.SetActive(false);
		}
		else if (cameraPosition == GameManager.CameraPosition.Mid)
		{
			Calender.GetComponent<MeshRenderer>().enabled = true;
			Nutrient.GetComponent<MeshRenderer>().enabled = true;
			ShelterStats.GetComponent<MeshRenderer>().enabled = false;
			TurnEndButton.SetActive(true);
			UpgradeButton.SetActive(true);
		}
		else if (cameraPosition == GameManager.CameraPosition.In)
		{
			Calender.GetComponent<MeshRenderer>().enabled = true;
			Nutrient.GetComponent<MeshRenderer>().enabled = true;
			ShelterStats.GetComponent<MeshRenderer>().enabled = true;
			TurnEndButton.SetActive(true);
			UpgradeButton.SetActive(true);
		}
		else if (cameraPosition == GameManager.CameraPosition.Default)
		{
			Debug.Log("cameraPosition : Default");
		}
		else
		{
			Debug.LogError("Invalid input at 'UpdateAppearUI' method");
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateAppearUI();
	}
}

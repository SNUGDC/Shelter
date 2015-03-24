using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	private static TitleManager titleManagerInstance = null;

	public GameObject MainCamera;
	public GameObject prologue;
	public GameObject newGameText;
	public GameObject flower;
	public GameObject whiteScreen;
	public const int activeTimeOfText = 5;
	public const int fadeoutTimeOfText = 2;

	Vector3 openingViewPositionOfCamera = new Vector3 (-2.65f, -0.8f, -10);
	const float openingViewOrthographicSizeOfCamera = 0.5f;

	void Awake()
	{
		titleManagerInstance = this;
	}

	public static TitleManager GetTitleManagerInstance()
	{
		return titleManagerInstance;
	}

	// Use this for initialization
	void Start () {
		InitializeCamera();
		StartCoroutine("ViewPrologue");
	}

	void InitializeCamera()
	{
		MainCamera.transform.position = new Vector3 (0, 0, -10);
		MainCamera.gameObject.camera.orthographicSize = 3.6f;
		Debug.Log("Init status of camera");
	}

	public void NewGame()
	{
		StartCoroutine("ViewNewGameTextAndLoadScene");
	}

	public void ContinueGame()
	{
		StartCoroutine("FadeoutAndLoadScene");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator FadeoutAndLoadScene()
	{
		whiteScreen.SetActive(true);
		iTween.FadeFrom(whiteScreen, 0, fadeoutTimeOfText);
		yield return new WaitForSeconds(fadeoutTimeOfText);
		Application.LoadLevel("InGame");
	}

	IEnumerator ViewNewGameTextAndLoadScene ()
	{
		float moveCameraTime = fadeoutTimeOfText * 2;
		iTween.ValueTo(MainCamera.gameObject, iTween.Hash("from", MainCamera.camera.orthographicSize,
															"to", openingViewOrthographicSizeOfCamera,
														  "time", moveCameraTime,
												"onupdatetarget", this.gameObject, //??
													  "onupdate", "updateOrthographicSizeOfCamera"));
		//Prevent appear background at call Move to opening View.
		yield return new WaitForSeconds(moveCameraTime * 1/4);
		iTween.MoveTo (MainCamera, openingViewPositionOfCamera, moveCameraTime);
		yield return new WaitForSeconds(moveCameraTime * 3/4);
		flower.SetActive(true);
		iTween.FadeFrom(flower, 0, fadeoutTimeOfText);
		yield return new WaitForSeconds(fadeoutTimeOfText);
		yield return new WaitForSeconds(fadeoutTimeOfText);
		whiteScreen.SetActive(true);
		iTween.FadeFrom(whiteScreen, 0, fadeoutTimeOfText);
		yield return new WaitForSeconds(fadeoutTimeOfText);
		InitializeCamera();
		newGameText.SetActive(true);
		yield return new WaitForSeconds(activeTimeOfText);
		Application.LoadLevel("InGame");
	}

	void updateOrthographicSizeOfCamera(float size)
	{
		MainCamera.camera.orthographicSize = size;
	}

	IEnumerator ViewPrologue()
	{
		prologue.SetActive(true);
		yield return new WaitForSeconds(activeTimeOfText);
		iTween.FadeTo(prologue, 0, fadeoutTimeOfText);
		yield return new WaitForSeconds(fadeoutTimeOfText);
		prologue.SetActive(false);
	}
}

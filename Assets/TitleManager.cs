using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	private static TitleManager titleManagerInstance = null;

	public GameObject prologue;
	public GameObject newGameText;
	public int activeTimeOfText = 3;

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
		StartCoroutine("ViewPrologue");
	}

	public void NewGame()
	{
		StartCoroutine("ViewNewGameTextAndLoadScene");
	}

	public void ContinueGame()
	{
		Application.LoadLevel("InGame");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator ViewNewGameTextAndLoadScene ()
	{
		newGameText.SetActive(true);
		yield return new WaitForSeconds(activeTimeOfText);
		Application.LoadLevel("InGame");
	}

	IEnumerator ViewPrologue()
	{
		prologue.SetActive(true);
		yield return new WaitForSeconds(activeTimeOfText);
		prologue.SetActive(false);
		//iTween.FadeFrom(prologue, 0, 1);
	}
}

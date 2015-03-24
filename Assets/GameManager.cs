using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager gameManagerInstance = null;

	public GameObject MainCamera;
	public CameraPosition cameraPosition = CameraPosition.Default;
	public const int cameraMoveTime = 2;

	Vector3 outPositionOfCamera = new Vector3 (0, 0, -10);
	Vector3 midPositionOfCamera = new Vector3 (-2.25f, -0.9f, -10);
	Vector3 inPositionOfCamera = new Vector3 (-2.59f, -0.9f, -10);

	const float outOrthographicSizeOfCamera = 3.6f;
	const float midOrthographicSizeOfCamera = 3.6f / 2;
	const float inOrthographicSizeOfCamera = 3.6f / 6;

	Vector3 outScaleOfCamera = new Vector3 (1, 1, 1);
	Vector3 midScaleOfCamera = new Vector3 (2, 2, 1);
	Vector3 inScaleOfCamera = new Vector3 (6, 6, 1);

	public enum CameraPosition
	{
		Out,
		Mid,
		In,
		Default
	};

	void Awake()
	{
		gameManagerInstance = this;
	}

	public static GameManager GetGameManagerInstance()
	{
		return gameManagerInstance;
	}

	// Use this for initialization
	void Start ()
	{
		InitializeCamera();
	}

	void InitializeCamera()
	{
		cameraPosition = CameraPosition.Out;
		MainCamera.transform.position = new Vector3 (0, 0, -10);
		MainCamera.gameObject.camera.orthographicSize = outOrthographicSizeOfCamera;
		Debug.Log("Init status of camera");
	}

	IEnumerator MoveAniOfCamera(Vector3 position, float size)
	{
			iTween.MoveTo (MainCamera, position, cameraMoveTime);
			ChangeOrthographicSizeOfCamera(size);
			yield return new WaitForSeconds(cameraMoveTime);
	}

	void MoveCamera (CameraPosition cameraPosition)
	{
		if (cameraPosition == CameraPosition.Out)
		{
			StartCoroutine(MoveAniOfCamera(outPositionOfCamera, outOrthographicSizeOfCamera));
//			iTween.MoveTo (MainCamera, outPositionOfCamera, cameraMoveTime);
//			ChangeOrthographicSizeOfCamera(outOrthographicSizeOfCamera);
			//iTween.ScaleTo (MainCamera, outScaleOfCamera, cameraMoveTime);
		}
		else if (cameraPosition == CameraPosition.Mid)
		{
			StartCoroutine(MoveAniOfCamera(midPositionOfCamera, midOrthographicSizeOfCamera));
//			iTween.MoveTo (MainCamera, midPositionOfCamera, cameraMoveTime);

//			ChangeOrthographicSizeOfCamera(midOrthographicSizeOfCamera);

/*			iTween.ValueTo (MainCamera.gameObject, iTween.Hash("from", MainCamera.camera.orthographicSize,
															     "to", midOrthographicSizeOfCamera,
															   "time", cameraMoveTime,
														   "onupdate", "ChangeOrthographicSizeOfCamera",
													 "onupdatetarget", MainCamera.gameObject
													 ));
*/			//iTween.ScaleTo (MainCamera, midScaleOfCamera, cameraMoveTime);
		}
		else if (cameraPosition == CameraPosition.In)
		{
			StartCoroutine(MoveAniOfCamera(inPositionOfCamera, inOrthographicSizeOfCamera));
			//iTween.MoveTo (MainCamera, inPositionOfCamera, cameraMoveTime);
			//ChangeOrthographicSizeOfCamera(inOrthographicSizeOfCamera);
			//iTween.ScaleTo (MainCamera, inScaleOfCamera, cameraMoveTime);
		}
		else
		{
			Debug.LogError("Invalid input to 'MoveCamera'");
		}
	}

	void ChangeOrthographicSizeOfCamera(float size)
	{
		MainCamera.gameObject.camera.orthographicSize = size;
	}

	//temp value. using test.
	int cameraStatus = 0;

	void cameraMoveByStatus()
	{
		if (cameraStatus == 0)
		{
			MoveCamera(CameraPosition.Mid);
			cameraStatus++;
		}
		else if (cameraStatus == 1)
		{
			MoveCamera(CameraPosition.In);
			cameraStatus++;
		}
		else if (cameraStatus == 2)
		{
			MoveCamera(CameraPosition.Out);
			cameraStatus = 0;
		}
	}

	void OnMouseDown()
	{
		cameraMoveByStatus();
//		MoveCamera(CameraPosition.Mid);
	}

	// Update is called once per frame
	void Update () {

	}
}

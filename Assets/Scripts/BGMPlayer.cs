using UnityEngine;
using System.Collections;

public class BGMPlayer : MonoBehaviour {

	private static BGMPlayer BGMPlayerInstance = null;

	void Awake()
	{
		BGMPlayerInstance = this;
	}

	public static BGMPlayer GetBGMPlayerInstance()
	{
		return BGMPlayerInstance;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update () {

	}
}

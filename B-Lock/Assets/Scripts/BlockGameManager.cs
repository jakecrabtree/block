using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour {

	Timer timer;
	PageManager pageManager;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
		pageManager.LoadPage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameOver(){

	}
}

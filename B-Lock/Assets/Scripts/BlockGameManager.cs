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
		GameObject pageManagerObject = new GameObject();
		pageManager = pageManagerObject.AddComponent<PageManager>();
		Instantiate(pageManagerObject);
		pageManager.LoadPage();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameOver(){

	}
}

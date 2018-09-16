using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PageManager : MonoBehaviour {

	private static PageManager manager = null;
	BlockGameManager blockGameManager;
	AdManager adManager;
	string resourcesPath = "Prefabs" + Path.DirectorySeparatorChar + "Pages";
	GameObject[] pageBackgrounds;
	GameObject currentPage;
	float currentPageYTransform;

	Camera camera;
	
	float cameraMinX;
	float cameraMinY;
	float cameraMaxX;
	float cameraMaxY;

	public void Initialize(BlockGameManager blockGameManager){
		this.blockGameManager  = blockGameManager;
	}

	void Awake(){
		if (manager == null){
			manager = this;
		}
		else if (manager != this){
			Destroy(this.gameObject);
		}
		GameObject adManagerObject = new GameObject();
		adManager = adManagerObject.AddComponent<AdManager>();
		adManager.GetComponent<AdManager>().Initialize(this);
		Instantiate(adManagerObject);
		pageBackgrounds = Resources.LoadAll<GameObject>(resourcesPath);
		camera = Camera.main;
		float frustumHeight = 2f * camera.orthographicSize;
 		float frustumWidth = frustumHeight * camera.aspect;
		cameraMinX = (camera.transform.position.x - 0.5f*frustumWidth)*.8f;
		cameraMaxX = (camera.transform.position.x + 0.5f*frustumWidth)*.8f;
		cameraMinY = (camera.transform.position.x - 0.5f*frustumHeight)*.8f;
		cameraMaxY = (camera.transform.position.x + 0.5f*frustumHeight)*.8f; 
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(int adPerLevelAmount){
		if (currentPage == null){
			currentPage = Instantiate(pageBackgrounds[Random.Range(0,pageBackgrounds.Length)]);
			currentPageYTransform = -1f* currentPage.transform.position.y;
		}
		else{
			currentPage.transform.Translate(0.0f, currentPageYTransform, 0.0f);
		}
		for (int i = 0; i < adPerLevelAmount; i++){
			adManager.CreateAd(new Vector2(Random.Range(cameraMinX, cameraMaxX),
								Random.Range(cameraMinY, cameraMaxY)), i);
		}
	}

	public void AdCompleted(bool succeeded){
		blockGameManager.AdCompleted(succeeded);
	}
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockGameManager : MonoBehaviour {

	private static BlockGameManager manager = null;
	string timerPath = "Prefabs" + Path.DirectorySeparatorChar + "Misc" + Path.DirectorySeparatorChar + "Canvas";
	GameObject timerUIObject;
	Timer timer;
	PageManager pageManager;

	int timePenalty = 3;
	int adPerLevelAmount = 7;
	int adCount;
	int numLevels = 3;
	int level = 0;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{	
		if (manager == null){
			manager = this;
		}
		else if (manager != this){
			Destroy(this.gameObject);
		}
		GameObject pageManagerObject = new GameObject();
		pageManager = pageManagerObject.AddComponent<PageManager>();
		Instantiate(pageManagerObject);
		pageManager.Initialize(this);
		pageManager.LoadPage(adPerLevelAmount);
		adCount = adPerLevelAmount;

		timerUIObject = Instantiate(Resources.Load<GameObject>(timerPath));
        Color oldColor = timerUIObject.GetComponentInChildren<Image>().color;
        timerUIObject.GetComponentInChildren<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, 0.0f);
		timer = timerUIObject.GetComponentInChildren<Timer>();
		timer.Initialize(this);
        GameObject.FindGameObjectsWithTag("Music");
        
            }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AdCompleted(bool succeeded){
		if (!succeeded){
			timer.DecreaseTime(timePenalty);
		}
		if (--adCount == 0){
			NextLevel();
		}
	}

	void NextLevel(){
		adCount = adPerLevelAmount;
		if (++level > numLevels - 1){
			GameOver(true);
		}
		pageManager.LoadPage(adPerLevelAmount);
	}

	public void GameOver(bool win){
		if (win){
			Debug.Log("Win!");
            SceneManager.LoadScene(3);
            //Change Music
		}else{
			Debug.Log("Lose!");
            SceneManager.LoadScene(4);
            //Change Music
        }
	}
}

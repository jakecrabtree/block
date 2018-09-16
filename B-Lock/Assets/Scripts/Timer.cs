using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft = 60;
    Boolean reachedZero = false;
    int timeRemainingInt;

    GameObject firstDigit;
    GameObject secondDigit;

    // Use this for initialization
    void Start () {
        //timeRemainingText = GetComponent<Text>();
        firstDigit = GameObject.Find("6");
        secondDigit = GameObject.Find("0");
    }
	
	// Update is called once per frame
	void Update () {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeRemainingInt = (int)timeLeft;
            firstDigit = Instantiate(Resources.Load<GameObject>("Assets / Resources / Prefabs / Numbers / 0.prefab"),firstDigit.transform);
            secondDigit = Instantiate(Resources.Load<GameObject>((timeRemainingInt % 10).ToString()), secondDigit.transform);           
        }
        else if(!reachedZero)
        {
            firstDigit = Instantiate(GameObject.Find("0"), secondDigit.transform);
            secondDigit = Instantiate(GameObject.Find("0"), secondDigit.transform);
            timesUp();
            reachedZero = true;
        }

        
	}

	public void DecreaseTime(int amount){
        timeLeft -= amount;
	}

    void timesUp() {
     
    }
}

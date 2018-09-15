using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft = 60;
    Boolean reachedZero = false;
    Text timeRemainingText;
	// Use this for initialization
	void Start () {
		timeRemainingText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeRemainingText.text = Math.Round(timeLeft, 2).ToString();
        }
        else if(!reachedZero)
        {
            timesUp();
            reachedZero = true;
        }

        
	}

	void DecreaseTime(int amount){
        timeLeft -= amount;
	}

    void timesUp() {
     
    }
}

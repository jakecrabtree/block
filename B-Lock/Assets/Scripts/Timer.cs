using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft = 60;
    Text timeRemainingText;
	// Use this for initialization
	void Start () {
		timeRemainingText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeRemainingText.text = Math.Round(timeLeft, 2).ToString();
	}

	void DecreaseTime(int amount){
        timeLeft -= amount;
	}
}

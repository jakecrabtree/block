using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft = 60;
    Boolean reachedZero = false;
    Text timeRemainingText;

    BlockGameManager blockGameManager;

    public void Initialize(BlockGameManager blockGameManager){
        this.blockGameManager = blockGameManager;
    }

    // Use this for initialization
    void Start () {
        timeRemainingText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeRemainingText.text = Math.Round(timeLeft,0).ToString();         

        }
        else if(!reachedZero)
        {
            timeRemainingText.text = "0";
            timesUp();
            reachedZero = true;
        }

    }



    IEnumerator DoCheck()
    {
        Debug.Log("Got here");
        Boolean temp = true;
        for (double i = .5;i>=0;i-=.1)
        {
            if(temp)
            {
                timeRemainingText.color = Color.red;
                temp = false;
            }
            else
            {
                timeRemainingText.color = new Color(0.3098039f, 0.7329956f, 0.9803922f, 1);
                temp = true;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    public void DecreaseTime(int amount){
        timeLeft -= amount;
        StartCoroutine("DoCheck");
	}

    void timesUp() {
        blockGameManager.GameOver(false);
    }

}

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

    Sprite s0;
    Sprite s1;
    Sprite s2;
    Sprite s3;
    Sprite s4;
    Sprite s5;
    Sprite s6;
    Sprite s7;
    Sprite s8;
    Sprite s9;

    // Use this for initialization
    void Start () {
        //timeRemainingText = GetComponent<Text>();
        firstDigit = Instantiate(new GameObject(), transform);
        firstDigit.AddComponent<SpriteRenderer>();
        secondDigit = Instantiate(new GameObject(), transform);
        secondDigit.AddComponent<SpriteRenderer>();
        secondDigit.transform.Translate(260, 0, 0);

         s0 = Resources.Load<Sprite>("0");
         s1 = Resources.Load<Sprite>("1");
         s2 = Resources.Load<Sprite>("2");
         s3 = Resources.Load<Sprite>("3");
         s4 = Resources.Load<Sprite>("4");
         s5 = Resources.Load<Sprite>("5");
         s6 = Resources.Load<Sprite>("6");
         s7 = Resources.Load<Sprite>("7");
         s8 = Resources.Load<Sprite>("8");
         s9 = Resources.Load<Sprite>("9");
    }
	
	// Update is called once per frame
	void Update () {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeRemainingInt = (int)timeLeft;
            if(timeRemainingInt / 10 == 6)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s6;
            }
            else if(timeRemainingInt/10 == 5)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s5;
            }
            else if (timeRemainingInt / 10 == 4)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s4;
            }
            else if (timeRemainingInt / 10 == 3)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s3;
            }
            else if (timeRemainingInt / 10 == 2)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s2;
            }
            else if (timeRemainingInt / 10 == 1)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s1;
            }
            else if (timeRemainingInt / 10 == 0)
            {
                firstDigit.GetComponent<SpriteRenderer>().sprite = s0;
            }

            if(timeRemainingInt % 10 == 9)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s9;
            }
            else if (timeRemainingInt % 10 == 8)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s8;
            }
            else if (timeRemainingInt % 10 == 7)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s7;
            }
            else if (timeRemainingInt % 10 == 6)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s6;
            }
            else if (timeRemainingInt % 10 == 5)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s5;
            }
            else if (timeRemainingInt % 10 == 4)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s4;
            }
            else if (timeRemainingInt % 10 == 3)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s3;
            }
            else if (timeRemainingInt % 10 == 2)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s2;
            }
            else if (timeRemainingInt % 10 == 1)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s1;
            }
            else if (timeRemainingInt % 10 == 0)
            {
                secondDigit.GetComponent<SpriteRenderer>().sprite = s0;
            }
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

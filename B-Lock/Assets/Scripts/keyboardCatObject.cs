using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboardCatObject : MonoBehaviour {

    Ad ad;
    string[] wordBank = new string[] {"hello","shiba inu","delete this","bottom text","cake","doorframe","chair","bean bag","exterior","hardwood","california",
                                        "laptop","window pane","elephant","tabletop","arraylist","backpack","game jam", "medium green","references","cover letter"};

    GameObject textHolder;
    GameObject inputField;

    // Use this for initialization
    public void Initialize(Ad ad)
    {
        this.ad = ad;
    }
    void Start()
    {
        int randomIndex = Random.Range(0, wordBank.Length);

        textHolder = GameObject.Find("textToCopy");
        textHolder.GetComponent<TextMesh>().text = wordBank[randomIndex];
        inputField = GameObject.Find("responseBox");
        inputField.GetComponent<InputField>().text = "Enter response here...";
        
        //inputField.GetComponent<Text>().GetComponent<Renderer>().sortingOrder = textHolder.GetComponent<Text>().GetComponent<Renderer>().sortingOrder + 1;

    }

    // Update is called once per frame
    void Update () {
		if(textHolder.GetComponent<Text>().text == inputField.GetComponent<InputField>().text)
        {
            ad.OnSucceed();
        }
	}
}

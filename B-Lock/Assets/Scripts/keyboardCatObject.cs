using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboardCatObject : MonoBehaviour {

    Ad ad;
    string[] wordBank = new string[] {"hello","shiba inu","delete this","bottom text","cake","doorframe","chair","bean bag","exterior","hardwood","california",
                                        "laptop","window pane","elephant","tabletop","arraylist","backpack","game jam", "medium green","references","cover letter","using system","this int","namespace","public int","void if","path direct","string letter","foreach","update","int curr","index","base on","mousedown","public void","letter float","else return","new copy","letter object","initialize","quaternion","spritewidth","sprite height","get letter","case adshape","new vector","if input","private void","rigidbody","serialize","using unity","void start","else false","else true","if true","if false","component","gameobject","randomindex","get component","inputfield","textmesh","sortingorder","response","range zero","word bank","monobehavior","random index","new input","hello world"};

    TextMesh textHolder;
    InputField inputField;

    public InputField keyboardinputField;

    // Use this for initialization
    public void Initialize(Ad ad)
    {
        this.ad = ad;
    }
    void Start()
    {
        int randomIndex = Random.Range(0, wordBank.Length);
        keyboardinputField = GetComponentInChildren<InputField>();
        textHolder = GetComponentInChildren<TextMesh>();

        string temp = wordBank[randomIndex];
        temp = temp.ToLower();
        textHolder.GetComponent<TextMesh>().text = temp;

        Debug.Log("hi");
    }

    // Update is called once per frame
    void Update () {
        if (keyboardinputField.text == textHolder.GetComponent<TextMesh>().text)
        {
            ad.OnSucceed();
        }
    }

}

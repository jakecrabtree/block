using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class AudioManager : MonoBehaviour {

	string pathToMusic = "Music" + Path.DirectorySeparatorChar;
	string[] audioFileNames = {"B-Lock Home Screen Music", "B-Lock Background music",
								"B-Lock Failure Music", "B-Lock Victory music", 
								"B-Lock Mess Up Sound"};

	AudioSource audioSource;
	AudioSource soundSource;

	List<AudioClip> clips;

	void Awake(){
		clips = new List<AudioClip>();
		foreach (string name in audioFileNames){
			string path = new StringBuilder(pathToMusic).Append(name).ToString();
			clips.Add(Resources.Load<AudioClip>(path));
		}
		audioSource = gameObject.GetComponent<AudioSource>();
		soundSource = gameObject.AddComponent<AudioSource>();
		playHomeMusic();
	}

	void playClip(int index){
		audioSource.clip = clips[index];
		audioSource.Play();
	}

	public void playHomeMusic(){
		playClip(0);
	}

	public void playBackgroundMusic(){
		playClip(1);
	}

	public void playFailureMusic(){
		playClip(2);
		Invoke("playHomeMusic",clips[2].length);
	}

	public void playVictoryMusic(){
		playClip(3);
		Invoke("playHomeMusic",clips[2].length);
	}

	public void playMessUpSound(){
		soundSource.clip = clips[4];
		soundSource.Play();
		Invoke("playBackgroundMusic",clips[4].length);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

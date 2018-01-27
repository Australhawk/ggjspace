using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public void Start(){
		this.transform.Find("MainMenu").gameObject.SetActive (false);
		this.transform.Find ("OptionsMenu").gameObject.SetActive (false);
	}
	public void Toggle(){
		GameObject ob = this.transform.Find("MainMenu").gameObject;
		GameObject opt = this.transform.Find("OptionsMenu").gameObject;
		if (ob) {
			ob.SetActive (!ob.activeSelf);
		} else {
			this.transform.Find("MainMenu").gameObject.SetActive (true);
		}
		if (opt) {
			opt.gameObject.SetActive (false);
		}
	}
	public void Continue(){
		GameObject.Find("MainMenu").gameObject.SetActive (false);
		GameManager.instance.playing = true;
	}
	public void Options(){
		GameObject.Find("MainMenu").gameObject.SetActive (false);
		this.transform.Find ("OptionsMenu").gameObject.SetActive (false);
	}
	public void Back(){
		GameObject.Find("MainMenu").gameObject.SetActive (true);
		GameObject.Find("OptionsMenu").gameObject.SetActive (false);
	}
	public void Quit(){
		Application.Quit();
	}
}

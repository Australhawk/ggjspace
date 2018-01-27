using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IntroText : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		StartCoroutine (ShowText());
	}
	
	// Update is called once per frame
	IEnumerator ShowText(){
		var text = GetComponent<TextMeshProUGUI> ();
		text.text = "At the beginning, there was nothing";
		yield return new WaitForSeconds (4);
		text.text = "Not event a rock, a sun or a human";
		yield return new WaitForSeconds (4);
		text.text = "But something happend";
		yield return new WaitForSeconds (4);
		text.text = "Something Changed";
		yield return new WaitForSeconds (4);
		text.text = "A new entity transmitted its power to us";
		yield return new WaitForSeconds (4);
		text.text = "So we could be alive, think and comunicate";
		yield return new WaitForSeconds (4);
		text.text = "Who is this?";
		yield return new WaitForSeconds (4);
		text.text = ".";
		yield return new WaitForSeconds (0.1f);
		text.text = "..";
		yield return new WaitForSeconds (0.1f);
		text.text = "...";
		yield return new WaitForSeconds (0.1f);
		text.text = ".....";
		yield return new WaitForSeconds (0.1f);
		text.text = "......";
		yield return new WaitForSeconds (0.1f);
		text.text = ".......";
		yield return new WaitForSeconds (0.1f);
		text.text = "........";
		yield return new WaitForSeconds (0.1f);
		text.text = "........!?";
		yield return new WaitForSeconds (2);
		text.text = "...gasp";
		yield return new WaitForSeconds (2);
		text.text = "";


	}
}

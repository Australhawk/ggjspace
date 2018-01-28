using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EndingScript : MonoBehaviour {
    public GameObject panel;
	// Use this for initialization
	void Start () {
        StartCoroutine(ShowText());
	}
	
	// Update is called once per frame
	void Update () {

    }
    IEnumerator ShowText() {
        var text = GetComponent<TextMeshProUGUI>();
        text.text = "Wait...";
        yield return new WaitForSeconds(4);
        text.text = "Hadn't I made a level 5?";
        yield return new WaitForSeconds(4/3f);
        text.text = "Hadn't I made a level 5?.";
        yield return new WaitForSeconds(4/3f);
        text.text = "Hadn't I made a level 5?..";
        yield return new WaitForSeconds(4/3f);
        text.text = "Hadn't I made a level 5?...";
        yield return new WaitForSeconds(4);
        text.text = "Well, that's awkward. Sorry for the confusion.";
        yield return new WaitForSeconds(4);
        text.text = "You may be thinking though, 'Who the hell are you?'";
        yield return new WaitForSeconds(4);
        text.text = "Because apparently, if you are God...";
        yield return new WaitForSeconds(4);
        text.text = "there shouldn't be anyone superior, am I right?";
        yield return new WaitForSeconds(4);
        text.text = "Well, I'm the one who has been looking at you all this time.";
        yield return new WaitForSeconds(4);
        text.text = "You didn't think The Rings appeared magically out of nowhere, did you?";
        yield return new WaitForSeconds(5);
        text.text = "Well, it's time for you to leave, I hope it was fun pretending to be God.";
        yield return new WaitForSeconds(5);
        text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End.";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End.";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End.";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End.";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End.";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End";
		yield return new WaitForSeconds(0.4f);
		text.text = "The End?";
		yield return new WaitForSeconds(1.5f);
        CustomSceneManager.ChangeScene("Intro");
    }
}

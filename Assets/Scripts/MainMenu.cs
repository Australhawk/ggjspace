using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public void Start(){
        GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
        DontDestroyOnLoad(this);
    }
	public void Toggle(){
        GameObject ob = GameObject.Find("Menu");
        if (ob) {
            bool set = !ob.GetComponent<Canvas>().enabled;
            ob.GetComponent<Canvas>().enabled = set;
            if (set) {
                foreach(GameObject go in GameManager.instance.planets) {
                    go.GetComponent<Planet>().Pause();
                }
            } else {
                foreach (GameObject go in GameManager.instance.planets) {
                    go.GetComponent<Planet>().Resume();
                }
            }
            GameManager.instance.playing = !set;
        } else {
            GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
        }
	}
	public void Continue() {
        GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
        GameManager.instance.playing = true;
	}
	public void Options() {
        Show(GameObject.Find("OptionsMenu").GetComponent<CanvasGroup>());
        Hide(GameObject.Find("MainMenu").GetComponent<CanvasGroup>());
        Hide(GameObject.Find("VolumeMenu").GetComponent<CanvasGroup>());
    }
    public void Volume() {
        Hide(GameObject.Find("OptionsMenu").GetComponent<CanvasGroup>());
        Show(GameObject.Find("VolumeMenu").GetComponent<CanvasGroup>());
        Hide(GameObject.Find("MainMenu").GetComponent<CanvasGroup>());
    }

	public void Back() {
        Hide(GameObject.Find("OptionsMenu").GetComponent<CanvasGroup>());
        Hide(GameObject.Find("VolumeMenu").GetComponent<CanvasGroup>());
        Show(GameObject.Find("MainMenu").GetComponent<CanvasGroup>());
    }
	public void Quit(){
		Application.Quit();
	}
    void Show(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    void Hide(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class MicTestManager : MonoBehaviour {

	public static MicTestManager instance;
	//Used in the menu to update visuals.
	public TMP_Dropdown dropdown;
	//public Dropdown dropdown;
	public Slider slider;
	public Slider calibrateSlider;
	public InputField calibrateInput;
	private MicInput micInput;
	private bool start_testing = false;
	private bool microphone_ok = false;
	private float maxLevel;
	private float minLevel;
	private int micIndex;
	void Awake() {
		//For now, all mics will be loaded in, we should restrain this from happening in the menu screen later on.
		if (instance != null) {
			Destroy (this);
		} else {
			instance = this;
			DontDestroyOnLoad(this);
		}

	}
	// Use this for initialization
	void Start () {
		if (dropdown != null) {
			micInput = new MicInput ();
			UpdateDropDownValues();
			StartCoroutine (Speech ());
		}
	}
	//Called once per frame
	void FixedUpdate() {
		UpdateSlider();
	}
	public void StartTesting(){
		start_testing = true;
	}
	public float GetPower(float loudness){
		float MAX_MULT = 100 / (maxLevel - minLevel);
		float MAX_OFFSET = -MAX_MULT * minLevel + maxLevel;
		float value =  loudness*MAX_MULT + MAX_OFFSET;
		Debug.Log ("Power: " + value);
		return Mathf.Clamp(value,0,100);
	}

	private void UpdateSlider() {
		if (dropdown != null && slider != null) {
			float volume = MicrophoneInputManager.instance.MicrophoneReader.Volume;
			slider.value = volume;
			float r = 100 - volume;
			float g = volume;
			slider.GetComponentsInChildren<Image>()[1].color = new Color(r/100,g/100, 0);
		}
	}

	public void UpdateDropDownValues() {
		MicrophoneInputManager.instance.Mic_devices = Microphone.devices;
		if (dropdown != null) {
			dropdown.ClearOptions ();
			System.Collections.Generic.List<string> mics = new System.Collections.Generic.List<string>();
			Debug.Log ("Found :"+MicrophoneInputManager.instance.Mic_devices + " mics");
			mics.AddRange(MicrophoneInputManager.instance.Mic_devices);
			dropdown.AddOptions(mics);
			//MicrophoneInputManager.instance.InstantiateMicrophones();
			if (dropdown.options.Count > 0) {
				micInput.InitMic (0);
			}
		}
	}

	public void SetDeviceFromDropDown() {
		if (dropdown != null)
			MicrophoneInputManager.instance.Device = dropdown.itemText.text;
	}


	public void UpdateMicrophone() {
		micIndex = dropdown.value;
		micInput.InitMic (dropdown.value);
	}

	public void Play() {
		GameManager.instance.level = 1;
		MicrophoneInputManager.instance.UnloadUnusedMicrophones();
		this.gameObject.SetActive (false);
		CustomSceneManager.ChangeScene("Level_1");
	}
	public void SetSliderValue() {
		calibrateSlider.value = float.Parse(calibrateInput.text);
	}
	IEnumerator Speech() { 
		float min, max;
		GameObject.Find ("First").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		GameObject.Find ("First").GetComponent<CanvasGroup> ().alpha = 1;
		yield return new WaitForSeconds (4);
		while (!microphone_ok) {
			start_testing = false;
			GameObject.Find ("Fifth").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("Fifth").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.Find ("First").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("First").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.Find ("Second").GetComponent<CanvasGroup> ().blocksRaycasts = true;
			GameObject.Find ("Second").GetComponent<CanvasGroup> ().alpha = 1;
			yield return new WaitUntil (() => start_testing);
			GameObject.Find ("Second").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("Second").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.Find ("Third").GetComponent<CanvasGroup> ().blocksRaycasts = true;
			GameObject.Find ("Third").GetComponent<CanvasGroup> ().alpha = 1;
			yield return new WaitForSeconds (5);
			maxLevel = micInput.LevelMax ();
			minLevel = micInput.LevelMin ();
			GameObject.Find ("Third").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("Third").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.Find ("Fourth").GetComponent<CanvasGroup> ().blocksRaycasts = true;
			GameObject.Find ("Fourth").GetComponent<CanvasGroup> ().alpha = 1;
			yield return new WaitForSeconds (5);

			max = micInput.LevelMax ();
			min = micInput.LevelMin ();
			if (max > maxLevel) {
				maxLevel = max;
			}
			if (min < minLevel) {
				minLevel = min;
			}
			Debug.Log ("Min: " + minLevel + ", Max: " + maxLevel);
			GameObject.Find ("Fourth").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("Fourth").GetComponent<CanvasGroup> ().alpha = 0;
			if (maxLevel / minLevel > 100) {
				microphone_ok = true;

			} else {
				GameObject.Find ("Fifth").GetComponent<CanvasGroup> ().blocksRaycasts = true;
				GameObject.Find ("Fifth").GetComponent<CanvasGroup> ().alpha = 1;
				yield return new WaitForSeconds (3);
			}
			
		}
		micInput.StopMicrophone ();
		Debug.Log ("Starting Mic For play");
		micInput.InitMicForPlay (micIndex);
		CustomSceneManager.ChangeScene ("Level_1");
		while (maxLevel/minLevel > 100) {
			max = micInput.LevelMax ();
			min = micInput.LevelMin ();
			if (max > maxLevel) {
				maxLevel = max;
			}
			if (min < minLevel) {
				minLevel = min;
			}
			float power = this.GetPower (max);
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("MicrophoneLevel");
			foreach (GameObject ob in objs) {
				float alpha = Mathf.Clamp((power / 100),0.3f,1f);
				ob.GetComponent<RawImage>().color = new Color(1,1,1,alpha);
			}
			yield return new WaitForSeconds (0.1f);
		}

	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    //Used in the menu to update visuals.
    public Dropdown dropdown;
    public Slider slider;


    // Use this for initialization
    void Start () {
        if (dropdown != null) {
            UpdateDropDownValues();
        }
    }

    //Called once per frame
    void FixedUpdate() {
        UpdateSlider();
    }

    private void UpdateSlider() {
        if (dropdown != null && slider != null) {
			int volume = MicrophoneInputManager.instance.Mic_readers[dropdown.value].GetVolume();
            slider.value = volume;
            float r = 100 - volume;
            float g = volume;
            slider.GetComponentsInChildren<Image>()[1].color = new Color(r/100,g/100, 0);
        }
    }

    public void UpdateDropDownValues() {
		MicrophoneInputManager.instance.Mic_devices = Microphone.devices;
        if (dropdown != null) {
            dropdown.ClearOptions();
            List<string> mics = new List<string>();
			mics.AddRange(MicrophoneInputManager.instance.Mic_devices);
            dropdown.AddOptions(mics);
        }
    }

    public void SetDeviceFromDropDown() {
        if (dropdown != null)
			MicrophoneInputManager.instance.Device = dropdown.itemText.text;
    }


    public void UpdateMicrophone() {
        MicrophoneInputManager.instance.UpdateMicrophoneReader(dropdown.value);
    }

    public void Play() {
		MicrophoneInputManager.instance.UnloadUnusedMicrophones();
		this.gameObject.SetActive (false);
    }
}

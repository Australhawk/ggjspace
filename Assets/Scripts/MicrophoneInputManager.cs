using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * Manages multiple microphones, in case we have to work with multiplayer.
 * 
 */
public class MicrophoneInputManager : MonoBehaviour {
    private string[] mic_devices;
    private int mic_count;
    private string device;

	public static MicrophoneInputManager instance;

    List<MicrophoneReader> mic_readers; //used in menu and mic selection.
    MicrophoneReader microphoneReader;  //used real time during gameplay.

    // Use this for initialization
    void Awake() {
        //For now, all mics will be loaded in, we should restrain this from happening in the menu screen later on.
		if (instance != null) {
			Destroy (this);
		} else {
			instance = this;
			mic_devices = Microphone.devices;
			mic_count = mic_devices.Length;
			mic_readers = new List<MicrophoneReader>();
			InstantiateMicrophones(mic_devices);
			DontDestroyOnLoad(this);
		}
        
    }

    public int GetPower() {
        return microphoneReader.GetVolume();
    }


    /**
     * Starts all microphones in the mic_devices array and attaches them to a MicrophoneReader Object.
     */
    private void InstantiateMicrophones(string[] devices) {
        foreach (string device in devices) {
            MicrophoneReader mic = new MicrophoneReader(device);
            Debug.Log("Registered and starting microphone: " + device);
            try {
                mic.StartMicrophone();
                mic_readers.Add(mic);
            } catch (Exception e) {
                Debug.LogError("WRONG MIC D:");
            }
            mic.StopMicrophone();
        }
        UpdateMicrophoneReader(0);
    }


    internal void UpdateMicrophoneReader(int value) {
        if (microphoneReader != null) {
            microphoneReader.StopMicrophone();
        }
        microphoneReader = mic_readers[value];
        microphoneReader.StartMicrophone();
        Debug.Log("Setting default mic: " + microphoneReader.Device);
        StartCoroutine(microphoneReader.UpdateVolume());
    }

    internal void UnloadUnusedMicrophones() {
        foreach (MicrophoneReader micReader in Mic_readers) {
            if (micReader.Device.Equals(device)) {
                this.microphoneReader = micReader;
            } else {
                micReader.StopMicrophone();
            }
        }
        Mic_readers = null;
    }

    public string[] Mic_devices {
        get {
            return mic_devices;
        }

        set {
            mic_devices = value;
        }
    }

    public string Device {
        get {
            return device;
        }

        set {
            device = value;
        }
    }

    public List<MicrophoneReader> Mic_readers {
        get {
            return mic_readers;
        }

        set {
            mic_readers = value;
        }
    }
}
using UnityEngine;
using System.Collections;
using System;

public class MicInput : MonoBehaviour {

	public float MicLoudness;

	private string _device;
	private int deviceIndex = 0;
	private bool _isInitialized = false;
	//mic initialization
	public void InitMic(int index){
		if (_isInitialized) {
			StopMicrophone ();
		}
		deviceIndex = index;
		_device = Microphone.devices[index];
		_clipRecord = Microphone.Start(_device, true, 999, 44100);
		_isInitialized = true;
	}
	public void InitMicForPlay(int index){
		if (_isInitialized) {
			StopMicrophone ();
		}
		deviceIndex = index;
		_device = Microphone.devices[index];
		_clipRecord = Microphone.Start(_device, true, 1, 44100);
		_isInitialized = true;
	}
	public void StopMicrophone()
	{	
		Microphone.End(_device);
	}


	AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	//get data from microphone into audioclip
	public float  LevelMax()
	{
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		_clipRecord.GetData(waveData, 0);
		// Getting a peak on the last 128 samples
		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}
	public float  LevelMin()
	{
		float levelMax = 9999;
		float[] waveData = new float[_sampleWindow];
		_clipRecord.GetData(waveData, 0);
		// Getting a peak on the last 128 samples
		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax > wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}



	void Update()
	{
		// levelMax equals to the highest normalized value power 2, a small number because < 1
		// pass the value to a static var so we can access it from anywhere
		MicLoudness = LevelMax ();
	}

	void OnEnable()
	{
		
	}

	//stop mic when loading a new level or quit application
	void OnDisable()
	{
		StopMicrophone();
	}

	void OnDestroy()
	{
		StopMicrophone();
	}


	// make sure the mic gets started & stopped when application gets focused
	void OnApplicationFocus(bool focus) {
		if (focus)
		{
			//Debug.Log("Focus");

			if(!_isInitialized){
				//Debug.Log("Init Mic");

			}
		}      
		if (!focus)
		{
			//Debug.Log("Pause");
			StopMicrophone();
			//Debug.Log("Stop Mic");
			_isInitialized=false;

		}
	}
}

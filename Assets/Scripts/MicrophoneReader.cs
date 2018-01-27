using UnityEngine;
using System.Collections;

/**
 * Reads input from a single Microphone.
 */
public class MicrophoneReader{
    private string device;
    private AudioClip audioClip;
    private int volume; //from 0 to 100
    private bool playing = true;

    public const int MAX_VALUE = 30;

    public const int MIC_SEC_LENGTH = 1;
    private const int MIC_FREQ = 16000;
    public MicrophoneReader(string device) {
        this.device = device;
    }

    public IEnumerator UpdateVolume() {
        //updates the volume
        while (playing) {
			if (audioClip) {
				float[] samples = new float[audioClip.samples * audioClip.channels];
				audioClip.GetData(samples, 0);
				int volume = (int)(MeanVolume(samples) *100*100/MAX_VALUE);
				volume = System.Math.Abs(volume);
				this.volume = volume;
			}
			yield return new WaitForSeconds(0.1f);
        }
    }

    public float MeanVolume(float[] samples) {
        float mean = 0;
        foreach(float sample in samples) {
            mean += sample;
        }
        return mean / samples.Length;
    }

    public bool StartMicrophone() {
        audioClip = Microphone.Start(device, true, MIC_SEC_LENGTH, MIC_FREQ);
        return (audioClip != null);
    }

    public void StopMicrophone() {
        Microphone.End(device);
    }

    public int GetVolume() {
        return volume;
    }

    public string Device {
        get {
            return device;
        }
    }

}
using UnityEngine;
using System.Collections;

/**
 * Reads input from a single Microphone.
 */
public class MicrophoneReader {
    private string device;
    private AudioClip audioClip;
    private float volume; //from 0 to 1
    private int power;
    private bool active;
    private bool calibrating;

    private static float MAX_MULT = 143;

    public const int MIC_SEC_LENGTH = 1;
    private const int MIC_FREQ = 16000;
    public MicrophoneReader(string device) {
        this.device = device;
    }

    internal IEnumerator UpdateVolume() {
        //updates the volume
        while (active) {
            if (audioClip) {
                float[] samples = new float[audioClip.samples * audioClip.channels];
                audioClip.GetData(samples, 0);
                float volume = MeanVolume(samples);
                if (!calibrating) {
                    volume = (volume * MAX_MULT);
                }
                this.volume = volume;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    internal IEnumerator Calibrate(float seconds) {
        calibrating = true;
        StopMicrophone();
        StartMicrophone();
        Debug.Log("Speak as loud as you can");
        float high = 0;
        for (int x = 0; x < 10; x++) {
            float volume = Volume;
            Debug.Log(volume);
            if (volume > 1) {
                // - MAX_OFFSET) / MAX_MULT;
            } else {
                high += volume;
            }
            yield return new WaitForSeconds(seconds);
        }
        high /= 10;
        Debug.Log("High: " + high);
        Debug.Log("Stay Silent");
        float silent = 0;
        for (int x = 0; x < 10; x++) {
            silent += Volume;
            yield return new WaitForSeconds(seconds);
        }
        silent /= 10;
        Debug.Log("Silent: " + silent);
        MAX_MULT = 100 / (high - silent);
        //MAX_OFFSET = -MAX_MULT * silent;
        Debug.Log("Calibrated " + device);
        //Debug.Log(MAX_MULT + "," + MAX_OFFSET);
        calibrating = false;
    }

    internal float MeanVolume(float[] samples) {
        float mean = 0;
        foreach (float sample in samples) {
            mean += sample;
        }
        return mean / samples.Length;
    }

    internal bool StartMicrophone() {
        active = true;
        audioClip = Microphone.Start(device, true, MIC_SEC_LENGTH, MIC_FREQ);
        return (audioClip != null);
    }

    public void StopMicrophone() {
        active = false;
        Microphone.End(device);
    }

    public string Device {
        get {
            return device;
        }
    }

    public bool Active {
        get {
            return active;
        }

        set {
            active = value;
        }
    }

    public float Volume {
        get {
            return volume;
        }

        set {
            volume = value;
        }
    }

    public int Power {
        get {
            return power;
        }

        set {
            power = value;
        }
    }
    public static void setMaxValue(float max_value) {
        MAX_MULT = max_value;
    }
}
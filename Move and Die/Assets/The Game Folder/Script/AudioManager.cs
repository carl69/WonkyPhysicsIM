using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    [HideInInspector]
    public float Bass;
    void FixedUpdate()
    {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        Bass = spectrum[1];
    }
}

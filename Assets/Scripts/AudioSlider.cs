using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] AudioSource[] m_Source;
    [SerializeField] Slider slider;

    private void Start()
    {
        slider.value = 0.25f;
    }

    public void OnValueChanged()
    {
        foreach (var i in m_Source)
            i.volume = slider.value;
        SetFloat("SoundValue",slider.value);
            
    }
    public void SetFloat(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }
}

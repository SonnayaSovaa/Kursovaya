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
        slider.value = 0.5f;
    }

    public void OnValueChanged()
    {
        foreach (var i in m_Source)
            i.volume = slider.value;
    }
}

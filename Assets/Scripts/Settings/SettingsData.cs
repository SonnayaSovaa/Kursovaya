using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData : MonoBehaviour
{
    public GameObject Lev1;
    public GameObject Lev2;
    public GameObject Lev3;
    
    private void Awake()
    {
        int lev = GetLev("LevelDif");
        switch (lev)
        {
            case 0:
                Lev1.SetActive(true);
                break;
            case 1:
                Lev2.SetActive(true);
                break;
            case 2:
                Lev3.SetActive(true);
                break;
        }
    }

    public int GetLev(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    
    public float GetSound(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName);
    }
}

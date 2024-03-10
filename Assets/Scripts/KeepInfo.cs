using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInfo : MonoBehaviour
{
    public static KeepInfo Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

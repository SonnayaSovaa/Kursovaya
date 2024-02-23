using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Igrat()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void Vihod()
    {
        Application.Quit();
    }


    public void nastroyki()
    {
        //
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu_nastroek;
    bool vkl=false;
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
        vkl = !vkl;
        menu_nastroek.SetActive(vkl);
    }


}

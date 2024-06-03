using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    int igrok_umer;
    int boss_umer;
    int vrag_num;
    int score;
    float time;

    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text vragovubito;
    [SerializeField] TMP_Text scorer;
    [SerializeField] TMP_Text fintext;
    [SerializeField] TMP_Text state;


    string texttt ="";
    string endState = "";

    public AudioClip AudioClip;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        igrok_umer = PlayerPrefs.GetInt("Health");
        boss_umer = PlayerPrefs.GetInt("Boss_Dead");
        score = PlayerPrefs.GetInt("Score");
        vrag_num = PlayerPrefs.GetInt("Enemy_Dead");
        time = PlayerPrefs.GetFloat("Time");

        int LevelDif = PlayerPrefs.GetInt("LevelDif");

        int dopScore;

        int usingTime = Convert.ToInt32(time / 60);

        if (LevelDif == 0) dopScore=-Convert.ToInt32((usingTime*usingTime)/14)+300;
        else if (LevelDif == 1) dopScore = -Convert.ToInt32((usingTime * usingTime) / 10) + 400;
        else dopScore = -Convert.ToInt32((usingTime * usingTime) / 8) + 500;
        if (dopScore < 0) dopScore = 0;

        score += dopScore;


        if (igrok_umer <= 0 || score<1500)
        {
            endState = "���������";
        }
        else
        { 
           endState = "������";
        }

        if (igrok_umer <= 0)
        {
            texttt = "�� ������. � ��� �� ������. ���������� ������������� � ������� � ��������� ���.";
        }
        else
        {
            if (score < 1500)
                texttt = "���������� � ����������! ������ ��� �� ������� �����, ����� ������ � ��������� ����. ��������� ������������� � ������� � ��������� ���.";
            else
                texttt = "����������� � ������������ �������! �� ������� ���������� �����, ����� ������ � ��������� ����.";
        }


        timer.text = $"{Convert.ToInt32(time / 3600)}:{Convert.ToInt32(Math.Floor(time % 3600 / 60))}:{Convert.ToInt32(time % 60)}";
        vragovubito.text = $"{vrag_num}";
        scorer.text = $"{score}";
        fintext.text = texttt;
        state.text = endState;

    }

    public void ToMenu()
    {
        Application.Quit();
        SceneManager.LoadScene("Menu");
    }

    public void Vihod()
    {
        audioSource.PlayOneShot(AudioClip);
        Application.Quit();

    }


}

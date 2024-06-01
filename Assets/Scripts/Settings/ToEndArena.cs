using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndArena : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = FindObjectOfType<Player>();

        player.loading.SetActive(true);

        PlayerPrefs.SetInt("Score", player.score);
        PlayerPrefs.SetInt("Health", player.currhealth);
        PlayerPrefs.SetFloat("Time", player.time);

        SceneManager.LoadSceneAsync("TheEnd");
    }
}

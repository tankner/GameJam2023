using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer myPlayer;
    public void StartGame() {
        StartCoroutine(VideoAndStart());
    }

    IEnumerator VideoAndStart()
    {
        myPlayer.Play();
        yield return new WaitForSeconds(10);
        Destroy(myPlayer.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

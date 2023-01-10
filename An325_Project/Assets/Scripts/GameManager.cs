using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool IsWin;
    public bool IsGameOver;
    public TMP_Text gameOverText;
    public TMP_Text PressFText;
    public TMP_Text ThxForPlayingText;
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");

    }
    public void QuitgameButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Quitgame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
    public void Win()
    {
        IsWin = true;
        ThxForPlayingText.gameObject.SetActive(true);
        StartCoroutine(Press(0.3f));
    }
    public void GameOver()
    {
        IsGameOver = true;
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(Press(0.3f));
    }
    IEnumerator Press(float secPress)
    {
        yield return new WaitForSeconds(secPress);
        PressFText.gameObject.SetActive(true);

    }
    void Update()
    {
        if (IsWin && Input.GetKeyDown(KeyCode.F) || IsGameOver && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Menu");
        }

        if (IsGameOver && Input.GetKeyDown(KeyCode.F) || IsGameOver && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

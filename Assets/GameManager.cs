using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public GameObject winningUI;
    public GameObject losingUI;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Error");
        } else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Point").GetComponent<TextMeshProUGUI>().text != null)
        GameObject.FindGameObjectWithTag("Point").GetComponent<TextMeshProUGUI>().text = player.point.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        winningUI.SetActive(true);
    }

    public void LoseGame()
    {
        losingUI.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

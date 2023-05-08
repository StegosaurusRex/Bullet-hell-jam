using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    PlayerHP playerHP;
    PlaneHP planeHP;
    BossHP bossHP;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject crosshair;
    public float timeToDeath;
    public float timeToWin;
    public GameObject pauseMenuUIGameOver;
    public GameObject pauseMenuUIWinGame;
    private void Start()
    {
        playerHP = GameObject.FindObjectOfType<PlayerHP>();
        planeHP = GameObject.FindObjectOfType<PlaneHP>();
        bossHP = GameObject.FindObjectOfType<BossHP>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (playerHP.hp<=0)
        {
            PauseGameOver();
        }
        if (planeHP.hp<=0)
        {
            PauseGameOver();
        }
        if (bossHP.hp<=0)
        {
           PauseWinGame();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        crosshair.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = false;
        GameIsPaused = false;


    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;


    }
    public void PauseGameOver()
    {

        StartCoroutine(WaitingBeforeDead());

    }
    public void PauseWinGame()
    {
        StartCoroutine(WaitingBeforeWin());


    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Resume();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitingBeforeDead()
    {
        
        yield return new WaitForSeconds(timeToDeath);
        pauseMenuUIGameOver.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    IEnumerator WaitingBeforeWin()
    {
        
        yield return new WaitForSeconds(timeToWin);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        SceneManager.LoadScene(2);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject GameOverScreen;
    public GameObject PauseMenu;
    private GameManager gameManager;

    //Buttons
    public GameObject pause;

    public Text highScore;

    private AudioSource audioSource;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        highScore.text = gameManager.HighScore.ToString();
    }

    public void showGameOverScreen()
    {
        pause.SetActive(false);
        GameOverScreen.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void hideGameOverScreen()
    {
        pause.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene("Level 01");
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void showPauseMenu()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        gameManager.IsPaused = true;
        PauseMenu.SetActive(true);
        audioSource.Play();
    }

    public void hidePauseMenu()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        gameManager.IsPaused = false;
        PauseMenu.SetActive(false);
        audioSource.Play();
    }

    public void MainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }
   
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject GameOverScreen;
    public GameObject PauseMenu;
    public GameManager gameManager;
    public GameObject pauseBtn;

    public Text highScore;

    private void Update()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        highScore.text = gameManager.highScore.text.ToString();
    }

    public void showGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        pauseBtn.GetComponent<Button>().interactable = false;
    }

    public void hideGameOverScreen()
    {
        GameOverScreen.SetActive(false);
        pauseBtn.GetComponent<Button>().interactable = true;
    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene("Level 01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void showPauseMenu()
    {
        Time.timeScale = 0;
        gameManager.IsPaused = true;
        PauseMenu.SetActive(true);
    }

    public void hidePauseMenu()
    {
        Time.timeScale = 1;
        gameManager.IsPaused = false;
        PauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

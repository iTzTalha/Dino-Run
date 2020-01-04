using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private BackgroundElement[] backgroundElements;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.move();
        }
    }

    public void tapToStart()
    {
        SceneManager.LoadScene("Selection");
    }
}

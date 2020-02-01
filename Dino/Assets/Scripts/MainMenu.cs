using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private BackgroundElement[] backgroundElements;

    Animator animator;
    public Image FadeImage;

    public Text hiScore;

    private void Start()
    {
        Time.timeScale = 1;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.move();
        }

        hiScore.text = PlayerPrefs.GetInt("HighScore0").ToString();
    }

    public void tapToStart()
    {
        StartCoroutine(Fading());
        SceneManager.LoadScene("Selection");
    }


    IEnumerator Fading()
    {
        animator.SetBool("FadeOut", true);
        yield return new WaitUntil(() => FadeImage.color.a == 1);
    }

}

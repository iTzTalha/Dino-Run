using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour
{

    [SerializeField] private bool unlocked;//Default value is false;
    public Image lockedImage, unlockedImage;

    public Animator animator;
    public Image FadeImage;

    public AudioSource audioSource;

    public int unlockScore;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();   
    }

    private void Update()
    {
        UpdateLevelImage();//TODO MOve this method later
        UpdateLevelStatus();//TODO MOve this method later
    }

    private void UpdateLevelStatus()
    {
        //if the current lv is 5, the pre should be 4
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > unlockScore)//If the firts level star is bigger than 0, second level can play
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            lockedImage.gameObject.SetActive(true);
            unlockedImage.gameObject.SetActive(false);
        }
        else//if unlock is true means This level can play !
        {
            lockedImage.gameObject.SetActive(false);
            unlockedImage.gameObject.SetActive(true);
        }
    }

    public void SelectLevel (string levelName)//When we press this level, we can move to the corresponding Scene to play
    {
        if (unlocked)
            // animator.SetBool("FadeOut", true);
            StartCoroutine(Fading());
            SceneManager.LoadScene(levelName);
    }

    IEnumerator Fading()
    {
        audioSource.Play();
        animator.SetBool("FadeOut", true);
        yield return new WaitUntil(() => FadeImage.color.a == 1);
    }
}

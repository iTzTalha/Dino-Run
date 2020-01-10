using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    [SerializeField] private bool unlocked;//Default value is false;
    public Image unlockImage;

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
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > 3 )//If the firts level star is bigger than 0, second level can play
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            unlockImage.gameObject.SetActive(true);
        }
        else//if unlock is true means This level can play !
        {
            unlockImage.gameObject.SetActive(false);        
        }
    }

    public void SelectLevel (string levelName)//When we press this level, we can move to the corresponding Scene to play
    {
        if (unlocked)
        {
            SceneManager.LoadScene(levelName);
        }
    }

}

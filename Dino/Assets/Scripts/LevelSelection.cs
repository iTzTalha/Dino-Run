using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

   public void SelectLevel (string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}

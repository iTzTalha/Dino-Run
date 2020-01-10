using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    private int currentScore = 0;
    public int levelIndex;

    public void PressStarsButton(int _starsScore)
    {
        currentScore = _starsScore;

        if(currentScore > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsScore);
        }

        //BackButton();
        //MARKER Each level has saved their own stars number
        //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsScore));
    }

}

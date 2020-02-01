using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlock : MonoBehaviour
{
    [SerializeField] private bool unlocked;//Default value is false;
    public GameObject unlockObject;

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerObject();//TODO MOve this method later
        UpdatePlayerStatus();//TODO MOve this method later
    }

    private void UpdatePlayerObject()
    {
        if (!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            unlockObject.gameObject.SetActive(true);
        }
        else//if unlock is true means This level can play !
        {
            unlockObject.gameObject.SetActive(false);
        }
    }

    private void UpdatePlayerStatus()
    {
        //if the current lv is 5, the pre should be 4
        // int previousCharacterNum = int.Parse(gameObject.name) - 1;
        int previousCharacterNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("chr" + previousCharacterNum.ToString()) > 1000)//If the firts level star is bigger than 0, second level can play
        {
            unlocked = true;
        }
    }
}

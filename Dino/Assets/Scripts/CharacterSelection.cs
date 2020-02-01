using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] _charaterList;
    private int index;

    public GameObject LevelSelectionPanel;
    public GameObject CharacterSelectionPanel;
    public GameObject CreditPanel;

    public GameObject Btn_About;
    public GameObject Btn_Lvl;
    public GameObject Btn_Hero;
    public GameObject Btn_Back;
    public GameObject HiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //index = PlayerPrefs.GetInt("CharacterSelected");

        _charaterList = new GameObject[transform.childCount];

        for(int i=0; i< transform.childCount; i++)
        {
            _charaterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject gameObject in _charaterList)
        {
            gameObject.SetActive(false);
        }

        if (_charaterList[index])
        {
            _charaterList[index].SetActive(true);
        }
     
    }
 
    public void LeftCharacters()
    {
        _charaterList[index].SetActive(false);

        index--;

        if(index < 0)
        {
            index = _charaterList.Length - 1;
        }

        _charaterList[index].SetActive(true);
    }
    public void RightCharacters()
    {

        _charaterList[index].SetActive(false);

        index++;

        if (index == _charaterList.Length)
        {
            index = 0;
        }

        _charaterList[index].SetActive(true);
    }
    public void CharacterSelected()
    {

        PlayerPrefs.SetInt("CharacterSelected", index);

        LevelSelectionPanel.SetActive(true);
        CharacterSelectionPanel.SetActive(false);
    }
    public void LevelSelected()
    {
        LevelSelectionPanel.SetActive(true);
        CharacterSelectionPanel.SetActive(false); 
    }
    public void HeroSelected()
    {    
        CharacterSelectionPanel.SetActive(true);
        LevelSelectionPanel.SetActive(false);
    }
    public void About()
    {
        LevelSelectionPanel.SetActive(false);
        CharacterSelectionPanel.SetActive(false);
        CreditPanel.SetActive(true);
        Btn_About.SetActive(false);
        Btn_Lvl.SetActive(false);
        Btn_Hero.SetActive(false);
        Btn_Back.SetActive(true);
        HiScoreText.SetActive(false);
    }
    public void ExitCredits()
    {
        CreditPanel.SetActive(false);
        Btn_About.SetActive(true);
        LevelSelectionPanel.SetActive(true);
        CharacterSelectionPanel.SetActive(false);
        Btn_Lvl.SetActive(true);
        Btn_Hero.SetActive(true);
        Btn_Back.SetActive(false);
        HiScoreText.SetActive(true);
    }
}

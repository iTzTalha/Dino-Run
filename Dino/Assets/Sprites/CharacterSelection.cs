using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] _charaterList;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

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
        SceneManager.LoadScene("Sunny Land");
    }
}

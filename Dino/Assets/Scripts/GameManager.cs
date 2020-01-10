using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BackgroundElement[] backgroundElements;
    [SerializeField] private GameObject[] _Player;
    [SerializeField] private GameObject[] _Enemies;
    [SerializeField] private Transform enemieSpawnPoint;
    int getCharacter;
    private PlayerController player;
    public int levelIndex;

    //SpawnManager
    float timeBtwSpawn;
    public float startTimeBtwSpawn = 3f;
    public float decreaseTime = 0.05f;
    public float minTime = 1f;

    //UI 
    public Text currentScore;
    public Text highScore;
    int Score = 0;
    private UIManager _uIManager;
    public bool IsPaused { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        highScore.text = PlayerPrefs.GetInt("HighScore0", 0).ToString();

        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        SpwanPlayer();

        foreach (GameObject element in _Enemies)
        {
            element.GetComponent<ObstacleControl>().moveSpeed = -5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (!player.IsDead && !IsPaused)
            {
                Score++;
                currentScore.text = Score.ToString();

                if (Score > PlayerPrefs.GetInt("HighScore0", 0))
                {
                    PlayerPrefs.SetInt("HighScore0", Score);
                    highScore.text = PlayerPrefs.GetInt("HighScore0").ToString();

                }

                foreach (BackgroundElement element in backgroundElements)
                {
                    element.move();
                }

                if (Score == 1000)
                {
                    saveScoreForNextLevel();
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -6f;
                    }
                }
                if (Score >= 2000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -7f;
                    }
                }
                if (Score == 3000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -8f;
                    }
                }
                if (Score == 4000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -9f;
                    }
                }
                if (Score == 5000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -10f;
                    }
                }
                if (Score == 7000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -11f;
                    }
                }
                if (Score == 9000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -12f;
                    }
                }
                if (Score == 10000)
                {
                    foreach (GameObject element in _Enemies)
                    {
                        element.GetComponent<ObstacleControl>().moveSpeed = -13f;
                    }
                }
            }

        if (player.IsDead)
        {
            _uIManager.showGameOverScreen();
        }

        //Spawn Enemies
        if (timeBtwSpawn <= 0)
        {
            SpawnObstacle();
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    void SpwanPlayer()
    {
        getCharacter = PlayerPrefs.GetInt("CharacterSelected");

        switch (getCharacter)
        {
            case 0:
                Instantiate(_Player[0], new Vector3(-6, -2, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(_Player[1], new Vector3(-6, -2, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(_Player[2], new Vector3(-6, -2, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(_Player[3], new Vector3(-6, -2, 0), Quaternion.identity);
                break;  
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        /*
        foreach (GameObject child in _Player)
        {
            player = child.GetComponent<PlayerController>();
        }*/
    }

    void SpawnObstacle()
    {
       // nextSpawn = Time.time + spawnRate;
        int randomObstacle = Random.Range(0, _Enemies.Length);
        Instantiate(_Enemies[randomObstacle], enemieSpawnPoint.position, Quaternion.identity);

        timeBtwSpawn = startTimeBtwSpawn;

        if (startTimeBtwSpawn > minTime)
        {
            startTimeBtwSpawn -= decreaseTime;
        }
        
    }

    private void saveScoreForNextLevel()
    {

        PlayerPrefs.SetInt("Lv" + levelIndex, Score);

        //Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, Score));
        //BackButton();
        //MARKER Each level has saved their own stars number
        //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE   
    }
}

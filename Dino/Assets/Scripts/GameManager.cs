using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BackgroundElement[] backgroundElements;
    [SerializeField] private GameObject[] _Player;
    [SerializeField] private GameObject[] _Enemies;
    [SerializeField] private Transform enemieSpawnPoint;
    [SerializeField] private Transform playerSpawnPoint;
    int getCharacter;
    private PlayerController player;
    public int levelIndex;

    AudioSource audioSource;

    //SpawnManager
    float timeBtwSpawn;
    public float startTimeBtwSpawn = 3f;
    public float decreaseTime = 0.05f;
    public float minTime = 1f;

    //UI 
    public Text currentScore;
    private int highScore;
    public int HighScore { get => highScore; set => highScore = value; }
    int Score = 0;
    bool scorePlaying;
    private UIManager _uIManager;
    public bool IsPaused { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        SpwanPlayer();

        HighScore = PlayerPrefs.GetInt("HighScore0", 0);

        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        foreach (GameObject element in _Enemies)
        {
            element.GetComponent<ObstacleControl>().moveSpeed = -5f;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
            if (!player.IsDead && !IsPaused)
            {
                 scorePlaying = true;
                 saveScoreForNextLevel();               
                 currentScore.text = Score.ToString();

                if (Score > PlayerPrefs.GetInt("HighScore0", 0))
                {
                    PlayerPrefs.SetInt("HighScore0", Score);
                    HighScore = PlayerPrefs.GetInt("HighScore0");

                }

                foreach (BackgroundElement element in backgroundElements)
                {
                    element.move();
                }
           
            foreach (GameObject element in _Enemies)
            {
                switch (Score)
                {
                    case 0:
                        element.GetComponent<ObstacleControl>().moveSpeed = -6f;
                        break;
                    case 1000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -8f;
                        break;
                    case 2000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -10f;
                        break;
                    case 3000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -12f;
                        break;
                    case 4000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -14f;
                        break;
                    case 5000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -16f;
                        break;
                    case 6000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -17f;
                        break;
                    case 7000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -18f;
                        break;
                    case 8000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -19f;
                        break;
                    case 9000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -20f;
                        break;
                    case 10000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -21f;
                        break;
                    case 15000:
                        element.GetComponent<ObstacleControl>().moveSpeed = -22f;
                        break;
                }
            }
        }

        if (player.IsDead)
        {
            audioSource.Stop();
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

    private void FixedUpdate()
    {
        if (scorePlaying)
        {
            Score++;
        }
    }
    void SpwanPlayer()
    {
        getCharacter = PlayerPrefs.GetInt("CharacterSelected");

        switch (getCharacter)
        {
            case 0:
                Instantiate(_Player[0], playerSpawnPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(_Player[1], playerSpawnPoint.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(_Player[2], playerSpawnPoint.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(_Player[3], playerSpawnPoint.position, Quaternion.identity);
                break;
            default:
                Instantiate(_Player[0], playerSpawnPoint.position, Quaternion.identity);
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
        Instantiate(_Enemies[randomObstacle], new Vector3(Random.Range(enemieSpawnPoint.position.x, 20f), Random.Range(-2f, 3f), enemieSpawnPoint.position.z), Quaternion.identity);

        timeBtwSpawn = startTimeBtwSpawn;

        if (startTimeBtwSpawn > minTime)
        {
            startTimeBtwSpawn -= decreaseTime;
        }    
    }

    private void saveScoreForNextLevel()
    {

        if(Score > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, Score);
        }
        //Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, Score));
        //BackButton();
        //MARKER Each level has saved their own stars number
        //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE   
    }

}

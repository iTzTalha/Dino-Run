using UnityEngine.SceneManagement;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private static BGMusic instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
      
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex > 1)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityADS : MonoBehaviour
{

    private static UnityADS instance;
#if UNITY_IOS
    private string gameId = "3446226";
#elif UNITY_ANDROID
    private string gameId = "3446227";
#endif
    string BannerID = "DinoBannerADS";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, false);
        StartCoroutine(DisplayADS()); 
    }

    IEnumerator DisplayADS()
    {
        while (!Advertisement.IsReady(BannerID))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(BannerID);      
    }
}

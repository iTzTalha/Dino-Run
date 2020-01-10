using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scroll : MonoBehaviour 
{
    [Header("Select amount of your objects")]
    [Range(1, 100)]
    public int amount;
    [Header("Select smooth speed")]
    [Range(0.05f, 0.5f)]
    public float smoothSpeed;

    [Header("Select distance between objects")]
    [Range(5, 20)]
    public int distance;

    [Header("Select names for your objects")]
    public string[] names;
	public GameObject[] obj;
    private GameObject[] instatiatedObj;
    private Vector2[] points;
    public GameObject parentScroll;
    public Text characterName;
    private float smoothedX, smoothedScale;
    private Vector3[] defaultScale, bigScale;
    
    void Start()
    {
        instatiatedObj = new GameObject[amount];
        points = new Vector2[amount + 1];
        defaultScale = new Vector3[amount];
        bigScale = new Vector3[amount];
        for(int i = 0; i < amount; i++)
        { 
            if(i == 0) instatiatedObj[i] = Instantiate(obj[i], new Vector3(0, parentScroll.transform.position.y, 70), Quaternion.identity);
            if(i != 0) instatiatedObj[i] = Instantiate(obj[i], new Vector3(instatiatedObj[i-1].transform.position.x + distance,
                    instatiatedObj[i-1].transform.position.y, instatiatedObj[i-1].transform.position.z), Quaternion.identity);
            instatiatedObj[i].transform.parent = parentScroll.transform;
            defaultScale[i] = new Vector3(instatiatedObj[i].transform.localScale.x - 25, instatiatedObj[i].transform.localScale.y - 25, instatiatedObj[i].transform.localScale.z - 25);
            bigScale[i] = new Vector3(instatiatedObj[i].transform.localScale.x + 10, instatiatedObj[i].transform.localScale.y + 10, instatiatedObj[i].transform.localScale.z + 10);
        }
        for(int y = 0; y < amount + 1; y++)
        {
            if(y == 0) points[y] = new Vector2(parentScroll.transform.position.x + distance / 2, parentScroll.transform.position.y);
            if(y != 0) points[y] = new Vector2(points[y-1].x - distance, parentScroll.transform.position.y);
        }
        
    }

    void Update()
    {
        try
        {
            for(int i = 0; i < amount; i++)
            {
               instatiatedObj[i].transform.Rotate(0, 1, 0); 
               if(parentScroll.transform.position.x < points[i].x && parentScroll.transform.position.x > points[i+1].x)
               {
                   smoothedX = Mathf.SmoothStep(parentScroll.transform.position.x, points[i].x - distance / 2, smoothSpeed);
                   smoothedScale = Mathf.SmoothStep(bigScale[i].x, defaultScale[i].x, smoothSpeed);
                   characterName.text = names[i];
               }
               else smoothedScale = Mathf.SmoothStep(defaultScale[i].x, bigScale[i].x, smoothSpeed);
               instatiatedObj[i].transform.localScale = new Vector3(smoothedScale, smoothedScale, smoothedScale);
            }
        }
        catch
        {
        }
        parentScroll.transform.position = new Vector2(smoothedX, parentScroll.transform.position.y);
    }
    public void ButtonClick()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "Buy") // CODE FOR "BUY" BUTTON
        {
            print("buy");
            // WRITE HERE
        }
        if(EventSystem.current.currentSelectedGameObject.name == "Select") // CODE FOR "SELECT" BUTTON
        {
            print("select");
            // WRITE HERE
        }
    }
}

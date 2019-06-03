using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour {
    public GameObject Quit;
    public GameObject Restart;
    readonly float LeftX = -3.26f;
    readonly float RightX = 3.476529f;
    readonly float FloorY = -1.89f; 
    readonly float TopY = 2.322461f;
    public float time;
    public float timetemp;
    public Text timeText;
    public static background Instance;
	// Use this for initialization
	void Start () {
        Instance = this;
        Quit.SetActive(false);
        Restart.SetActive(false);
	}
	int choose()
    {
        return Random.Range(0, 3);
    }
    float NewX()
    {
        return Random.Range(LeftX, RightX);
    }
    float NewY()
    {
        return Random.Range(FloorY, TopY);
    }
    void CreatMonkey()
    {
        GameObject newone = Instantiate(Resources.Load<GameObject>("monkey"));
        int mode = choose();
        switch (mode)
        {
            case 0:
                newone.transform.position = new Vector3(LeftX, NewY(), 0);
                break;
            case 1:
                newone.transform.position = new Vector3(RightX, NewY(), 0);
                break;
            case 2:
                newone.transform.position = new Vector3(NewX(), TopY, 0);
                break;
            case 3:
                newone.transform.position = new Vector3(NewX(), FloorY, 0);
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timetemp += Time.deltaTime;
        if (timetemp > 5f)
        {
            CreatMonkey();
            timetemp = 0f;
        }
        timeText.text = "Time: " + time;
	}

    public void Gameover()
    {
        Quit.SetActive(true);
        Restart.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

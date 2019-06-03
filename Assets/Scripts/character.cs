using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour {
    public float time;
    public float LeftX = -3.26f;
    public float RightX = 3.476529f;
    public float FloorY = -1.89f;
    public float TopY = 2.322461f;
    public int blood = 100;
    public Text btext;
    public bool exist = false;
    // Use this for initialization
    void Start () {
		
	}

    void skill()
    {
        GameObject newone = Instantiate(Resources.Load<GameObject>("Circle"));
        newone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }

    GameObject newone;

    void skillOn()
    {
        newone = Instantiate(Resources.Load<GameObject>("Diamond"));
        newone.transform.position = new Vector3(-3f, -3f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (!exist)
        {
            if (time > 10f)
            {
                skillOn();
                exist = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {  
            if(gameObject.transform.position.x < RightX)
            {
                gameObject.transform.position += new Vector3(0.05f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LeftX)
            {
                gameObject.transform.position -= new Vector3(0.05f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gameObject.transform.position.y < TopY)
            {
                gameObject.transform.position += new Vector3(0, 0.05f, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (gameObject.transform.position.y > FloorY)
            {
                gameObject.transform.position -= new Vector3(0, 0.05f, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (exist)
            {
                skill();
                Destroy(newone.gameObject);
                time = 0f;
                exist = false;
            }
        }
        btext.text = "Blood: " + blood;
        if (blood <= 0f)
        {
            Destroy(gameObject);
            background.Instance.Gameover();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "stone")
        {
            blood -= 10;
            Destroy(col.gameObject);
        }
    }
}

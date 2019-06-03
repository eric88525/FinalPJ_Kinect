using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stones : MonoBehaviour {
    public float moveX;
    public float moveY;
    public float flyspeed;
    // Use this for initialization
    void Start () {
        fly();
    }

    void fly()
    {
        moveX = GameObject.Find("ch").transform.position.x - gameObject.transform.position.x;
        moveY = GameObject.Find("ch").transform.position.y - gameObject.transform.position.y;
        flyspeed = speed();
    }
    // Update is called once per frame
    float speed()
    {
        return Random.Range(0.002f, 0.01f);
    }
    void Update()
    {
        gameObject.transform.position += new Vector3(moveX * flyspeed, moveY  * flyspeed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ch" || col.tag == "Circle")
        {
            Destroy(col.gameObject);
        }
    }
}

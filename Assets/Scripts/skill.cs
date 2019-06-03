using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 1f)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "stone" || collision.tag == "monkey")
        {
            Destroy(collision.gameObject);
        }
    }
}

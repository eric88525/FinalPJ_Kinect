using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
    public float time3;
    // Use this for initialization
    void Start () {
		
	}
	void Monkeyattack()
    {
        GameObject stone = Instantiate(Resources.Load<GameObject>("stone"));
        stone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }

	// Update is called once per frame
	void Update () {
        time3 += Time.deltaTime;
        if (time3 > 5f)
        {
            Monkeyattack();
            time3 = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Circle")
        {
            Destroy(gameObject);
        }
    }
}

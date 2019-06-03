using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject startScreen;
	public string outTrigger;
	private List<GameObject> screenHistory;

  
	void Awake()
	{
        this.screenHistory = new List<GameObject> { this.startScreen };
        Debug.Log("AWAKE");
	}

	public void ToScreen(GameObject target)
	{
        GameObject current = this.screenHistory[this.screenHistory.Count - 1];
        if (target == null || target == current) return;

        this.PlayScreen(current, target, false, this.screenHistory.Count);
        this.screenHistory.Add(target);
        Debug.Log(this.screenHistory.Count);
    }

	public void GoBack()
	{
        Debug.Log(this.screenHistory.Count);
        if(this.screenHistory.Count > 1)
        {
            int currentIndex = this.screenHistory.Count - 1;
            this.PlayScreen(this.screenHistory[currentIndex], this.screenHistory[currentIndex - 1], true, currentIndex - 2);
            this.screenHistory.RemoveAt(currentIndex);
            Debug.Log("remove at");
        }
    }

    public void GameExit()
    {
        Debug.Log("GameExit");
        Application.Quit();
    }

    private void PlayScreen(GameObject current, GameObject target, bool isBack, int Order)
    {
        
        current.GetComponent<Animator>().SetTrigger(this.outTrigger);
        if(isBack)
        {
            current.GetComponent<Canvas>().sortingOrder = Order;
        }
        else
        {
            current.GetComponent<Canvas>().sortingOrder = Order - 1;
            target.GetComponent<Canvas>().sortingOrder = Order;
        }
        target.SetActive(true);
        Debug.Log(this.screenHistory.Count);
    }

}

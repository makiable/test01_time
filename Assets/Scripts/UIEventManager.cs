using UnityEngine;
using System.Collections;

public class UIEventManager : MonoBehaviour {

    public GameObject UI_MainPage;
    public GameObject UI_ScrollPage;


	// Use this for initialization
	void Start () {

        UI_MainPage.SetActive(true);
        UI_ScrollPage.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openScrollpage() 
    {
        UI_MainPage.SetActive(false);
        UI_ScrollPage.SetActive(true);
    }

    public void closeScrollpage() 
    {
        UI_MainPage.SetActive(true);
        UI_ScrollPage.SetActive(false);
    }
    
}

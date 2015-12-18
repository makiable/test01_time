using UnityEngine;
using System.Collections;

public class UIEventManager : MonoBehaviour {

    public GameObject UI_Bottom_Bar;
    public GameObject UI_ScrollPage_C;
    public GameObject UI_ScrollPage_Shop;
    public int UI_ScrollPageChcker; // 0 = 스크롤, 1 =  shop, 2 = etc


	// Use this for initialization
	void Start () {

        UI_Bottom_Bar.SetActive(true);
        UI_ScrollPage_C.SetActive(true);
        UI_ScrollPage_Shop.SetActive(false);

        UI_ScrollPageChcker = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openScrollpage(int tempint) 
    {
        switch (tempint)
        {
        case 0:
             UI_ScrollPage_C.SetActive(true);
             UI_ScrollPage_Shop.SetActive(false);
            break;

        case 1:
             UI_ScrollPage_C.SetActive(false);
             UI_ScrollPage_Shop.SetActive(true);
            break;

        default:
             UI_ScrollPage_C.SetActive(false);
             UI_ScrollPage_Shop.SetActive(false);
            break;
        }
    }
}

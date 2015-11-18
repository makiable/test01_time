using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {
    	
	//최상단 시간.
    private DateTime Maintime2;

	public Text SystemTime;

	public Text SpendTime;

	public Text totalgold;

    public float deltaTimeCheck = 0;

	public float NumberTotalGold = 0;



	



	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
        
		Maintime2 = System.DateTime.Now;

		SystemTime.text = Maintime2.ToString ();

        deltaTimeCheck += Time.deltaTime;

        SpendTime.text = deltaTimeCheck.ToString();

 
	}


}

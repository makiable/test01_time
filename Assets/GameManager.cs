using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

	//버튼 객체.
	public Funtion01_MoneyIncrese mFuntion_Button01;
	
	//최상단 시간.
	private DateTime Maintime;
	private DateTime Maintime2;

	public Text SystemTime;
	public Text SpendTime;

	public DateTime addedTime;

	//[11/11/2015 tgboys] // 시간 비교 후 결과 값을 위한 구조체.
	private enum DateComparisonResult
	{
		Earlier = -1,
		Later = 1,
		TheSame = 0
	};
	
	//평션1 시간이 흐를 때마다 돈을 획득, 맥스값이 있음.

	public Text totalgold;
	public float NumberTotalGold = 0;



	public float checkFlowTime; 

	public Button basic02;
	public Text text02;
	private float timer02;
	public float Max02;

	private float BasicTime01;
	
	//펑션2

	public Text Funtion2gold;
	private float Funtion2Gold_number;


	public Button funtion02_Button01;
	public Text funtion02_Buttion01_text;
	public float funtion02_button01_WaitTime;
	public float funtion02_button01_Gold = 100;
	public DateTime funtion02_Time;

	public Button funtion02_Button02;
	public Text funtion02_Buttion02_text;



	// Use this for initialization
	void Start () 
	{
		//[11/11/2015 tgboys] // 펑션 2를 위한 글로벌 타임 세팅과 펑션2의 시간 세팅. 추후에는 리스트로 만들어서 체크 해야함.
		//Maintime = System.DateTime.Now;
		//Debug.Log ("maintime is "+Maintime);

		//펑션2가 눌러서 수확을 하면, 지금 시간기준으로 얼마나 기다려야 되는지 확인.
		//여기서는 Start할때 넣어주지만, 나중엔 리스트에서 불렁오면 됨. 시작시에.
		funtion02_Time = Maintime.AddMinutes (funtion02_button01_WaitTime); //30초 추가.
		//Debug.Log ("mainTime is " + Maintime + " // funtion02_time is " + funtion02_Time);

	}
	
	// Update is called once per frame
	void Update () 
	{
		Maintime2 = System.DateTime.Now;

		SystemTime.text = Maintime2.ToString ();



		//여기는 2번 기능에 대한 내용.

		if (funtion02_button01_WaitTime > 0) {

			funtion02_Button01.interactable = false;

		}

		else if (funtion02_button01_WaitTime < 0) {

			funtion02_Buttion01_text.text = "Ready";

			funtion02_Button01.interactable = true;
		}


		DateComparisonResult comparison_Funtion02;

		comparison_Funtion02 = (DateComparisonResult)funtion02_Time.CompareTo (Maintime); //Funtion2랑 현재시간이랑 비교.

		//Debug.Log ("Comparision is " + comparison_Funtion02 +"....F2 Time is " + funtion02_Time + "main Time is " + Maintime );

		if (comparison_Funtion02 > 0) {
			
			funtion02_Button01.interactable = false;
			
		}
		
		else if (comparison_Funtion02 < 0) {
			
			funtion02_Buttion01_text.text = "Ready";
			
			funtion02_Button01.interactable = true;
		}



	}


	public void GetGoldButton02()
	{
		float a;
		a = timer02;
		
		NumberTotalGold += a;
		totalgold.text = NumberTotalGold.ToString ("N2");
		timer02 = 0;
		
		Debug.Log (totalgold.text);
		Debug.Log ("Clicked");
		
	}
	

	public void GetGoldFuntion2()
	{
		Funtion2Gold_number += funtion02_button01_Gold;

		//시간 찍기.

		funtion02_Time = Maintime.AddMinutes (funtion02_button01_WaitTime);

		Funtion2gold.text = Funtion2Gold_number.ToString ("N2");

		funtion02_Button01.interactable = false;

	}


}

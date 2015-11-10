using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	private long Maintime;


	//평션1
	public Button basic01;
	public Text text01;
	private float timer01;
	public float Max01;

	public Button basic02;
	public Text text02;
	private float timer02;
	public float Max02;
	
	public Text BasicTime01_text;
	private float BasicTime01;

	public Text totalgold;
	private float NumberTotalGold = 0;

	//펑션2

	public Text Funtion2gold;
	private float Funtion2Gold_number;
	public Text funtion2_Time;
	private float BasicTime02;

	public Button funtion02_Button01;
	public Text funtion02_Buttion01_text;
	public float funtion02_button01_WaitTime;
	public float funtion02_button01_Gold = 100;


	public Button funtion02_Button02;
	public Text funtion02_Buttion02_text;
	//public float funtion02_button02_Gold;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//일반적인 시간의 흐름
		//Debug.Log (Time.deltaTime);

		//시간 관련 TEST
		//Debug.Log("1 -> " + System.DateTime.UtcNow); //세계 협정시
		//Debug.Log("2 -> " +System.DateTime.Now); //로컬 시

		Maintime = System.DateTime.UtcNow.ToBinary ();


		//여기는 1번 기능에 대한 내용.
		BasicTime01 += Time.deltaTime;

		if (timer01 <= Max01) 
		{
			timer01 += Time.deltaTime;
		} 
		else 
		{
			timer01 = Max01;
		}

		if (timer02 <= Max02) 
		{
			timer02 += Time.deltaTime;
		} 
		else 
		{
			timer02 = Max02;
		}

		text01.text = "Time:" + timer01.ToString ("N2");

		text02.text = "Time:" + timer02.ToString ("N2");

		BasicTime01_text.text = "Time:" + BasicTime01.ToString ("N0");

		//여기는 2번 기능에 대한 내용.
		//BasicTime02 = Time.deltaTime;

		funtion02_button01_WaitTime -= Time.deltaTime;

		if (funtion02_button01_WaitTime > 0) {

			funtion02_Button01.interactable = false;

		}

		else if (funtion02_button01_WaitTime < 0) {

			funtion02_Buttion01_text.text = "Ready";

			funtion02_Button01.interactable = true;
		}


	}

	public void GetGoldButton01()
	{
		float a;
		a = timer01;

		NumberTotalGold += a;
		totalgold.text = NumberTotalGold.ToString ("N2");
		timer01 = 0;

		Debug.Log (totalgold.text);
		Debug.Log ("Clicked");

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

		BasicTime02 = 0;

		funtion02_button01_WaitTime = 5;

		Funtion2gold.text = Funtion2Gold_number.ToString ("N2");

		funtion02_Button01.interactable = false;

	}


}

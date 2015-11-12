using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Funtion01_MoneyIncrese : MonoBehaviour {


	public GameManager mGameManager;


	//[11/11/2015 tgboys]: 
	// 1. 이 버튼은 시간에 따라 돈이 쌓이고, (시간 X 골드)
	// 2. 설정된 최대 시간 이상은 돈이 쌓일 수 없다. (다른 건 설정된 골드 이상은 돈이 쌓일 수 없는 걸로) 
	// 3. 버튼을 클릭하면 돈을 회수하고 
	// 4. 버튼에 쌓인 돈은 없어지고 다시 생성되게 된다.

	//UI
	public Button mButton;         // 할당된 버튼 UI
	public Text mButton_text;      // UI에 표시될 TEXT = (시간 * 골드)

	//변수
	public DateTime mButton_PressedLastDateTime; // 이 버튼에 마지작으로 눌린 시간.(저장해야된다.)

	public float mButton_Checktimer;    // 이 버튼 현재 시간. -> time.delta를 통해 Text로 표시.
	public float mButton_MaxTimer_type_Min; // 이 버튼에 할당된 맥스 분. 
	public float mButton_gold;     // 시간 당 쌓이는 골드

	void Start()
	{
		//이버튼에 할당된 DateTime을 알면 실행 시킬지 말지 결정할 수 있다.
		//xml에 저장된 시간보다 현재 시간이 더 많다면(지났다면) -> 수확을 할수 있도록.
		//xml에 저장된 시간보다 현재 시간이 더 적다면(안 지났다면) -> 시간의 차이 만큼 델타 타임을 준다. 

		//실행을 하면 코루틴 시작.
		StartCoroutine (CheckTime ());
		Debug.Log ("Start");
	}

	void Update () 
	{
	}

	float CalcSec (float a)
	{
		//a는 분(min)이다.. 이걸 초로 보이게 
		//왜냐 이걸 DeltaTime에서 써야하기 때문에.
		return a * 60;
	}


	//[11/12/2015 tgboys] 모으기 시작 
	IEnumerator CheckTime()
	{
		//버튼의 비활성화.
		mButton.interactable = false;

		float tempGold = 0;
		float deltaTime = 0;

		while ( deltaTime < CalcSec(mButton_MaxTimer_type_Min)) {
			deltaTime += Time.deltaTime;
			//Debug.Log("deltaTime" + deltaTime);

			//버튼 TEXT에 보여주자.(시간이 얼마나 흘렀나 보여주기)/
			//mButton_text.text = deltaTime.ToString("N0");

			//현재까지의 돈 보여주기.
			tempGold =  deltaTime * mButton_gold;
			mButton_text.text = "Gold = " + tempGold.ToString("N0");


			yield return new WaitForFixedUpdate();
		}

		if (deltaTime >= CalcSec(mButton_MaxTimer_type_Min)) {

			mButton_text.text = "Gold = " + tempGold.ToString("N0");

			mButton.interactable = true;
		}
	}

	public void setTime (DateTime d_Time){
		DateTime tempTime = d_Time;
		mButton_PressedLastDateTime = tempTime.AddMinutes (mButton_MaxTimer_type_Min);

		//Debug.Log("mButton_PressedLastDateTime = " + mButton_PressedLastDateTime+ " --Add Time : "+ mButton_MaxTimer_type_Min +"-- System.DateTime.Now is " +System.DateTime.Now);
		//mButton.interactable = false;
	}

	
	public void CheckTime1(DateTime d_time){

		//비교 해서 아직 시간이 지나지 않았을 때.
		if (mButton_PressedLastDateTime.CompareTo(d_time) > 0) {
			//Debug.Log("big");
			//Debug.Log("mButton_PressedLastDateTime = " + mButton_PressedLastDateTime+ "-- d_time is " + d_time);

			TimeSpan tempCalcTime = mButton_PressedLastDateTime - d_time;

			string a = mButton_PressedLastDateTime.ToString();

			//Debug.Log("a ===="+ a );

			//mButton_text.text = "Time :" +tempCalcTime.ToString();

			//mButton_text.text = "Time: " + mButton_Checktimer.ToString("N0");

		}
		//시간이 지남.
		else if (mButton_PressedLastDateTime.CompareTo(d_time) < 0) {
			//Debug.Log("small");
			//Debug.Log("mButton_PressedLastDateTime = " + mButton_PressedLastDateTime+ "-- d_time is " + d_time);

			//체크 타임의 숫자를 정한다. 0.25 는 15초.....1은 60초라능.

			//mButton_Checktimer = mButton_MaxTimer_type_Min

			mButton_text.text = "Ready";
			//mButton.interactable = true;
		}

	}


	public void GetGoldButton()
	{
		//눌렀으니 다음 활성화 시간을 기록 한다.
		DateTime tempTime = System.DateTime.Now;
		mButton_PressedLastDateTime = tempTime.AddMinutes (mButton_MaxTimer_type_Min);

		//돈은 시간만큼 가져간다.
		float nowGold = CalcSec(mButton_MaxTimer_type_Min) * mButton_gold;

		mGameManager.NumberTotalGold += nowGold;
		mGameManager.totalgold.text = mGameManager.NumberTotalGold.ToString ("N0");

		Debug.Log ("Clicked");

		mButton.interactable = false;
		StartCoroutine (CheckTime ());

	}
}

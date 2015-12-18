using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimeSpendButton02 : MonoBehaviour {

	public GameManager mGameManager;
	
	
	//[13/11/2015 tgboys]: 일반 소셜 게임 방식.
	// 1. 시간을 체크해서 수확이 가능하면 버튼 On, 수확 불가면 off 
	// 2. 버튼을 클릭하면 돈을 회수하고 
	// 3. 버튼에 쌓인 돈은 없어지고 다시 시간만큼 기다리기.
    // 4. 버튼.TEXT에는 남은 시간이 출력되도록 한다.
	
	//UI
	public Button mButton;         // 할당된 버튼 UI
	public Text mButton_text;      // UI에 표시될 TEXT = (시간 * 골드)
	
	//변수
	public DateTime mButton_PressedLastDateTime; // 이 버튼에 마지작으로 눌린 시간.(저장해야된다.)
	
	public float mButton_MaxTimer_type_Min; // 이 버튼에 할당된 맥스 분. 
	public float mButton_gold;     // 획득 되는 골드.
	
	void Start()
	{
        //처음 실행 될때 시간을 찍어준다. 더해준다. --> 여기에선 임시 방편임..TEST용도.
        mButton_PressedLastDateTime = System.DateTime.Now.AddMinutes(mButton_MaxTimer_type_Min);
        Debug.Log(mButton_PressedLastDateTime);

		//이버튼에 할당된 DateTime을 알면 실행 시킬지 말지 결정할 수 있다.
        var temp_compareTime = mButton_PressedLastDateTime.CompareTo(System.DateTime.Now);

        //조건 비교 들어갑니다잉...
        if (temp_compareTime >= 0) //목표 시간이 남았을 때
        {  //xml에 저장된 시간보다 현재 시간이 더 적다면(안 지났다면) -> 시간의 차이 만큼 델타 타임을 준다. 

            TimeSpan calcTime = mButton_PressedLastDateTime - System.DateTime.Now; //시간 차이를 구하고.

            //남은 시간을 문자로 보여주자.
            string tempTime = Convert.ToString(calcTime.Hours + calcTime.Minutes + calcTime.Seconds);

            //Debug.Log("Eariler lasted Time is = " + calcTime);
            Debug.Log("Eariler lasted Time is = " + tempTime);
        }

        else //목표 시간이 지났을 때.
        {    //xml에 저장된 시간보다 현재 시간이 더 많다면(지났다면) -> 수확을 할수 있도록.

            mButton.interactable = true;
            mButton_text.text = "Ready = " + mButton_gold.ToString();
            Debug.Log("Ready");
        }

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

        float tempGold = mButton_gold;
		float deltaTime = 0;
		
		while ( deltaTime < CalcSec(mButton_MaxTimer_type_Min)) {
			deltaTime += Time.deltaTime;
			//Debug.Log("deltaTime" + deltaTime);

			//현재까지의 돈 보여주기.
			tempGold = mButton_gold;
            //mButton_text.text = "Gold = " + tempGold.ToString("N0");
            
            //남은 시간 보여주기.
            TimeSpan tempCalcTime = System.DateTime.Now - mButton_PressedLastDateTime;


            //Debug.Log("nowTime: " + System.DateTime.Now + " buttonTime : " + mButton_PressedLastDateTime);

            //남은 시간을 문자로 보여주자.
            //string.Format("aaa : {0}, bbb : {1}", 1, 2);
            mButton_text.text = string.Format("{0}H, {1}M, {2}S", tempCalcTime.Hours, tempCalcTime.Minutes, tempCalcTime.Seconds);

			yield return new WaitForFixedUpdate();
		}
		
		if (deltaTime >= CalcSec(mButton_MaxTimer_type_Min)) {
			
			mButton_text.text = "Gold = " + tempGold.ToString("N0");
			
			mButton.interactable = true;
		}
	}
	
	public void GetGoldButton() //눌러서 돈은 회수, 시간은 초기화
	{
		//눌렀으니 다음 활성화 시간을 기록 한다.
        mButton_PressedLastDateTime = System.DateTime.Now.AddMinutes(mButton_MaxTimer_type_Min);
		
		//돈은 시간만큼 가져간다.
		float nowGold = mButton_gold;
		
		mGameManager.NumberTotalGold += nowGold;
		mGameManager.totalgold.text = mGameManager.NumberTotalGold.ToString ("N0");
		
		Debug.Log ("Clicked");
		
		mButton.interactable = false;
		StartCoroutine (CheckTime ());
		
	}

    public void setTime(DateTime d_Time)
    {
        DateTime tempTime = d_Time;
        mButton_PressedLastDateTime = tempTime.AddMinutes(mButton_MaxTimer_type_Min);

        //Debug.Log("mButton_PressedLastDateTime = " + mButton_PressedLastDateTime+ " --Add Time : "+ mButton_MaxTimer_type_Min +"-- System.DateTime.Now is " +System.DateTime.Now);
        //mButton.interactable = false;
    }

}

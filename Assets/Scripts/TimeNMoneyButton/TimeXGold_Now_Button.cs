using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimeXGold_Now_Button : MonoBehaviour {

	public GameManager mGameManager;


	//[17/11/2015 tgboys]: 클래시 오브 클랜 방식에 즉시 획득 방식.
	// 1. 이 버튼은 시간에 따라 돈이 쌓이고, (시간 X 골드)
	// 2. 설정된 최대 시간 이상은 돈이 쌓일 수 없다. (다른 건 설정된 골드 이상은 돈이 쌓일 수 없는 걸로) 
	// 3. 버튼을 클릭하면 돈을 회수하고 
	// 4. 버튼에 쌓인 돈은 없어지고 다시 생성되게 된다.

	//UI
	public Button mButton;         // 할당된 버튼 UI
	public Text mButton_text;      // UI에 표시될 TEXT = (시간 * 골드)

	//변수
	public DateTime mButton_PressedLastDateTime; // 이 버튼에 마지작으로 눌린 시간.(저장해야된다.)
    public float mButton_MaxTimer_type_Min; // 이 버튼에 할당된 맥스 분. 
	public float mButton_gold;     // 시간 당 쌓이는 골드
    
    //신규
    public float tempGold; //시간당 계산된 골드.
    public float deltaTime;

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


	//[17/12/2015 tgboys] 모으기 시작 
	IEnumerator CheckTime()
	{

        tempGold = 0;
        deltaTime = 0;

		while ( deltaTime < CalcSec(mButton_MaxTimer_type_Min)) {
			deltaTime += Time.deltaTime;

			//현재까지의 돈 보여주기.
			tempGold =  deltaTime * mButton_gold;
            mButton_text.text = "Gold = " + Math.Truncate(tempGold).ToString("N0");
            
			yield return new WaitForFixedUpdate();
		}

		if (deltaTime >= CalcSec(mButton_MaxTimer_type_Min)) {

			//숫자 버림 사용.
            mButton_text.text = "Gold = " + Math.Truncate(tempGold).ToString("N0");

		}
	}
    		
	public void GetGoldButton() //누르면 누를수록 빨리 체워 진다 왜 그럴까??
	{
        StopCoroutine(CheckTime());
		//돈은 시간만큼 가져간다.
        float nowGold = deltaTime * mButton_gold;

		mGameManager.NumberTotalGold += nowGold;
		mGameManager.totalgold.text = mGameManager.NumberTotalGold.ToString ("N0");

		Debug.Log ("Clicked");

        //눌렀으니 다음 활성화 시간을 기록 한다.
        mButton_PressedLastDateTime = System.DateTime.Now.AddMinutes(mButton_MaxTimer_type_Min);

		StartCoroutine (CheckTime ());
	}
}

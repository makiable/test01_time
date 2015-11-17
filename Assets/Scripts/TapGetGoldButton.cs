using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TapGetGoldButton : MonoBehaviour {

    public GameManager mGameManager;

    //[17/11/2015 tgboys]: 탭할때마다 골드를 얻는 방식.
    // 1. 버튼을 클리하면 돈을 획득한다.
    // 2. 버튼을 누르는 간격이 있다. (간격설정은 어떻게??)
    // 3. 누른 타임을 기억하는 것과 4. 릴리즈를 기억하는 것 2개가 있음

    
   	//UI
	public Button mButton;         // 할당된 버튼 UI
	public Text mButton_text;      // UI에 표시될 TEXT = (시간 * 골드)

	//변수
	//public DateTime mButton_PressedLastDateTime; // 이 버튼에 마지작으로 눌린 시간.(저장해야된다.)
    public float mButton_MaxTimer_sec; // 이 버튼에 할당된 맥스 초. 
	public float mButton_gold;     // 시간 당 쌓이는 골드
  

    // Use this for initialization
	void Start () {
        CanClickedButton();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CanClickedButton()
    {
        mButton.interactable = true;
        mButton_text.text = mButton_gold.ToString();
    }

    public void GetGoldButton() //눌러서 돈은 회수, 시간은 초기화
    {
        //누르면 돈을 가져간다.
        mGameManager.NumberTotalGold += mButton_gold;
        mGameManager.totalgold.text = mGameManager.NumberTotalGold.ToString("N0");

        Debug.Log("Clicked");
        
        mButton.interactable = false;

        //눌렸으니 코루틴 ㄱㄱ
        StartCoroutine(CheckTime());
    }

    IEnumerator CheckTime()
    {
        //버튼의 비활성화.
        mButton.interactable = false;

        float deltaTime = 0;
            
        while (deltaTime < mButton_MaxTimer_sec){
            deltaTime += Time.deltaTime;

            mButton_text.text = deltaTime.ToString("N0");

            yield return new WaitForFixedUpdate();
        }

        if (deltaTime >= mButton_MaxTimer_sec)
        {
            CanClickedButton();
        }

	}
}

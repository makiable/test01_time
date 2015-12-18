using UnityEngine;
using System.Collections;

public class CountManager : MonoBehaviour {

    //씬에 있는 버튼
    public GameObject P1;
    public GameObject P2;

    //베틀 순서
    public int[] PlayerAttackList;


	// Use this for initialization
	void Start () {
        //버튼의 DEX가져와서 넣기.
        

        //버튼들의 덱스 비교 후 배틀 순서 정하기.

        
        //코루틴 스타트.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //코루틴은 리스트에 있는 순서대로 버튼들을 액션을 시킴.
    //공격, 스킬등은 각 객체가 알아서 하도록하고.
    //행동이 끝났다는 리턴 값만 받으면 다음애가 움직일 수 있도록. ㄱㄱ


}

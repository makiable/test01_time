using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollbarSet : MonoBehaviour {

    public Scrollbar mScrollbar;

	// Use this for initialization
	void Start () {
        mScrollbar.value = 1.0f; //시작하면 맨 상단으로 간당!
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

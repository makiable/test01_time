using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScrollContentsController : MonoBehaviour {

    [SerializeField]
    RectTransform prefab = null;

    public int NodeCount;

    void Start()
    {
        for (int i = 0; i < NodeCount; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            var text = item.GetComponentInChildren<Text>();
            text.text = "item:" + i.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

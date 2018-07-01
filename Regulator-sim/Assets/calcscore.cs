using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class calcscore : MonoBehaviour {

    public GameObject obj1, obj2;
    public Text score_text;

    float score = 0;
	// Update is called once per frame
	void Update () {

        score = Mathf.Abs(Vector3.Distance(obj1.transform.position, obj2.transform.position));
        
        score_text.text = score.ToString();

    }
}

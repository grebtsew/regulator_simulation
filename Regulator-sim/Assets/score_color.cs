using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_color : MonoBehaviour {

    private Text text;
    private float score = 0;
    private string temp = "";

	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        temp = text.text;
        temp = temp.Replace("%", "");
        temp = temp.Replace(" ", "");
        score = float.Parse(temp);

            // print(score);
        if(score < 50)
        {
            // red
            text.color = new Color32(255, 64, 64, 255);
        }
      if(score > 50)
        {
            // white
            text.color = new Color32(245 , 245, 220, 255);
        }
        if (score > 60)
        {
            // yellow
            text.color = new Color32(255, 185, 15, 255);
        }
        if (score > 70)
        {
            // green light
            text.color = new Color32(153, 204, 50, 255);
        }
        if (score > 80)
        {   // green
            text.color = new Color32(254, 152, 0, 255);
        }
        if (score > 90)
        {
            // green dark
            text.color = new Color32(124, 252, 0, 255);
        }
        if (score > 95)
        {
            text.color = new Color32(0, 100, 0, 255);
        }



    }
}

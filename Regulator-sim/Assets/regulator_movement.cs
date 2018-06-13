using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regulator_movement : MonoBehaviour {

    public Dropdown dropdown;
    public Slider Kp;
    public Slider Ki;
    public Slider Kd;
    public Slider T;
    public GameObject signal;
    float s = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        s = signal.transform.position.y;
        

        switch (dropdown.value)
        {
            

            // p
            case 0:
                // Kp/(s^2 + Ts + Kp)
                this.transform.position = new Vector3(transform.position.x, Kp.value / (Mathf.Pow(s,2) + T.value * s + Kp.value));
                break;
            // pd
            case 1:
                // (Kp + s*Kd)/(s^2 + (1 + Kd)s + Kp)
                this.transform.position = new Vector3(transform.position.x, (Kp.value + s*Kd.value)/ (Mathf.Pow(s, 2) + (1 + Kd.value)*s + Kp.value));

                break;
            // pi
            case 2:
                //(Kp + sKi)/s^2 + (1 + Kp)s + Ki)
                this.transform.position = new Vector3(transform.position.x, (Kp.value + Ki.value*s) / (Mathf.Pow(s, 2) + (1 + Kp.value) * s + Ki.value));

                break;
            // pid
            case 3:
                //(Kp)/(s^3 + (1 + Kd)s^2 + (1 + Kp)s + Ki)
                this.transform.position = new Vector3(transform.position.x, Kp.value / (Mathf.Pow(s, 3) + (1 + Kd.value) * Mathf.Pow(s, 3) + (1 + Kp.value)*s + Ki.value));

                break;
        }

	}
}

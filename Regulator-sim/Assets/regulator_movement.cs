using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regulator_movement : MonoBehaviour {

    public Dropdown dropdown;
    public Slider Kp;
    public Slider Ki;
    public Slider Kd;
    public signal_movement signal;
    float s = 0;
    List<float> s_list = new List<float>();
    private float curr = 0;
    float error = 0;
    float integral = 0;
    float derivate = 0;
    float old_error = 0;
    float _dt = 1;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        s = signal.transform.position.y;

        error = s - curr;

        if(signal.freq_counter != 0)
        _dt = signal.freq_counter;
        
        // integral
        integral += error * _dt;

        // derivate
        derivate = (error - old_error) /_dt;


        // time ++
        //_dt++;
        old_error = error;

        switch (dropdown.value)
        {
            

            // p
            case 0:
                //old
                // Kp/(s^2 + Ts + Kp)
                //new
                // Kp*e(t)
                curr = Kp.value * error;
                this.transform.position = new Vector3(transform.position.x, curr );
                break;
            // pd
            case 1:
                // old
                // (Kp + s*Kd)/(s^2 + (1 + Kd)s + Kp)
                // new
                // Kp*e(t) + Kd*derivate
                curr = Kp.value * error + Kd.value * derivate;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
            // pi
            case 2:
                //old
                //(Kp + sKi)/s^2 + (1 + Kp)s + Ki)
                //new
                // kp*e(t) + Ki*integral
                curr = Kp.value * error + Ki.value * integral;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
            // pid
            case 3:
                //old
                //(Kp)/(s^3 + (1 + Kd)s^2 + (1 + Kp)s + Ki)
                //new
                //kp*e(t) + Kd*derivate + Ki*integral
                curr = Kp.value * error + Kd.value * derivate + Ki.value * integral;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
        }

	}
}

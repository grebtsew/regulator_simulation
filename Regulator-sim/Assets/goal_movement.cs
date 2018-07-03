using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal_movement : MonoBehaviour
{

    public signal_movement signal;
    float s = 0;
    private float curr = 0;
    float error = 0;
    float integral = 0;
    float derivate = 0;
    float old_error = 0;
    float _dt = 1;
    int random_regulator = 0;
    float random_kp = 0;
    float random_ki = 0;
    float random_kd = 0;
    public Text goal_text;
    string goal_string = "";
    string random_regulator_string = "";
    public float time_value = 0;
    public Text done_text;

    public void reset_score()
    {
        time_value = 0;
    }

    // Use this for initialization
    void Start()
    {
        update_goal();
    }

    public void update_goal()
    {
        
        random_regulator = Random.Range(0, 4);
        if(random_regulator == 4)
        {
            random_regulator = 3;
        }

        switch (random_regulator)
        {

            case 0:
                //p
                random_kp = Random.Range(0, 1f);
                random_ki = 0;
                random_kd = 0;
                random_regulator_string = "P";
                break;
            case 1:
                //pd
                random_kp = Random.Range(0, 0.5f);
                random_kd = Random.Range(0, 0.9f);
                random_ki = 0;
                random_regulator_string = "PD";
                break;

            case 2:
                //ki
                random_kp = Random.Range(0, 0.35f);
                random_ki = Random.Range(0, 0.035f);
                random_kd = 0;
                random_regulator_string = "PI";
                break;
            case 3:
                // pid
                random_ki = Random.Range(0, 0.01f);
                random_kd = Random.Range(0, 0.1f);
                random_kp = Random.Range(0, 0.4f);
                random_regulator_string = "PID";
                break;
                
        }

        if(goal_text != null)
        {

        goal_string = "Regulator : " + random_regulator_string + " kp : " + random_kp + " kd : " + random_kd + " ki : " + random_ki;
        goal_text.text = goal_string;
        Debug.Log(goal_string);
        }

    }

    public void Update_Game_Score()
    {
        goal_string = "Regulator : " + random_regulator_string + " kp : " + random_kp + " kd : " + random_kd + " ki : " + random_ki;
        done_text.text = goal_string;
       
    }

    // Update is called once per frame
    void Update()
    {

        s = signal.transform.position.y;

        error = s - curr;

        if (signal.freq_counter != 0)
            _dt = signal.freq_counter;

        // integral
        integral += error * _dt;

        // derivate
        derivate = (error - old_error) / _dt;


        // time ++
        //_dt++;
        old_error = error;

        
        switch (random_regulator)
        {


            // p
            case 0:
                //old
                // Kp/(s^2 + Ts + Kp)
                //new
                // Kp*e(t)
                curr = random_kp * error;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
            // pd
            case 1:
                // old
                // (Kp + s*Kd)/(s^2 + (1 + Kd)s + Kp)
                // new
                // Kp*e(t) + Kd*derivate
                curr = random_kp * error + random_kd * derivate;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
            // pi
            case 2:
                //old
                //(Kp + sKi)/s^2 + (1 + Kp)s + Ki)
                //new
                // kp*e(t) + Ki*integral
                curr = random_kp * error + random_ki * integral;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
            // pid
            case 3:
                //old
                //(Kp)/(s^3 + (1 + Kd)s^2 + (1 + Kp)s + Ki)
                //new
                //kp*e(t) + Kd*derivate + Ki*integral
                curr = random_kp * error + random_kd * derivate + random_ki * integral;
                this.transform.position = new Vector3(transform.position.x, curr);
                break;
        }

        time_value += Mathf.Abs(curr);

    }
}

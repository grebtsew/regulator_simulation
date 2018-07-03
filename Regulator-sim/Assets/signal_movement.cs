using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signal_movement : MonoBehaviour {

    public Slider freqslider;
    public Slider valueslider;
    public Toggle step_mode;
    public Slider min_randomslider;
    public Slider max_randomslider;

    public goal_movement goal;
    public regulator_movement regulator;
    public Text score_text;

    public float freq_counter = 0;
    bool b = false;
    float delta_signal;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(valueslider != null)
        {
            delta_signal = valueslider.value;
            
        } else
        {
            delta_signal = 1;
        }
        
        
        // Random
        if (delta_signal == -1)
        {
            delta_signal = Random.Range( (int)min_randomslider.value, (int) max_randomslider.value);
         }

        
        if (step_mode.isOn) {
            

            // freq
            if (freq_counter > freqslider.value)
            {
                freq_counter = 0;
                if(b)
                {
                    
                    b = false;
                    this.transform.position = new Vector3(this.transform.position.x, delta_signal);

                }
                else
                {
                    b = true;
                    this.transform.position = new Vector3(this.transform.position.x, -delta_signal);

                }
                score_text.text = calculate_score();
                reset_scores();
            }
            else
            {
                freq_counter++;
            }

        } else
        {
            // freq
            if (freq_counter > freqslider.value)
            {
                
                freq_counter = 0;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + delta_signal);
            }
            else
            {
                freq_counter++;
            }
            score_text.text = calculate_score();
            reset_scores();
        }

	}

    private void reset_scores()
    {
        regulator.reset_score();
        goal.reset_score();
    }

    private string calculate_score()
    {

        float r_value = regulator.time_value;
        float g_value = goal.time_value;

        float res = 0;

        //Debug.Log(r_value + " g " + g_value );
        if(g_value != 0)
        {
            if(r_value <= g_value)
            {
                res = Mathf.Abs(r_value / g_value) * 100;
            } else
            {
                res = Mathf.Abs(g_value / r_value) * 100;
            }
            
        }

        return res.ToString() + " %";
    }
}

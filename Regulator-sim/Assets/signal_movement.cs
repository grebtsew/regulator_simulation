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

    float freq_counter = 0;
    bool b = false;
    int delta_signal;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delta_signal = (int) valueslider.value  ;
        
        // Random
        if (delta_signal == 0)
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
            }
            else
            {
                freq_counter++;
            }

        } else
        {
            Debug.Log("hej");
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

        }

	}
}

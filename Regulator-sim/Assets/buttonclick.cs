using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonclick : MonoBehaviour {
        //Make sure to attach these Buttons in the Inspector
        public Button button;

        void Start()
        {
            Button btn = this.GetComponent<Button>();
         
        //Calls the TaskOnClick method when you click the Button
            btn.onClick.AddListener(TaskOnClick);

        }

        void TaskOnClick()
        {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

        
    
}

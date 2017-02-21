using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public SpriteRenderer s;

	// Use this for initialization
	void Start () {
        s.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu();
        }
    }

    public void pauseMenu()
    {
        if (Controller.Instance.paused)
        {
            Time.timeScale = 1;
            s.enabled = false;
            Controller.Instance.paused = false;
        }
        else
        {
            Time.timeScale = 0;
            s.enabled = true;
            Controller.Instance.paused = true;
        }
    }
}

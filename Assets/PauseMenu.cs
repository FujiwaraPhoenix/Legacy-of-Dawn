using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public SpriteRenderer s;
    public bool redo;

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            redo = !redo;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            redo = !redo;
        }
        if (Controller.Instance.paused)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                execMission(redo);
            }
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

    public void execMission(bool reset)
    {
        if (reset)
        {
            Controller.Instance.player.transform.position = new Vector3(-4, 5, 0);
            Controller.Instance.lives = 2;
            Controller.Instance.bombs = 3;
            Controller.Instance.points = 0;
            Controller.Instance.power = 1;
            Controller.Instance.paused = false;
            Controller.Instance.beginning = true;
            SceneManager.LoadScene("Stage1");
        }
        else
        {
            Controller.Instance.paused = false;
            s.enabled = false;
        }
    }
}

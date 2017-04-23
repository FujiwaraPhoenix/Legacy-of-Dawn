using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public SpriteRenderer s;
    public bool redo;
    public AudioClip deny;

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
        if (Controller.Instance.player.dead)
        {
            s.enabled = true;
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
            Controller.Instance.player.dead = false;
            Controller.Instance.clearScreen = false;
            Controller.Instance.bossHP = 0;
            Controller.Instance.bossMaxHP = 0;
            Controller.Instance.hpbar.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1;
            SceneManager.LoadScene("Stage1");
        }
        else
        {
            if (!Controller.Instance.player.dead)
            {
                Controller.Instance.paused = false;
                Time.timeScale = 1;
                s.enabled = false;
            }
            else
            {
                Sound.me.PlaySound(deny, .1f, 48, 49);
            }
        }

    }
}

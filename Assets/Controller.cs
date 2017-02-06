using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public static Controller Instance;
    public int lives, bombs, points, stageNo, dmg, dmg2, laserProcTimer;
    public float power;
    public bool pt1up1, pt1up2, pt1up3, stageClear, laserActive;
    public Player player;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

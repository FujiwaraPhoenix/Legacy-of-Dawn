using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public static Controller Instance;
    public int lives, bombs, points, stageNo, dmg, dmg2, laserProcTimer, bossHP, bossMaxHP;
    public float power, globalAng;
    public bool pt1up1, pt1up2, pt1up3, stageClear, laserActive, invuln, clearScreen, bombing, beginning, paused, bossDead;
    public Player player;
    public Exploder expl;
    public GameObject BossExpl;
    public HPBar hpbar;

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

    void Update()
    {
        Instance.power = Instance.power * 20;
        Instance.power = Mathf.Round(Instance.power);
        Instance.power = Instance.power / 20;
        if (bossHP < 0)
        {
            bossHP = 0;
        }
    }
}

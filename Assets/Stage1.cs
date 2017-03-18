using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stage1 : MonoBehaviour {
    public Enemy a;
    public Boss1 b;
    public Player p;
    public bool testing;
    public int tilNextStg;


    void Start()
    {
        StartCoroutine(stage1());
        testing = true;
    }

    // Update is called once per frame
    void Update () {
		if (Controller.Instance.lives < 0)
        {
            p.dead = true;
            StopAllCoroutines();
            Controller.Instance.clearScreen = true;
        }
        if (Controller.Instance.bossDead)
        {
            if (tilNextStg > 180)
            {
                SceneManager.LoadScene("Stage2");
            }
            tilNextStg++;
        }
	}

    IEnumerator stage1()
    {
        yield return new WaitForSeconds(3);

        //Initial Wave: 7 fairies, slight V formation.
        Enemy mob1 = Instantiate(a, new Vector3(-4, 21, 0), Quaternion.identity);
        mob1.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob1.direction = new Vector3(0, -1, 0);
        mob1.itemDrop = 2;

        yield return new WaitForSeconds(.75f);

        Enemy mob2 = Instantiate(a, new Vector3(-2, 21, 0), Quaternion.identity);
        Enemy mob3 = Instantiate(a, new Vector3(-6, 21, 0), Quaternion.identity);
        mob2.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob3.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob2.direction = new Vector3(0, -1, 0);
        mob3.direction = new Vector3(0, -1, 0);
        mob2.itemDrop = 1;
        mob3.itemDrop = 1;

        yield return new WaitForSeconds(.75f);

        Enemy mob4 = Instantiate(a, new Vector3(0, 21, 0), Quaternion.identity);
        Enemy mob5 = Instantiate(a, new Vector3(-8, 21, 0), Quaternion.identity);
        mob4.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob5.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob4.direction = new Vector3(0, -1, 0);
        mob5.direction = new Vector3(0, -1, 0);
        mob4.itemDrop = 2;
        mob5.itemDrop = 2;

        yield return new WaitForSeconds(.75f);

        Enemy mob6 = Instantiate(a, new Vector3(2, 21, 0), Quaternion.identity);
        Enemy mob7 = Instantiate(a, new Vector3(-10, 21, 0), Quaternion.identity);
        mob6.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob7.setParameters(1, .02f, 0, .02f, .02f, 1, false, 5);
        mob6.direction = new Vector3(0, -1, 0);
        mob7.direction = new Vector3(0, -1, 0);
        mob6.itemDrop = 1;
        mob7.itemDrop = 1;

        yield return new WaitForSeconds(8);

        //Wave 2: 7 fairies from top right. Move down, then curve to left.

        Enemy mob8 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob8.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob8.direction = new Vector3(0, -1, 0);
        mob8.itemDrop = 2;
        mob8.shotType = 1;
        mob8.shotDelay = 90;
        mob8.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob9 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob9.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob9.direction = new Vector3(0, -1, 0);
        mob8.itemDrop = 1;
        mob9.shotType = 1;
        mob9.shotDelay = 90;
        mob9.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob10 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob10.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob10.direction = new Vector3(0, -1, 0);
        mob10.itemDrop = 2;
        mob10.shotType = 1;
        mob10.shotDelay = 90;
        mob10.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob11 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob11.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob11.direction = new Vector3(0, -1, 0);
        mob11.itemDrop = 1;
        mob11.shotType = 1;
        mob11.shotDelay = 90;
        mob11.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob12 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob12.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob12.direction = new Vector3(0, -1, 0);
        mob12.itemDrop = 2;
        mob12.shotType = 1;
        mob12.shotDelay = 90;
        mob12.shotTimer = -30;

        mob8.mvtFxn = 2;
        mob8.deltaAngle = -3;
        mob8.moveTimer = 30;

        Enemy altMob1 = Instantiate(a, new Vector3(-8, 22, 0), Quaternion.identity);
        altMob1.setParameters(1, .045f, 0, .045f, .045f, 1, false, 30);
        altMob1.direction = new Vector3(0, -1, 0);
        altMob1.noForCirc = 12;
        altMob1.shotVel = .05f;
        altMob1.itemDrop = 2;
        altMob1.shotType = 3;
        altMob1.shotDelay = 60;
        altMob1.shotTimer = -30;
        altMob1.offsetInc = 5;

        yield return new WaitForSeconds(.75f);

        Enemy mob13 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob13.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob13.direction = new Vector3(0, -1, 0);
        mob13.itemDrop = 1;
        mob13.shotType = 1;
        mob13.shotDelay = 90;
        mob13.shotTimer = -30;

        mob9.mvtFxn = 2;
        mob9.deltaAngle = -3;
        mob9.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        Enemy mob14 = Instantiate(a, new Vector3(1, 21, 0), Quaternion.identity);
        mob14.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob14.direction = new Vector3(0, -1, 0);
        mob14.itemDrop = 2;
        mob14.shotType = 1;
        mob14.shotDelay = 90;
        mob14.shotTimer = -30;

        mob10.mvtFxn = 2;
        mob10.deltaAngle = -3;
        mob10.moveTimer = 30;

        altMob1.velocity = 0;

        yield return new WaitForSeconds(.75f);

        mob11.mvtFxn = 2;
        mob11.deltaAngle = -3;
        mob11.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob12.mvtFxn = 2;
        mob12.deltaAngle = -3;
        mob12.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob13.mvtFxn = 2;
        mob13.deltaAngle = -3;
        mob13.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob14.mvtFxn = 2;
        mob14.deltaAngle = -3;
        mob14.moveTimer = 30;

        yield return new WaitForSeconds(2);


        //Wave 3: Mirror of wave 2
        Enemy mob15 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob15.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob15.direction = new Vector3(0, -1, 0);
        mob15.itemDrop = 1;
        mob15.shotType = 1;
        mob15.shotDelay = 90;
        mob15.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob16 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob16.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob16.direction = new Vector3(0, -1, 0);
        mob16.itemDrop = 2;
        mob16.shotType = 1;
        mob16.shotDelay = 90;
        mob16.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob17 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob17.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob17.direction = new Vector3(0, -1, 0);
        mob17.itemDrop = 1;
        mob17.shotType = 1;
        mob17.shotDelay = 90;
        mob17.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob18 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob18.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob18.direction = new Vector3(0, -1, 0);
        mob18.itemDrop = 2;
        mob18.shotType = 1;
        mob18.shotDelay = 90;
        mob18.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob19 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob19.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob19.direction = new Vector3(0, -1, 0);
        mob19.itemDrop = 1;
        mob19.shotType = 1;
        mob19.shotDelay = 90;
        mob19.shotTimer = -30;

        mob15.mvtFxn = 2;
        mob15.deltaAngle = 3;
        mob15.moveTimer = 30;

        Enemy altMob2 = Instantiate(a, new Vector3(0, 22, 0), Quaternion.identity);
        altMob2.setParameters(1, .045f, 0, .045f, .045f, 1, false, 30);
        altMob2.direction = new Vector3(0, -1, 0);
        altMob2.noForCirc = 12;
        altMob2.shotVel = .05f;
        altMob2.itemDrop = 2;
        altMob2.shotType = 3;
        altMob2.shotDelay = 60;
        altMob2.shotTimer = -30;
        altMob2.offsetInc = -5;

        yield return new WaitForSeconds(.75f);

        Enemy mob20 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob20.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob20.direction = new Vector3(0, -1, 0);
        mob20.itemDrop = 2;
        mob20.shotType = 1;
        mob20.shotDelay = 90;
        mob20.shotTimer = -30;

        mob16.mvtFxn = 2;
        mob16.deltaAngle = 3;
        mob16.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        Enemy mob21 = Instantiate(a, new Vector3(-9, 21, 0), Quaternion.identity);
        mob21.setParameters(1, .04f, 0, .04f, .04f, 1, false, 10);
        mob21.direction = new Vector3(0, -1, 0);
        mob21.itemDrop = 1;
        mob21.shotType = 1;
        mob21.shotDelay = 90;
        mob21.shotTimer = -30;

        mob17.mvtFxn = 2;
        mob17.deltaAngle = 3;
        mob17.moveTimer = 30;

        altMob2.velocity = 0;

        yield return new WaitForSeconds(.75f);

        mob18.mvtFxn = 2;
        mob18.deltaAngle = 3;
        mob18.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob19.mvtFxn = 2;
        mob19.deltaAngle = 3;
        mob19.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob20.mvtFxn = 2;
        mob20.deltaAngle = 3;
        mob20.moveTimer = 30;

        yield return new WaitForSeconds(.75f);

        mob21.mvtFxn = 2;
        mob21.deltaAngle = 3;
        mob21.moveTimer = 30;

        yield return new WaitForSeconds(2.5f);

        //Wave 4: Bigger fairy down center
        Enemy mob22 = Instantiate(a, new Vector3(-4, 21, 0), Quaternion.identity);
        mob22.setParameters(1, .025f, 0, .025f, .025f, 1, false, 200);
        mob22.direction = new Vector3(0, -1, 0);
        mob22.transform.localScale *= 2;
        mob22.itemDrop = 2;
        mob22.shotType = 2;
        mob22.shotDelay = 90;
        mob22.shotTimer = -180;

        yield return new WaitForSeconds(2f);


        //Wave 5: Two big fairies, one on each side. Once they stop, scatter around self (reference MoF deathfairies)

        Enemy altMob3 = Instantiate(a, new Vector3(-8, 22, 0), Quaternion.identity);
        altMob3.setParameters(1, .045f, 0, .045f, .045f, 1, false, 100);
        altMob3.direction = new Vector3(0, -1, 0);
        altMob3.noForCirc = 12;
        altMob3.shotVel = .05f;
        altMob3.itemDrop = 2;
        altMob3.shotType = 3;
        altMob3.shotDelay = 120;
        altMob3.shotTimer = -30;
        altMob3.offsetInc = 5;

        Enemy altMob4 = Instantiate(a, new Vector3(0, 22, 0), Quaternion.identity);
        altMob4.setParameters(1, .045f, 0, .045f, .045f, 1, false, 100);
        altMob4.direction = new Vector3(0, -1, 0);
        altMob4.noForCirc = 12;
        altMob4.shotVel = .05f;
        altMob4.itemDrop = 2;
        altMob4.shotType = 3;
        altMob4.shotDelay = 120;
        altMob4.shotTimer = -30;
        altMob4.offsetInc = -5;

        yield return new WaitForSeconds(1f);

        mob22.velocity = 0;

        yield return new WaitForSeconds(.5f);
        altMob3.velocity = 0;
        altMob4.velocity = 0;

        yield return new WaitForSeconds(15);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(1);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(1);

        //Mini-midboss

        Enemy midboss1 = Instantiate(a, new Vector3(-4, 21, 0), Quaternion.identity);
        midboss1.transform.localScale *= 1.5f;
        midboss1.setParameters(1, .03f, 0, .03f, .03f, 1, false, 500);
        midboss1.setShotParameters(4, .01f, 0, .01f, .01f, 1, false);
        midboss1.offsetInc = 5;
        midboss1.direction = new Vector3(0, -1, 0);
        midboss1.itemDrop = 3;
        midboss1.shotDelay = 30;
        midboss1.shotTimer = -180;

        yield return new WaitForSeconds(2);
        midboss1.velocity = 0;
        midboss1.ptInRotation = 1;

        yield return new WaitForSeconds(25);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(2);

        //Waves 6-10: Waves enter from left/right of screen. Move diagonally, shoot at player location.
        //From right
        Enemy mob23 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob23.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob23.direction = GlobalFxns.ToVect(210);
        mob23.itemDrop = 1;
        mob23.shotType = 1;
        mob23.shotDelay = 90;
        mob23.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob24 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob24.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob24.direction = GlobalFxns.ToVect(210);
        mob24.itemDrop = 2;
        mob24.shotType = 1;
        mob24.shotDelay = 90;
        mob24.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob25 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob25.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob25.direction = GlobalFxns.ToVect(210);
        mob25.itemDrop = 1;
        mob25.shotType = 1;
        mob25.shotDelay = 90;
        mob25.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob26 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob26.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob26.direction = GlobalFxns.ToVect(210);
        mob26.itemDrop = 1;
        mob26.shotType = 2;
        mob26.shotDelay = 90;
        mob26.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob27 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob27.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob27.direction = GlobalFxns.ToVect(210);
        mob27.itemDrop = 2;
        mob27.shotType = 1;
        mob27.shotDelay = 90;
        mob27.shotTimer = -30;

        yield return new WaitForSeconds(.5f);

        //From left

        Enemy mob28 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob28.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob28.direction = GlobalFxns.ToVect(-30);
        mob28.itemDrop = 1;
        mob28.shotType = 1;
        mob28.shotDelay = 90;
        mob28.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob29 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob29.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob29.direction = GlobalFxns.ToVect(-30);
        mob29.itemDrop = 2;
        mob29.shotType = 1;
        mob29.shotDelay = 90;
        mob29.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob30 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob30.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob30.direction = GlobalFxns.ToVect(-30);
        mob30.itemDrop = 1;
        mob30.shotType = 1;
        mob30.shotDelay = 90;
        mob30.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob31 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob31.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob31.direction = GlobalFxns.ToVect(-30);
        mob31.itemDrop = 1;
        mob31.shotType = 2;
        mob31.shotDelay = 90;
        mob31.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob32 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob32.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob32.direction = GlobalFxns.ToVect(-30);
        mob32.itemDrop = 2;
        mob32.shotType = 1;
        mob32.shotDelay = 90;
        mob32.shotTimer = -30;

        yield return new WaitForSeconds(.5f);

        //Right again

        Enemy mob33 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob33.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob33.direction = GlobalFxns.ToVect(210);
        mob33.itemDrop = 1;
        mob33.shotType = 1;
        mob33.shotDelay = 90;
        mob33.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob34 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob34.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob34.direction = GlobalFxns.ToVect(210);
        mob34.itemDrop = 2;
        mob34.shotType = 1;
        mob34.shotDelay = 90;
        mob34.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob35 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob35.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob35.direction = GlobalFxns.ToVect(210);
        mob35.itemDrop = 1;
        mob35.shotType = 1;
        mob35.shotDelay = 90;
        mob35.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob36 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob36.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob36.direction = GlobalFxns.ToVect(210);
        mob36.itemDrop = 1;
        mob36.shotType = 2;
        mob36.shotDelay = 90;
        mob36.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob37 = Instantiate(a, new Vector3(3, 16, 0), Quaternion.identity);
        mob37.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob37.direction = GlobalFxns.ToVect(210);
        mob37.itemDrop = 2;
        mob37.shotType = 1;
        mob37.shotDelay = 90;
        mob37.shotTimer = -30;

        yield return new WaitForSeconds(.5f);

        //Left again
        Enemy mob38 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob38.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob38.direction = GlobalFxns.ToVect(-30);
        mob38.itemDrop = 1;
        mob38.shotType = 1;
        mob38.shotDelay = 90;
        mob38.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob39 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob39.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob39.direction = GlobalFxns.ToVect(-30);
        mob39.itemDrop = 2;
        mob39.shotType = 1;
        mob39.shotDelay = 90;
        mob39.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob40 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob40.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob40.direction = GlobalFxns.ToVect(-30);
        mob40.itemDrop = 1;
        mob40.shotType = 1;
        mob40.shotDelay = 90;
        mob40.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob41 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob41.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob41.direction = GlobalFxns.ToVect(-30);
        mob41.itemDrop = 1;
        mob41.shotType = 2;
        mob41.shotDelay = 90;
        mob41.shotTimer = -30;

        yield return new WaitForSeconds(.75f);

        Enemy mob42 = Instantiate(a, new Vector3(-12, 16, 0), Quaternion.identity);
        mob42.setParameters(1, .03f, 0, .03f, .03f, 1, false, 25);
        mob42.direction = GlobalFxns.ToVect(-30);
        mob42.itemDrop = 2;
        mob42.shotType = 1;
        mob42.shotDelay = 90;
        mob42.shotTimer = -30;

        yield return new WaitForSeconds(.5f);

        //Final Wave: No shooting, just a bunch of low HP fairies.

        yield return new WaitForSeconds(10);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(5);

        //Spawn Boss
        Boss1 boss = Instantiate(b, new Vector3(-4, 22, 0), Quaternion.identity);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{

    public Enemy a, a1;
    public Boss3 b;
    public Player p;

    void Start()
    {
        Controller.Instance.bossDead = false;
        Controller.Instance.clearScreen = false;
        StartCoroutine(stage3());
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.lives < 0)
        {
            Controller.Instance.player.dead = true;
            StopAllCoroutines();
            Controller.Instance.clearScreen = true;
        }
    }

    IEnumerator stage3()
    {
        yield return new WaitForSeconds(3);
        //Wave 1: X-pattern-shooting fairies. Center shoots burst at player :D
        Enemy fairy1 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy1.direction = new Vector3(0, -1, 0);
        fairy1.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy1.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy1.transform.localScale *= 1.5f;
        fairy1.shotDelay = 30;
        fairy1.shotTimer = -90;
        fairy1.noForCirc = 4;
        fairy1.offsetVal = 45;
        fairy1.itemDrop = 1;

        Enemy fairy2 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy2.direction = new Vector3(0, -1, 0);
        fairy2.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy2.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy2.transform.localScale *= 1.5f;
        fairy2.shotDelay = 30;
        fairy2.shotTimer = -90;
        fairy2.noForCirc = 4;
        fairy2.offsetVal = 45;
        fairy2.itemDrop = 1;

        yield return new WaitForSeconds(1);

        Enemy fairy3 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy3.direction = new Vector3(0, -1, 0);
        fairy3.setParameters(1, .075f, 0, .075f, .075f, 1, false, 250);
        fairy3.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy3.transform.localScale *= 1.5f;
        fairy3.shotDelay = 30;
        fairy3.shotTimer = -90;
        fairy3.noForCirc = 4;
        fairy3.offsetVal = 45;
        fairy3.itemDrop = 2;

        Enemy fairy4 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy4.direction = new Vector3(0, -1, 0);
        fairy4.setParameters(1, .075f, 0, .075f, .075f, 1, false, 250);
        fairy4.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy4.transform.localScale *= 1.5f;
        fairy4.shotDelay = 30;
        fairy4.shotTimer = -90;
        fairy4.noForCirc = 4;
        fairy4.offsetVal = 45;
        fairy4.itemDrop = 2;

        yield return new WaitForSeconds(0.5f);

        Enemy fairy5 = Instantiate(a, new Vector3(-4, 22, 0), Quaternion.identity);
        fairy5.direction = new Vector3(0, -1, 0);
        fairy5.setParameters(1, .05f, 0, .05f, .05f, 1, false, 500);
        fairy5.setShotParameters(1, .075f, 0, .075f, .075f, 1, false);
        fairy5.transform.localScale *= 1.5f;
        fairy5.indirect = true;
        fairy5.variance = 5;
        fairy5.shotDelay = 20;
        fairy5.shotTimer = -40;
        fairy5.itemDrop = 1;

        yield return new WaitForSeconds(0.5f);
        fairy1.velocity = 0;
        fairy2.velocity = 0;

        yield return new WaitForSeconds(.75f);
        fairy5.velocity = 0;

        yield return new WaitForSeconds(.25f);
        fairy3.velocity = 0;
        fairy4.velocity = 0;

        yield return new WaitForSeconds(10);

        fairy1.direction = new Vector3(1, 0, 0);
        fairy2.direction = new Vector3(-1, 0, 0);
        fairy3.direction = new Vector3(1, 0, 0);
        fairy4.direction = new Vector3(-1, 0, 0);
        fairy5.direction = new Vector3(0, 1, 0);
        fairy1.velocity = .05f;
        fairy2.velocity = .05f;
        fairy3.velocity = .05f;
        fairy4.velocity = .05f;
        fairy5.velocity = .05f;
        //Wave 2: Repeat of wave 1, except now with trash mobs in the way.

        Enemy fairy6 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy6.direction = new Vector3(0, -1, 0);
        fairy6.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy6.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy6.transform.localScale *= 1.5f;
        fairy6.shotDelay = 30;
        fairy6.shotTimer = -90;
        fairy6.noForCirc = 4;
        fairy6.offsetVal = 45;
        fairy6.itemDrop = 1;

        Enemy fairy7 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy7.direction = new Vector3(0, -1, 0);
        fairy7.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy7.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy7.transform.localScale *= 1.5f;
        fairy7.shotDelay = 30;
        fairy7.shotTimer = -90;
        fairy7.noForCirc = 4;
        fairy7.offsetVal = 45;
        fairy7.itemDrop = 1;

        yield return new WaitForSeconds(1);

        Enemy fairy8 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy8.direction = new Vector3(0, -1, 0);
        fairy8.setParameters(1, .075f, 0, .075f, .075f, 1, false, 250);
        fairy8.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy8.transform.localScale *= 1.5f;
        fairy8.shotDelay = 30;
        fairy8.shotTimer = -90;
        fairy8.noForCirc = 4;
        fairy8.offsetVal = 45;
        fairy8.itemDrop = 2;

        Enemy fairy9 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy9.direction = new Vector3(0, -1, 0);
        fairy9.setParameters(1, .075f, 0, .075f, .075f, 1, false, 250);
        fairy9.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy9.transform.localScale *= 1.5f;
        fairy9.shotDelay = 30;
        fairy9.shotTimer = -90;
        fairy9.noForCirc = 4;
        fairy9.offsetVal = 45;
        fairy9.itemDrop = 2;

        yield return new WaitForSeconds(0.5f);

        Enemy fairy10 = Instantiate(a, new Vector3(-4, 22, 0), Quaternion.identity);
        fairy10.direction = new Vector3(0, -1, 0);
        fairy10.setParameters(1, .05f, 0, .05f, .05f, 1, false, 500);
        fairy10.setShotParameters(1, .075f, 0, .075f, .075f, 1, false);
        fairy10.transform.localScale *= 1.5f;
        fairy10.indirect = true;
        fairy10.variance = 5;
        fairy10.shotDelay = 20;
        fairy10.shotTimer = -40;
        fairy10.itemDrop = 1;

        yield return new WaitForSeconds(0.5f);
        fairy6.velocity = 0;
        fairy7.velocity = 0;

        yield return new WaitForSeconds(1f);
        fairy8.velocity = 0;
        fairy9.velocity = 0;
        fairy10.velocity = 0;

        yield return new WaitForSeconds(2.25f);

        Enemy fairy11 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy11.direction = new Vector3(0, -1, 0);
        fairy11.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy11.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy11.shotDelay = 60;
        fairy11.shotTimer = -15;
        fairy11.itemDrop = 2;

        Enemy fairy12 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy12.direction = new Vector3(0, -1, 0);
        fairy12.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy12.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy12.shotDelay = 60;
        fairy12.shotTimer = -15;
        fairy12.itemDrop = 2;

        yield return new WaitForSeconds(.5f);

        Enemy fairy13 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy13.direction = new Vector3(0, -1, 0);
        fairy13.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy13.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy13.shotDelay = 60;
        fairy13.shotTimer = -15;
        fairy13.itemDrop = 1;

        Enemy fairy14 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy14.direction = new Vector3(0, -1, 0);
        fairy14.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy14.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy14.shotDelay = 60;
        fairy14.shotTimer = -15;
        fairy14.itemDrop = 1;

        yield return new WaitForSeconds(.5f);

        Enemy fairy15 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy15.direction = new Vector3(0, -1, 0);
        fairy15.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy15.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy15.shotDelay = 60;
        fairy15.shotTimer = -15;
        fairy15.itemDrop = 2;

        Enemy fairy16 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy16.direction = new Vector3(0, -1, 0);
        fairy16.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy16.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy16.shotDelay = 60;
        fairy16.shotTimer = -15;
        fairy16.itemDrop = 2;

        yield return new WaitForSeconds(.5f);

        fairy11.mvtFxn = 2;
        fairy11.deltaAngle = -3;
        fairy11.moveTimer = 60;
        fairy12.mvtFxn = 2;
        fairy12.deltaAngle = 3;
        fairy12.moveTimer = 60;

        Enemy fairy17 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy17.direction = new Vector3(0, -1, 0);
        fairy17.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy17.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy17.shotDelay = 60;
        fairy17.shotTimer = -15;
        fairy17.itemDrop = 1;

        Enemy fairy18 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy18.direction = new Vector3(0, -1, 0);
        fairy18.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy18.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy18.shotDelay = 60;
        fairy18.shotTimer = -15;
        fairy18.itemDrop = 1;

        yield return new WaitForSeconds(.5f);

        fairy13.mvtFxn = 2;
        fairy13.deltaAngle = -3;
        fairy13.moveTimer = 60;
        fairy14.mvtFxn = 2;
        fairy14.deltaAngle = 3;
        fairy14.moveTimer = 60;

        yield return new WaitForSeconds(.5f);

        fairy15.mvtFxn = 2;
        fairy15.deltaAngle = -3;
        fairy15.moveTimer = 60;
        fairy16.mvtFxn = 2;
        fairy16.deltaAngle = 3;
        fairy16.moveTimer = 60;
        yield return new WaitForSeconds(.5f);

        fairy17.mvtFxn = 2;
        fairy17.deltaAngle = -3;
        fairy17.moveTimer = 60;
        fairy18.mvtFxn = 2;
        fairy18.deltaAngle = 3;
        fairy18.moveTimer = 60;

        yield return new WaitForSeconds(5);

        fairy6.direction = new Vector3(1, 0, 0);
        fairy7.direction = new Vector3(-1, 0, 0);
        fairy8.direction = new Vector3(1, 0, 0);
        fairy9.direction = new Vector3(-1, 0, 0);
        fairy10.direction = new Vector3(0, 1, 0);
        fairy6.velocity = .05f;
        fairy7.velocity = .05f;
        fairy8.velocity = .05f;
        fairy9.velocity = .05f;
        fairy10.velocity = .05f;

        yield return new WaitForSeconds(3);

        //Wave 3: Two X-shot fairies and a pair of burst streams.
        Enemy fairy19 = Instantiate(a, new Vector3(0, 22, 0), Quaternion.identity);
        fairy19.direction = new Vector3(0, -1, 0);
        fairy19.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy19.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy19.transform.localScale *= 1.5f;
        fairy19.shotDelay = 20;
        fairy19.shotTimer = -90;
        fairy19.noForCirc = 4;
        fairy19.offsetVal = 45;
        fairy19.offsetInc = -12;
        fairy19.itemDrop = 1;

        Enemy fairy20 = Instantiate(a, new Vector3(-8, 22, 0), Quaternion.identity);
        fairy20.direction = new Vector3(0, -1, 0);
        fairy20.setParameters(1, .05f, 0, .05f, .05f, 1, false, 250);
        fairy20.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy20.transform.localScale *= 1.5f;
        fairy20.shotDelay = 20;
        fairy20.shotTimer = -90;
        fairy20.noForCirc = 4;
        fairy20.offsetVal = 45;
        fairy20.offsetInc = 12;
        fairy20.itemDrop = 1;

        Enemy fairy21 = Instantiate(a, new Vector3(-3, 22, 0), Quaternion.identity);
        fairy21.direction = new Vector3(0, -1, 0);
        fairy21.setParameters(1, .05f, 0, .05f, .05f, 1, false, 300);
        fairy21.setShotParameters(1, .075f, 0, .075f, .075f, 1, false);
        fairy21.shotDelay = 60;
        fairy21.shotTimer = -40;
        fairy21.itemDrop = 3;

        Enemy fairy22 = Instantiate(a, new Vector3(-5, 22, 0), Quaternion.identity);
        fairy22.direction = new Vector3(0, -1, 0);
        fairy22.setParameters(1, .05f, 0, .05f, .05f, 1, false, 300);
        fairy22.setShotParameters(1, .075f, 0, .075f, .075f, 1, false);
        fairy22.shotDelay = 60;
        fairy22.shotTimer = -40;
        fairy22.itemDrop = 3;

        yield return new WaitForSeconds(1.5f);
        fairy19.velocity = 0;
        fairy20.velocity = 0;
        fairy21.velocity = 0;
        fairy22.velocity = 0;

        yield return new WaitForSeconds(10);

        fairy19.direction = GlobalFxns.ToVect(-45);
        fairy20.direction = GlobalFxns.ToVect(-135);
        fairy21.direction = GlobalFxns.ToVect(-45);
        fairy22.direction = GlobalFxns.ToVect(-135);

        fairy19.velocity = .05f;
        fairy20.velocity = .05f;
        fairy21.velocity = .05f;
        fairy22.velocity = .05f;

        yield return new WaitForSeconds(5);
        //Wave 4: Wisps that pop up every few secs or so. Yuugi-style lasers.
        Enemy wisp1 = Instantiate(a1, new Vector3(.75f, 22, 0), Quaternion.identity);
        wisp1.setParameters(1, .05f, 0, .05f, .05f, 1, false, 100);
        wisp1.setShotParameters(10, .075f, 0, .075f, .075f, 1, false);
        wisp1.direction = new Vector3(0, -1, 0);
        wisp1.offsetInc = 15;
        wisp1.shotDelay = 10;
        wisp1.shotTimer = -110;
        wisp1.itemDrop = 1;

        yield return new WaitForSeconds(.5f);

        Enemy wisp2 = Instantiate(a1, new Vector3(-6.75f, 22, 0), Quaternion.identity);
        wisp2.setParameters(1, .05f, 0, .05f, .05f, 1, false, 100);
        wisp2.setShotParameters(10, .075f, 0, .075f, .075f, 1, false);
        wisp2.direction = new Vector3(0, -1, 0);
        wisp2.offsetInc = 15;
        wisp2.shotDelay = 10;
        wisp2.shotTimer = -110;
        wisp2.itemDrop = 1;

        yield return new WaitForSeconds(.5f);

        Enemy wisp3 = Instantiate(a1, new Vector3(-1.5f, 22, 0), Quaternion.identity);
        wisp3.setParameters(1, .05f, 0, .05f, .05f, 1, false, 100);
        wisp3.setShotParameters(10, .075f, 0, .075f, .075f, 1, false);
        wisp3.direction = new Vector3(0, -1, 0);
        wisp3.offsetInc = 15;
        wisp3.shotDelay = 10;
        wisp3.shotTimer = -110;
        wisp3.itemDrop = 2;


        yield return new WaitForSeconds(.5f);

        Enemy wisp4 = Instantiate(a1, new Vector3(-7.25f, 22, 0), Quaternion.identity);
        wisp4.setParameters(1, .05f, 0, .05f, .05f, 1, false, 100);
        wisp4.setShotParameters(10, .075f, 0, .075f, .075f, 1, false);
        wisp4.direction = new Vector3(0, -1, 0);
        wisp4.offsetInc = 15;
        wisp4.shotDelay = 10;
        wisp4.shotTimer = -110;
        wisp4.itemDrop = 2;

        wisp1.velocity = 0;

        yield return new WaitForSeconds(.5f);

        wisp2.velocity = 0;

        yield return new WaitForSeconds(.5f);

        wisp3.velocity = 0;

        yield return new WaitForSeconds(.5f);

        wisp4.velocity = 0;

        yield return new WaitForSeconds(3);

        wisp1.direction = GlobalFxns.ToVect(-60);
        wisp1.velocity = .025f;

        yield return new WaitForSeconds(.5f);

        wisp2.direction = GlobalFxns.ToVect(-120);
        wisp2.velocity = .025f;

        yield return new WaitForSeconds(.5f);

        wisp3.direction = GlobalFxns.ToVect(-60);
        wisp3.velocity = .025f;

        yield return new WaitForSeconds(.5f);

        wisp4.direction = GlobalFxns.ToVect(-120);
        wisp4.velocity = .025f;

        yield return new WaitForSeconds(3);

        //Wave 5: More Yuugi wisps. Add 4 that aim at player.
        //Wave 6: Death fairy. Would be a midboss, but screw it, outta time.
        Enemy deathFairy = Instantiate(a, new Vector3(-4, 22, 0), Quaternion.identity);
        deathFairy.setParameters(1, .05f, 0, .05f, .05f, 1, false, 1250);
        deathFairy.direction = new Vector3(0, -1, 0);
        deathFairy.bullet = deathFairy.bullet2;
        deathFairy.transform.localScale *= 1.5f;

        yield return new WaitForSeconds(2);
        deathFairy.velocity = 0;
        deathFairy.setShotParameters(9, .05f, 0, .05f, .05f, 1, false);
        deathFairy.shotDelay = 2;
        deathFairy.itemDrop = 4;

        //Boss time~
        yield return new WaitForSeconds(25);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(3);

        //Spawn Boss
        Boss3 boss = Instantiate(b, new Vector3(-4, 22, 0), Quaternion.identity);
    }
}

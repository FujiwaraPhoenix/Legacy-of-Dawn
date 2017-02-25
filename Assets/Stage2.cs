using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour {
    public Enemy a, a1;
    public Boss2 b;
    public Player p;

    void Start()
    {
        Controller.Instance.bossDead = false;
        Controller.Instance.clearScreen = false;
        StartCoroutine(stage2());
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.lives < 0)
        {
            p.dead = true;
            StopAllCoroutines();
            Controller.Instance.clearScreen = true;
        }
    }

    IEnumerator stage2()
    {
        yield return new WaitForSeconds(3);
        //Wave 1: Suicide ghosts. 5 from each side of the screen, sine mvt.
        Enemy ghost1 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost1.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost1.shotType = 6;
        ghost1.itemDrop = 1;
        ghost1.amplitude = .25f;
        ghost1.lr = false;
        ghost1.mvtScale = .2f;

        Enemy ghost2 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost2.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost2.shotType = 6;
        ghost2.itemDrop = 1;
        ghost2.amplitude = .25f;
        ghost2.lr = true;
        ghost2.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost3 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost3.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost3.shotType = 6;
        ghost3.itemDrop = 2;
        ghost3.amplitude = .25f;
        ghost3.lr = false;
        ghost3.mvtScale = .2f;

        Enemy ghost4 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost4.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost4.shotType = 6;
        ghost4.itemDrop = 2;
        ghost4.amplitude = .25f;
        ghost4.lr = true;
        ghost4.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost5 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost5.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost5.shotType = 6;
        ghost5.itemDrop = 1;
        ghost5.amplitude = .25f;
        ghost5.lr = false;
        ghost5.mvtScale = .2f;

        Enemy ghost6 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost6.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost6.shotType = 6;
        ghost6.itemDrop = 1;
        ghost6.amplitude = .25f;
        ghost6.lr = true;
        ghost6.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost7 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost7.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost7.shotType = 6;
        ghost7.itemDrop = 2;
        ghost7.amplitude = .25f;
        ghost7.lr = false;
        ghost7.mvtScale = .2f;

        Enemy ghost8 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost8.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost8.shotType = 6;
        ghost8.itemDrop = 2;
        ghost8.amplitude = .25f;
        ghost8.lr = true;
        ghost8.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost9 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost9.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost9.shotType = 6;
        ghost9.itemDrop = 1;
        ghost9.amplitude = .25f;
        ghost9.lr = false;
        ghost9.mvtScale = .2f;

        Enemy ghost10 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost10.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost10.shotType = 6;
        ghost10.itemDrop = 1;
        ghost10.amplitude = .25f;
        ghost10.lr = true;
        ghost10.mvtScale = .2f;

        yield return new WaitForSeconds(8);

        //Wave 2: Incoming fairies from both sides. Create circles as they move. 3 per side.

        Enemy fairy1 = Instantiate(a, new Vector3(4, 13.5f, 0), Quaternion.identity);
        fairy1.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy1.direction = new Vector3(-1, 0, 0);
        fairy1.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy1.itemDrop = 1;
        fairy1.noForCirc = 5;
        fairy1.shotTimer = -15;
        fairy1.shotDelay = 30;
        fairy1.offsetInc = 5;

        Enemy fairy2 = Instantiate(a, new Vector3(-12, 13.5f, 0), Quaternion.identity);
        fairy2.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy2.direction = new Vector3(1, 0, 0);
        fairy2.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy2.itemDrop = 2;
        fairy2.noForCirc = 5;
        fairy2.shotTimer = -15;
        fairy2.shotDelay = 30;
        fairy2.offsetInc = -5;

        yield return new WaitForSeconds(1);

        Enemy fairy3 = Instantiate(a, new Vector3(4, 13.5f, 0), Quaternion.identity);
        fairy3.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy3.direction = new Vector3(-1, 0, 0);
        fairy3.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy3.itemDrop = 2;
        fairy3.noForCirc = 5;
        fairy3.shotTimer = -15;
        fairy3.shotDelay = 30;
        fairy3.offsetInc = 5;

        Enemy fairy4 = Instantiate(a, new Vector3(-12, 13.5f, 0), Quaternion.identity);
        fairy4.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy4.direction = new Vector3(1, 0, 0);
        fairy4.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy4.itemDrop = 1;
        fairy4.noForCirc = 5;
        fairy4.shotTimer = -15;
        fairy4.shotDelay = 30;
        fairy4.offsetInc = -5;

        yield return new WaitForSeconds(1);

        Enemy fairy5 = Instantiate(a, new Vector3(4, 13.5f, 0), Quaternion.identity);
        fairy5.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy5.direction = new Vector3(-1, 0, 0);
        fairy5.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy5.itemDrop = 1;
        fairy5.noForCirc = 5;
        fairy5.shotTimer = -15;
        fairy5.shotDelay = 30;
        fairy5.offsetInc = 5;

        Enemy fairy6 = Instantiate(a, new Vector3(-12, 13.5f, 0), Quaternion.identity);
        fairy6.setParameters(1, .05f, 0, .05f, .05f, 1, false, 30);
        fairy6.direction = new Vector3(1, 0, 0);
        fairy6.setShotParameters(3, .075f, 0, .075f, .075f, 1, false);
        fairy6.itemDrop = 2;
        fairy6.noForCirc = 5;
        fairy6.shotTimer = -15;
        fairy6.shotDelay = 30;
        fairy6.offsetInc = -5;

        //Wave 3: While wave 2 is moving, 2 rows from top come in and U-turn out. Aimed shots at player. 5 per row.

        Enemy fairy7 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy7.direction = new Vector3(0, -1, 0);
        fairy7.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy7.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy7.shotDelay = 60;
        fairy7.shotTimer = -15;
        fairy7.itemDrop = 2;

        Enemy fairy8 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy8.direction = new Vector3(0, -1, 0);
        fairy8.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy8.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy8.shotDelay = 60;
        fairy8.shotTimer = -15;
        fairy8.itemDrop = 2;

        yield return new WaitForSeconds(.5f);

        Enemy fairy9 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        fairy9.direction = new Vector3(0, -1, 0);
        fairy9.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy9.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy9.shotDelay = 60;
        fairy9.shotTimer = -15;
        fairy9.itemDrop = 1;

        Enemy fairy10 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        fairy10.direction = new Vector3(0, -1, 0);
        fairy10.setParameters(1, .05f, 0, .05f, .05f, 1, false, 15);
        fairy10.setShotParameters(1, .1f, 0, .1f, .1f, 1, false);
        fairy10.shotDelay = 60;
        fairy10.shotTimer = -15;
        fairy10.itemDrop = 1;

        yield return new WaitForSeconds(.5f);

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

        fairy7.mvtFxn = 2;
        fairy7.deltaAngle = -3;
        fairy7.moveTimer = 60;
        fairy8.mvtFxn = 2;
        fairy8.deltaAngle = 3;
        fairy8.moveTimer = 60;

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

        fairy9.mvtFxn = 2;
        fairy9.deltaAngle = -3;
        fairy9.moveTimer = 60;
        fairy10.mvtFxn = 2;
        fairy10.deltaAngle = 3;
        fairy10.moveTimer = 60;

        yield return new WaitForSeconds(.5f);

        fairy11.mvtFxn = 2;
        fairy11.deltaAngle = -3;
        fairy11.moveTimer = 60;
        fairy12.mvtFxn = 2;
        fairy12.deltaAngle = 3;
        fairy12.moveTimer = 60;
        yield return new WaitForSeconds(.5f);

        fairy13.mvtFxn = 2;
        fairy13.deltaAngle = -3;
        fairy13.moveTimer = 60;
        fairy14.mvtFxn = 2;
        fairy14.deltaAngle = 3;
        fairy14.moveTimer = 60;

        yield return new WaitForSeconds(3);
        //Wave 4: Big fairy pops in from top left to center, create rotating circle pattern as it curves out at 120 degrees. Same from opposite direction.
        Enemy fairy15 = Instantiate(a, new Vector3(-12, 17, 0), Quaternion.identity);
        fairy15.transform.localScale *= 1.5f;
        fairy15.direction = GlobalFxns.ToVect(-45);
        fairy15.setParameters(1, .05f, 0, .05f, .05f, 1, false, 75);
        fairy15.setShotParameters(7, .1f, 0, .1f, .1f, 1, false);
        fairy15.offsetInc = 15;
        fairy15.noForCirc = 6;
        fairy15.shotDelay = 30;
        fairy15.shotTimer = -15;
        fairy15.itemDrop = 2;

        Enemy fairy16 = Instantiate(a, new Vector3(4, 17, 0), Quaternion.identity);
        fairy16.transform.localScale *= 1.5f;
        fairy16.direction = GlobalFxns.ToVect(225);
        fairy16.setParameters(1, .05f, 0, .05f, .05f, 1, false, 75);
        fairy16.setShotParameters(7, .1f, 0, .1f, .1f, 1, false);
        fairy16.offsetInc = -15;
        fairy16.noForCirc = 6;
        fairy16.shotDelay = 30;
        fairy16.shotTimer = -15;
        fairy16.itemDrop = 2;

        yield return new WaitForSeconds(2);
        fairy15.mvtFxn = 2;
        fairy15.deltaAngle = 1;
        fairy15.moveTimer = 45;
        fairy16.mvtFxn = 2;
        fairy16.deltaAngle = -1;
        fairy16.moveTimer = 45;

        yield return new WaitForSeconds(8);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(1);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(1);

        //Midboss: Mimic MoF stage 2 big fairy. Add homing burst shots.
        Enemy midboss2 = Instantiate(a, new Vector3(-4, 21, 0), Quaternion.identity);
        midboss2.setParameters(1, .05f, 0, .05f, .05f, 1, false, 1500);
        midboss2.setShotParameters(8, .05f, 0, .05f, .05f, 1, false);
        midboss2.offsetInc = 15;
        midboss2.transform.localScale *= 1.5f;
        midboss2.shotTimer = -150;
        midboss2.shotDelay = 30;
        midboss2.itemDrop = 4;
        midboss2.direction = new Vector3(0, -1, 0);
        yield return new WaitForSeconds(2);
        midboss2.velocity = 0;

        yield return new WaitForSeconds(25);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(3);

        //Wave 5: Row of 10 moves in, loops in a big circle while shooting at center before leaving. Same from opp direction.

        //Final wave: Repeat of suicide ghosts, but this time with 2 fairies that shoot in circles moving clockwise/counterclockwise.

        Enemy ghost11 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost11.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost11.shotType = 6;
        ghost11.itemDrop = 1;
        ghost11.amplitude = .25f;
        ghost11.lr = false;
        ghost11.mvtScale = .2f;

        Enemy ghost12 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost12.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost12.shotType = 6;
        ghost12.itemDrop = 1;
        ghost12.amplitude = .25f;
        ghost12.lr = true;
        ghost12.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost13 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost13.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost13.shotType = 6;
        ghost13.itemDrop = 2;
        ghost13.amplitude = .25f;
        ghost13.lr = false;
        ghost13.mvtScale = .2f;

        Enemy ghost14 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost14.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost14.shotType = 6;
        ghost14.itemDrop = 2;
        ghost14.amplitude = .25f;
        ghost14.lr = true;
        ghost14.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost15 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost15.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost15.shotType = 6;
        ghost15.itemDrop = 1;
        ghost15.amplitude = .25f;
        ghost15.lr = false;
        ghost15.mvtScale = .2f;

        Enemy ghost16 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost16.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost16.shotType = 6;
        ghost16.itemDrop = 1;
        ghost16.amplitude = .25f;
        ghost16.lr = true;
        ghost16.mvtScale = .2f;

        Enemy altFairy1 = Instantiate(a, new Vector3(-1, 22, 0), Quaternion.identity);
        altFairy1.direction = new Vector3(0, -1, 0);
        altFairy1.setParameters(1, .05f, 0, .05f, .05f, 1, false, 200);
        altFairy1.setShotParameters(3, .025f, 0, .025f, .025f, 1, false);
        altFairy1.offsetInc = 15;
        altFairy1.noForCirc = 8;
        altFairy1.shotTimer = -180;
        altFairy1.shotDelay = 45;
        altFairy1.itemDrop = 3;
        Enemy altFairy2 = Instantiate(a, new Vector3(-7, 22, 0), Quaternion.identity);
        altFairy2.direction = new Vector3(0, -1, 0);
        altFairy2.setParameters(1, .05f, 0, .05f, .05f, 1, false, 200);
        altFairy2.setShotParameters(3, .025f, 0, .025f, .025f, 1, false);
        altFairy2.offsetInc = -15;
        altFairy2.noForCirc = 8;
        altFairy2.shotTimer = -180;
        altFairy2.shotDelay = 45;
        altFairy2.itemDrop = 3;

        yield return new WaitForSeconds(.5f);

        Enemy ghost17 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost17.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost17.shotType = 6;
        ghost17.itemDrop = 2;
        ghost17.amplitude = .25f;
        ghost17.lr = false;
        ghost17.mvtScale = .2f;

        Enemy ghost18 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost18.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost18.shotType = 6;
        ghost18.itemDrop = 2;
        ghost18.amplitude = .25f;
        ghost18.lr = true;
        ghost18.mvtScale = .2f;

        yield return new WaitForSeconds(.5f);

        Enemy ghost19 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost19.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost19.shotType = 6;
        ghost19.itemDrop = 1;
        ghost19.amplitude = .25f;
        ghost19.lr = false;
        ghost19.mvtScale = .2f;

        Enemy ghost20 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost20.setParameters(3, .1f, 0, .1f, .1f, 1, false, 10);
        ghost20.shotType = 6;
        ghost20.itemDrop = 1;
        ghost20.amplitude = .25f;
        ghost20.lr = true;
        ghost20.mvtScale = .2f;

        yield return new WaitForSeconds(1);
        altFairy1.velocity = 0;
        altFairy2.velocity = 0;

        yield return new WaitForSeconds(15);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(3);

        //Spawn Boss
        Boss2 boss = Instantiate(b, new Vector3(-4, 22, 0), Quaternion.identity);
    }
}

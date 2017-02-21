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
        //Wave 1: Suicide ghosts. 10 from each side of the screen, sine mvt.
        Enemy ghost1 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost1.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost1.shotType = 6;
        ghost1.itemDrop = 1;
        ghost1.amplitude = .25f;
        ghost1.lr = false;

        Enemy ghost2 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost2.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost2.shotType = 6;
        ghost2.itemDrop = 1;
        ghost2.amplitude = .25f;
        ghost2.lr = true;

        yield return new WaitForSeconds(.5f);

        Enemy ghost3 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost3.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost3.shotType = 6;
        ghost3.itemDrop = 2;
        ghost3.amplitude = .25f;
        ghost3.lr = false;

        Enemy ghost4 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost4.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost4.shotType = 6;
        ghost4.itemDrop = 2;
        ghost4.amplitude = .25f;
        ghost4.lr = true;

        yield return new WaitForSeconds(.5f);

        Enemy ghost5 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost5.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost5.shotType = 6;
        ghost5.itemDrop = 1;
        ghost5.amplitude = .25f;
        ghost5.lr = false;

        Enemy ghost6 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost6.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost6.shotType = 6;
        ghost6.itemDrop = 1;
        ghost6.amplitude = .25f;
        ghost6.lr = true;

        yield return new WaitForSeconds(.5f);

        Enemy ghost7 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost7.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost7.shotType = 6;
        ghost7.itemDrop = 2;
        ghost7.amplitude = .25f;
        ghost7.lr = false;

        Enemy ghost8 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost8.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost8.shotType = 6;
        ghost8.itemDrop = 2;
        ghost8.amplitude = .25f;
        ghost8.lr = true;

        yield return new WaitForSeconds(.5f);

        Enemy ghost9 = Instantiate(a1, new Vector3(-12, 18, 0), Quaternion.identity);
        ghost9.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost9.shotType = 6;
        ghost9.itemDrop = 1;
        ghost9.amplitude = .25f;
        ghost9.lr = false;

        Enemy ghost10 = Instantiate(a1, new Vector3(4, 17, 0), Quaternion.identity);
        ghost10.setParameters(3, .25f, 0, .25f, .25f, 5, false, 10);
        ghost10.shotType = 6;
        ghost10.itemDrop = 1;
        ghost10.amplitude = .25f;
        ghost10.lr = true;

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

        //Wave 4: Big fairy pops in from top left to center, create rotating circle pattern as it curves out at 120 degrees. Same from opposite direction.

        //Midboss: Mimic MoF stage 2 big fairy. Add homing burst shots.

        //Wave 5: Row of 10 moves in, loops in a big circle while shooting at center before leaving. Same from opp direction.

        //Final wave: Repeat of suicide ghosts, but this time with 2 fairies that shoot in circles moving clockwise/counterclockwise.

        yield return new WaitForSeconds(10);

        Controller.Instance.clearScreen = true;

        yield return new WaitForSeconds(2);

        Controller.Instance.clearScreen = false;

        yield return new WaitForSeconds(3);

        //Spawn Boss
        Boss2 boss = Instantiate(b, new Vector3(-4, 22, 0), Quaternion.identity);
    }
}

using System;
using System.Collections;
using UnityEngine;

public class shoot : sounds
{
    public GameObject bullet; // Префаб пули
    public Transform bulletSpawn; // Точка появления пули
    public int damage = 10; 
    public static bool canshot = false;
    public static float CD = 0.5f;
    public static int summbaff = 100;

    void Update()
    {
        if (canshot && !MAgazine.inmagazine)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }
    }

    void Shoot()
    {
        PlaySound(soundes[0]);
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(newBullet, 1f);
    }

    IEnumerator Cooldown()
    {
        canshot = false;
        yield return new WaitForSeconds(CD);
        canshot = true;
    }

    public void UpSpeedShoot()
    {
        if (score.summ >= summbaff)
        {
            PlaySound(soundes[1]);
            CD -= 0.05f;
            summbaff += summbaff;
        }
    }
}

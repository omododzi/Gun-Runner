using System;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet; // Префаб пули
    public Transform bulletSpawn; // Точка появления пули
    public int damage = 10; 
    public static bool canshot = false;
    public static float CD = 0.5f;

   

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
        // Создаем пулю
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(newBullet, 1f);
    }

    IEnumerator Cooldown()
    {
        canshot = false;
        yield return new WaitForSeconds(CD);
        canshot = true;
    }
}

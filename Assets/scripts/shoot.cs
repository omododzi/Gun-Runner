using System;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet; // Префаб пули
    public Transform bulletSpawn; // Точка появления пули
    public int damage = 10; 
    public bool canshot = true;
    public static float CD = 0.5f;

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canshot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создаем пулю
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        StartCoroutine(Cooldown());



        Destroy(newBullet, 1f);
    }

    IEnumerator Cooldown()
    {
        canshot = false;
        yield return new WaitForSeconds(CD);
        canshot = true;
    }
}

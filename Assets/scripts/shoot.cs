using System;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;       // Префаб пули
    public Transform bulletSpawn;   // Точка появления пули
    public float bulletSpeed = 80f; // Скорость пули
    public int damage = 10;         // Урон пули

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создаем пулю
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Wait();
        
        // Получаем Rigidbody пули и задаем скорость
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = bulletSpawn.forward * bulletSpeed;
        }

        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

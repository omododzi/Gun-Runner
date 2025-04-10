using System;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody rb;
    public static float bulletSpeed = 80f; // Скорость пули
    public Transform bulletSpawn; // Точка появления пули
    public static int summbaff = 100;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletSpawn = GameObject.FindGameObjectWithTag("bulletSpawn").transform;
    }
    // Получаем Rigidbody пули и задаем скорость
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trap")|| other.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        rb.linearVelocity = bulletSpawn.forward * bulletSpeed;
    }

   
   
}

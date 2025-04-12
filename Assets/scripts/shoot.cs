using System;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullets; // Префаб пули
    public Transform bulletSpawn; // Точка появления пули
    public static int damage = 10; 
    public static bool canshot = false;
    public static float CD = 0.5f;
    public static int summbaff = 100;
    public AudioClip[] soundes ;
    private AudioSource source => GetComponent<AudioSource>();
    

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
        if (SwitshMusic.musicstate)
        {
            PlaySound(soundes[0]);
        }
        GameObject newBullet = Instantiate(bullets, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(newBullet, 1f);
    }

    IEnumerator Cooldown()
    {
        canshot = false;
        yield return new WaitForSeconds(CD);
        canshot = true;
    }

   
   
    public void PlaySound(AudioClip clip, float volume = 0.5f)
    {
        source.pitch = 1;
        source.PlayOneShot(clip, volume);
    }
}

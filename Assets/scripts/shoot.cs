using System;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullets; // Префаб пули
    public Transform bulletSpawn; // Точка появления пули
    public int damage = 10; 
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

    public void UpSpeedShoot()
    {
        if (score.summ >= summbaff)
        {
            score.summ -= summbaff;
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[1]);
            }
            CD -= 0.05f;
            summbaff += summbaff;
        }
    }
    public void Upspeedbullet()
    {
        if (score.summ >= summbaff)
        {
            score.summ -= summbaff;
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[1]);
            }
            bullet.bulletSpeed += 10;
            bullet.summbaff += bullet.summbaff;
        }
    }
    public void PlaySound(AudioClip clip, float volume = 0.5f)
    {
        source.pitch = 1;
        source.PlayOneShot(clip, volume);
    }
}

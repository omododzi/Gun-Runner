using System;
using UnityEngine;
using TMPro;
public class MAgazine : MonoBehaviour
{
    public static GameObject start;
    public static GameObject baff1;
    public static GameObject baff2;
    public static GameObject baff3;
    public static bool inmagazine = true;
    public GameObject upgann;
    public GameObject upspeedBullet;
    public GameObject upspeedShoot;
    public GameObject MusicOff;
    public GameObject MusicOn;

    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start");
        baff1 = GameObject.FindGameObjectWithTag("Baff1");
        baff2 = GameObject.FindGameObjectWithTag("Baff4");
        baff3 = GameObject.FindGameObjectWithTag("Baff3");
        upgann.SetActive(false);
        upspeedBullet.SetActive(false);
        upspeedShoot.SetActive(false);
        MusicOff.SetActive(false);
        MusicOn.SetActive(true);
    }
    public static void Inmagaz()
    {
        inmagazine = true;
        start.SetActive(true);
        baff1.SetActive(true);
        baff2.SetActive(true);
        baff3.SetActive(true);
        move.canMove = false;
    }

    private void Update()
    {
        if (!inmagazine)
        {
            start.SetActive(false);
            baff1.SetActive(false);
            baff2.SetActive(false);
            baff3.SetActive(false);   
        }

        if (inmagazine && score.summ >= spawn.summbaff && spawn.ourgan <= 4)
        {
            upgann.SetActive(true);
        }
        else
        {
            upgann.SetActive(false);
        }

        if (inmagazine && score.summ >= shoot.summbaff)
        {
            upspeedShoot.SetActive(true);
        }
        else
        {
            upspeedShoot.SetActive(false);
        }

        if (inmagazine && score.summ >= bullet.summbaff)
        {
            upspeedBullet.SetActive(true);
        }
        else
        {
            upspeedBullet.SetActive(false);
        }

        if (SwitshMusic.musicstate)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            MusicOff.SetActive(true);
            MusicOn.SetActive(false);
        }
    }
}

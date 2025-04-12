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

    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start");
        baff1 = GameObject.FindGameObjectWithTag("Baff1");
        baff2 = GameObject.FindGameObjectWithTag("Baff4");
        baff3 = GameObject.FindGameObjectWithTag("Baff3");
        upgann.SetActive(false);
        upspeedBullet.SetActive(false);
        upspeedShoot.SetActive(false);
    }
    public static void Inmagaz()
    {
        inmagazine = true;
        start.SetActive(true);
        baff1.SetActive(true);
        baff2.SetActive(true);
        baff3.SetActive(true);
    }

    private void Update()
    {
        if (inmagazine && score.summ >= spawn.summbaff)
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
    }
}

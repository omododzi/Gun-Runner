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
    public TMP_Text upgann;
    public TMP_Text upspeedBullet;
    public TMP_Text upspeedShoot;

    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start");
        baff1 = GameObject.FindGameObjectWithTag("Baff1");
        baff2 = GameObject.FindGameObjectWithTag("Baff4");
        baff3 = GameObject.FindGameObjectWithTag("Baff3");
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
        //upspeedBullet.text = " "+ bullet.summbaff;
        //upspeedShoot.text = " " + shoot.summbaff;
        //upgann.text = " " + spawn.summbaff;
    }
}

using System;
using UnityEngine;
using TMPro;
using YG;
public class score : MonoBehaviour
{
    public static int summ;

    void Start()
    {
        summ =YandexGame.savesData.money ;
    }
  
}

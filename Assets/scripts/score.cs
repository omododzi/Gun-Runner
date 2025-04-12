using System;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TMP_Text tmpText;
    public static int summ = 100;

    void Update()
    {
        tmpText.text = "" + summ;
    }
}

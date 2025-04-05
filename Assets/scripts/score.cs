using System;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TMP_Text tmpText;
    public static int summ = 0;

    void FixedUpdate()
    {
        tmpText.text = "" + summ;
    }
}

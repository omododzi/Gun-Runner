using System;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    public GameObject start;
    public GameObject baff1;
    public GameObject baff2;
    public GameObject baff3;
    
    

   

    public void OnButtonClick()
    {
        MAgazine.inmagazine = false;
        start.SetActive(false);
        baff1.SetActive(false);
        baff2.SetActive(false);
        baff3.SetActive(false);
        move.canMove = true;
        shoot.canshot = true;
       
    }
  
}

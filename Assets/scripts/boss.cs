using System;
using UnityEngine;

public class boss : MonoBehaviour
{
  private int hp = 1000;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Bllet"))
    {
      
    }
  }

  void Dead()
  {
    
  }
}

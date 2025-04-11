using System;
using UnityEngine;

public class SwitshMusic : MonoBehaviour
{
   public static bool musicstate = true;
   private byte state = 0;

   public void MusicSwitsh()
   {
      if (state == 0)
      {
         state = 1;
      }
      else
      {
         state = 0;
      }
   }

   private void Update()
   {
      if (state == 0)
      {
         musicstate = true;
      }else if (state == 1)
      {
         musicstate = false;
      }
   }
}

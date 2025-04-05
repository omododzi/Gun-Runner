using UnityEngine;

public class spawn : MonoBehaviour
{
   public GameObject[] Bafs;
   private GameObject[] spawnpoints;
   private int dontpowtor = 10;
   private int spawncount = 0;

   public GameObject[] Floor;
   public int spawnedfloor = 1;
   public int floorsize = 176;
   
   public GameObject[] Boss;
   public GameObject[] bossspawnpoints;
   public int bosscount = 0;

   

   void Update()
   {
      if (spawnedfloor <= 4)
      {
         Spawnfloor();
      }
      Spawnbafs();
      SpawnBoss();
   }

   public void Spawnfloor()
   {
      int randindex = Random.Range(0, Floor.Length);
      Vector3 pos = new Vector3(209.6f - floorsize, 0.0121555f, 25.9f);
      Instantiate(Floor[0], pos, Quaternion.identity);
      spawnedfloor++;
      floorsize += 176;
      
   }

   public void Spawnbafs()
   {
      spawnpoints = GameObject.FindGameObjectsWithTag("Spawntarg");
      for (; spawncount < spawnpoints.Length; spawncount++)
      {
         int randindex = Random.Range(0, Bafs.Length);
         if (dontpowtor != randindex)
         {  
            Instantiate(Bafs[randindex], spawnpoints[spawncount].transform.position, Quaternion.identity);
         }
         else
         {
            Instantiate(Bafs[0], spawnpoints[spawncount].transform.position, Quaternion.identity);
         }
         dontpowtor = randindex;
      }
   }

   public void SpawnBoss()
   {
      bossspawnpoints = GameObject.FindGameObjectsWithTag("bossSpawn");
      for (; bosscount < bossspawnpoints.Length; bosscount++)
      {
         int randindex = Random.Range(0, Boss.Length);
         Instantiate(Boss[randindex], bossspawnpoints[bosscount].transform.position, Quaternion.identity);
      }
   }
}

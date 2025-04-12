using UnityEngine;
using UnityEngine.UIElements;

public class spawn : MonoBehaviour
{
   public GameObject[] Bafs;
   private GameObject[] spawnpoints;
   private int dontpowtor = 10;
   private int spawncount = 0;

   public GameObject[] Floor;
   public static int spawnedfloor = 1;
   private int floorsize = 980;
   
   public GameObject[] Boss;
   public GameObject[] bossspawnpoints;
   public int bosscount = 0;

   public GameObject[] Bonus;
   public GameObject[] Bonusspawnpoints;
   public int bonuscount = 0;

   public GameObject[] guns;
   public static int summbaff = 100;
   public static int ourgan = 0;
   private Vector3 basespawn = new Vector3(697.05f, 3.96f, 27.48f);
   private Quaternion rotation = Quaternion.Euler(0, -90, 0);
   private GameObject spawnedgun;
   
   public AudioClip[] soundes ;
   private AudioSource source => GetComponent<AudioSource>();

   void Start()
   {
      if (ourgan == 0)
      {
         spawnedgun = Instantiate(guns[0], basespawn,rotation);
      }
   }

   void Update()
   {
      if (spawnedfloor <= 4)
      {
         Spawnfloor();
      }
      Spawnbafs();
      SpawnBoss();
      SpawnBonus();
   }

   public void Spawnfloor()
   {
      int randindex = Random.Range(0, Floor.Length);
      Vector3 pos = new Vector3(-235.7f - floorsize, -42.56367f, -217f);
      Floor[randindex].transform.position = Vector3.zero;
      Instantiate(Floor[0], pos, Quaternion.identity);
      spawnedfloor++;
      floorsize += 980;
   }

   public void Spawnbafs()
   {
      spawnpoints = GameObject.FindGameObjectsWithTag("Spawntarg");
      for (; spawncount < spawnpoints.Length; spawncount++)
      {
         int randindex = Random.Range(0, Bafs.Length);
         if (dontpowtor != randindex)
         {
            if (randindex == 1)
            {
               float deff = Random.Range(-8f, 8f);
               Vector3 randDeff = new Vector3(spawnpoints[spawncount].transform.position.x, spawnpoints[spawncount].transform.position.y, spawnpoints[spawncount].transform.position.z - deff);
               Instantiate(Bafs[randindex], randDeff, Quaternion.identity);
            }
            else
            {
               Instantiate(Bafs[randindex], spawnpoints[spawncount].transform.position, Quaternion.identity);
            }
         }
         else
         {
            randindex = Random.Range(0, Bafs.Length);
            Instantiate(Bafs[randindex], spawnpoints[spawncount].transform.position, Quaternion.identity);
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

   void SpawnBonus()
   {
      Bonusspawnpoints = GameObject.FindGameObjectsWithTag("BonusSpawn");
      for (; bonuscount < Bonus.Length; bonuscount++)
      {
         int randindex = Random.Range(0, Bonus.Length);
         Instantiate(Bonus[randindex], Bonusspawnpoints[bonuscount].transform.position, Quaternion.identity);
      }
   }

   public void Upgans()
   {
      if (score.summ >= summbaff && ourgan <=4 )
      {
         score.summ -= summbaff;
         if (SwitshMusic.musicstate)
         {
            PlaySound(soundes[0]);
         }
         ourgan++;
         Destroy(spawnedgun);
         spawnedgun = Instantiate(guns[ourgan],basespawn, rotation);
         summbaff *= 2;
      }
   }
   public void Upspeedbullet()
   {
        
      if (score.summ >= bullet.summbaff)
      {
         score.summ -= bullet.summbaff;
         if (SwitshMusic.musicstate)
         {
            PlaySound(soundes[0]);
         }
         bullet.bulletSpeed += 10;
         bullet.summbaff *= 2;
      }
   }
   public void UpSpeedShoot()
   {
      if (score.summ >= shoot.summbaff)
      {
         score.summ -= shoot.summbaff;
         if (SwitshMusic.musicstate)
         {
            PlaySound(soundes[0]);
         }
         shoot.CD -= 0.05f;
         shoot.summbaff *= 2;
      }
   }
   public void PlaySound(AudioClip clip, float volume = 0.5f)
   {
      source.pitch = 1;
      source.PlayOneShot(clip, volume);
   }
}

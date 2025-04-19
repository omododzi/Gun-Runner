using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using YG;
public class spawn : MonoBehaviour
{
   public GameObject[] Bafs;
   private List<GameObject> spawnpoints = new List<GameObject>();
   private int dontpowtor = 10;
   private int spawncount = 0;

   public GameObject[] Floor;
   public static int spawnedfloor = 0;
   private int floorsize = 0;
   
   public GameObject[] Boss;
   private List<GameObject> bossspawnpoints = new List<GameObject>();
   public int bosscount = 0;

   public GameObject[] Bonus;
   private List<GameObject> Bonusspawnpoints= new List<GameObject>();
   public int bonuscount = 0;

   public GameObject[] guns;
   public static int summbaff = 100;
   public static int ourgan = 0;
   private Vector3 basespawn = new Vector3(690f, 4f, 25f);
   private Quaternion rotation = Quaternion.Euler(0, -90, 0);
   private GameObject spawnedgun;
   
   public AudioClip[] soundes ;
   private AudioSource source => GetComponent<AudioSource>();

   private List<GameObject> spawned = new List<GameObject>();

   private int upgreadedgun;
   private int upgreadebullet;
   private int upgreadespeedshoot;

   void Start()
   {
      if (ourgan == 0)
      {
         spawnedgun = Instantiate(guns[0], basespawn,rotation);
      }

      upgreadedgun = YandexGame.savesData.upgn;
      upgreadespeedshoot =  YandexGame.savesData.speedshoot;
      upgreadebullet =  YandexGame.savesData.ubbullet;
      for (int i  = 0; i  < upgreadedgun; i ++)
      {
         ourgan++;
         Destroy(spawnedgun);
         spawnedgun = Instantiate(guns[ourgan],basespawn, rotation);
         summbaff *= 2;
      }

      for (int i = 0; i < upgreadespeedshoot; i++)
      {
         shoot.CD -= 0.05f;
         shoot.summbaff *= 2;
      }

      for (int i = 0; i < upgreadebullet; i++)
      {
         bullet.bulletSpeed += 10;
         bullet.summbaff *= 2;
      }
   }

   void Update()
   {
      if (spawnedfloor <= 2)
      {
         Spawnfloor();
      }
      Spawnbafs();
      SpawnBoss();
      SpawnBonus();
      if (move.restarting)
      {
         Reconstructoion();
      }
   }

   public void Spawnfloor()
   {
      int randindex = Random.Range(0, Floor.Length);
      Vector3 pos = new Vector3(-235.7f - floorsize, -42.56367f, -217f);
      Floor[randindex].transform.position = Vector3.zero;
      spawned.Add(Instantiate(Floor[0], pos, Quaternion.identity));
      spawnedfloor++;
      floorsize += 992;
      spawnpoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawntarg"));
      bossspawnpoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("bossSpawn"));
      Bonusspawnpoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("BonusSpawn"));
   }

   public void Spawnbafs()
   {
      for (; spawncount < spawnpoints.Count; spawncount++)
      {
         int randindex = Random.Range(0, Bafs.Length);
         if (dontpowtor != randindex)
         {
            if (randindex == 1)
            {
               float deff = Random.Range(-8f, 8f);
               Vector3 randDeff = new Vector3(spawnpoints[spawncount].transform.position.x, spawnpoints[spawncount].transform.position.y, spawnpoints[spawncount].transform.position.z - deff);
               spawned.Add(Instantiate(Bafs[randindex], randDeff, Quaternion.identity));
            }
            else
            {
               spawned.Add(Instantiate(Bafs[randindex], spawnpoints[spawncount].transform.position, Quaternion.identity));
            }
         }
         else
         {
            randindex = Random.Range(0, Bafs.Length);
            spawned.Add(Instantiate(Bafs[randindex], spawnpoints[spawncount].transform.position, Quaternion.identity));
         }
         dontpowtor = randindex;
      }
   }

   public void SpawnBoss()
   {
      for (; bosscount < bossspawnpoints.Count; bosscount++)
      {
         int randindex = Random.Range(0, Boss.Length);
         spawned.Add(Instantiate(Boss[randindex], bossspawnpoints[bosscount].transform.position, Quaternion.identity));
      }
   }

   void SpawnBonus()
   {
      for (; bonuscount < Bonusspawnpoints.Count; bonuscount++)
      {
         int randindex = Random.Range(0, Bonus.Length);
         spawned.Add(Instantiate(Bonus[randindex], Bonusspawnpoints[bonuscount].transform.position, Quaternion.identity));
      }
   }

   private void Reconstructoion()
   {
      // Уничтожаем все созданные объекты
      for (int i = 0; i < spawned.Count; i++)
      {
         if (spawned[i] != null)
            Destroy(spawned[i]);
      }
      spawned.Clear();
    
      // Полный сброс состояния
      spawnedfloor = 0;
      floorsize = 0;
      spawncount = 0; // Важно! Сбрасываем счетчик
      dontpowtor = 10; // Сбрасываем значение
      bosscount = 0;
      spawnpoints.Clear();
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

using System;
using System.Collections;
using UnityEngine;

public class boss : MonoBehaviour
{ public static int maxhpboss;
  private int hp =1;
  private int maney;
  private bool getmoney = false;
  private Animator animator;
  public  int speed =10;
  private bool fight = false;
  private Transform player;
  public AudioClip[] soundes;
  private AudioSource source => GetComponent<AudioSource>();
  private bool cansound = true;
  void Start()
  {
     
      maxhpboss += 100;
      hp = maxhpboss;
      wall.wallmaxhp += 10;
      maney = hp;
      animator = GetComponent<Animator>();
      animator.SetBool("issleep", true);
  }

  void OnCollisionEnter(Collision other)
  {
      if (other.gameObject.CompareTag("Bullet"))
      {
          if (SwitshMusic.musicstate)
          {
              if (cansound)
              {
                  PlaySound(soundes[0]);
                  StartCoroutine(SoundKD());
                  
              }
          }
          animator.SetBool("issleep", false);
          hp -= shoot.damage;
          fight = true;
      }

      if (other.gameObject.CompareTag("Player") && fight && hp>=1)
      {
          animator.SetTrigger("atak");
          move.infight = false;
          StartCoroutine(Coldown());
      }
  }

  void OnTriggerEnter(Collider other)
  {
      if (other.CompareTag("Player"))
      {
          animator.SetBool("issleep", false);
          fight = true;
          move.canMove = false;
      }
  }

  void Update()
  {
      if (player == null)
      {
          player = GameObject.FindGameObjectWithTag("Player").transform;
      }
      if (fight && hp > 0)
      {
          Debug.Log(hp);
          Vector3 direction = (player.position - transform.position).normalized;


          transform.position += direction * speed * Time.deltaTime;

          transform.rotation = Quaternion.Slerp(
              transform.rotation, 
              Quaternion.LookRotation(direction), 
              10f * Time.deltaTime
          );
      }

      
      if (hp <= 0)
      {
          if (SwitshMusic.musicstate)
          {
              PlaySound(soundes[1]);
          }
          animator.SetTrigger("die");
          spawn.spawnedfloor--;
          score.summ += maney;
          maxhpboss += 200;
          fight = false;
          move.infight = false;
          move.canMove = true;
          Destroy(gameObject,0.1f);
          
      }
  }

  private void OnDestroy()
  {
      move.canMove = true;
      move.infight = false;
      //MAgazine.inmagazine = false;
  }

  IEnumerator Coldown()
  {
      yield return new WaitForSeconds(0.3f);
      fight = false;
      animator.SetBool("issleep", true);
      move.restarting = true;
  }
  public void PlaySound(AudioClip clip, float volume = 0.5f)
  {
      source.pitch = 1;
      source.PlayOneShot(clip, volume);
  }

  IEnumerator SoundKD()
  {
      cansound = false;
      yield return new WaitForSeconds(0.5f);
      cansound = true;
  }
}

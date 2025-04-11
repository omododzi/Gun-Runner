using System.Collections;
using UnityEngine;

public class boss : MonoBehaviour
{ public static int maxhpboss;
  private int hp = maxhpboss += 10;
  private int maney;
  private bool getmoney = false;
  private Animator animator;
  public  int speed =10;
  private Rigidbody RB;
  private shoot _shoot;
  private bool fight = false;
  private Transform player;
  public AudioClip[] soundes;
  private AudioSource source => GetComponent<AudioSource>();
  void Start()
  {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      maxhpboss += 100;
      hp = maxhpboss;
      wall.wallmaxhp += 10;
      maney = hp;
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        _shoot = new shoot();
        animator.SetBool("issleep", true);
   
  }

  void OnCollisionEnter(Collision other)
  {
      if (other.gameObject.CompareTag("Bullet"))
      {
          if (SwitshMusic.musicstate)
          {
              PlaySound(soundes[0]);
          }
          hp -= _shoot.damage;
          animator.SetBool("issleep", false);
          fight = true;
      }

      if (other.gameObject.CompareTag("Player"))
      {
          animator.SetTrigger("atak");
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
      if (fight && hp > 0)
      {
          Vector3 direction = (player.position - transform.position).normalized;

// Движение (инвертировано из-за неправильной оси forward)
          transform.position += direction * speed * Time.deltaTime;

// Поворот
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
          Destroy(gameObject,0.5f);
          score.summ += maney;
          maxhpboss += 200;
          hp = 1000;
          move.infight = false;
          move.canMove = true;
          MAgazine.Inmagaz();
      }
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
}

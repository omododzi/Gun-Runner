using System.Collections;
using UnityEngine;

public class boss : MonoBehaviour
{
  public static int hp = 100;
  private int maney;
  private bool getmoney = false;
  private Animator animator;
  public static int speed = 5;
  private Rigidbody RB;
  private shoot _shoot;
  private bool fight = false;
  void Start()
  {
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
          RB.linearVelocity = new Vector3(speed, 0, 0);
      }

      if (hp <= 0)
      {
          animator.SetTrigger("die");
          Destroy(gameObject,0.5f);
          score.summ += maney;
          hp = 1000;
      }
  }

  IEnumerator Coldown()
  {
      yield return new WaitForSeconds(0.3f);
      move.restarting = true;
  }
}

using System;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 _input;
    public float moveSpeed = 10f;
    private Rigidbody Rb;
    private bool isfighting = false;
    public GameObject restartTxT;
    public static bool restarting = false;
    private Vector3 startpos;
    public static bool canMove = false;
    private spawn _spawn;
    private shoot _shoot;
    private float speedup;
    public static bool infight = false;
    private Transform Boss;
    public AudioClip[] soundes = new AudioClip[6];
    private AudioSource source => GetComponent<AudioSource>();

    void Start()
    {
        boss.maxhpboss = 100;
        Rb = GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
        _spawn = new spawn();
        _shoot = new shoot();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            restarting = true;
            canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            canMove = false;
            infight = true;
            Boss = other.transform;
        }
        if (other.CompareTag("Coin"))
        {
            PlaySound(soundes[0]);
            score.summ += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Speed"))
        {
            PlaySound(soundes[0]);
            moveSpeed += 2;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Star"))
        {
            PlaySound(soundes[0]);
            score.summ += 100;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("minus"))
        {
            PlaySound(soundes[0]);
            _shoot.damage -= 10;
        }
        else if (other.CompareTag("plus"))
        {
            PlaySound(soundes[0]);
            _shoot.damage += 10;
        }
    }
    
    

    void Update()
    {
        if (!MAgazine.inmagazine){
            speedup = Time.deltaTime;
        }

        if (speedup % 10 == 0 && speedup > 1)
        {
            moveSpeed += 1f;
        }
        
        if (canMove)
        {
            Move();
        }
        else
        {
            Rb.linearVelocity = Vector3.zero;
        }
        
        if (restarting)
        {
            gameObject.transform.position = startpos;
            MAgazine.Inmagaz();
            canMove = false;
            shoot.canshot = false;
            boss.maxhpboss = 100;
            restarting = false;
        }

        if (infight)
        {
            Vector3 direction = (Boss.position - transform.position).normalized;
            // Поворот
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                Quaternion.LookRotation(direction), 
                10f * Time.deltaTime
            );
        }
    }
    
    public void Move()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Rb.linearVelocity = new Vector3(-moveSpeed, Rb.linearVelocity.y,_input.x * moveSpeed);
    }
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        source.pitch = 1;
        source.PlayOneShot(clip, volume);
    }
}

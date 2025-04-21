using System;
using System.Collections;
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
    private float speedup;
    public static bool infight = false;
    private Transform Boss;
    private MAgazine _magazine = new MAgazine();
    public AudioClip[] soundes = new AudioClip[6];
    private AudioSource source => GetComponent<AudioSource>();

    void Start()
    {
        boss.maxhpboss = 100;
        Rb = GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
        _spawn = new spawn();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            MAgazine.inmagazine = true;
            restarting = true;
            canMove = false;
            _magazine.Inmagaz();
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
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[0]);
            }
            score.summ += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Speed"))
        {
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[0]);
            }
            moveSpeed += 2;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Star"))
        {
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[0]);
            }
            score.summ += 100;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("minus"))
        {
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[0]);
            }
            shoot.damage -= 10;
        }
        else if (other.CompareTag("plus"))
        {
            if (SwitshMusic.musicstate)
            {
                PlaySound(soundes[0]);
            }
            shoot.damage += 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            canMove = true;
            infight = false;
            //MAgazine.inmagazine = false;
        }
    }
    
    

    void Update()
    {
        Debug.Log(MAgazine.inmagazine);
        if (MAgazine.inmagazine)
        {
            canMove = false;
        }
    
        if (canMove)
        {
            Move();
        }
        else
        {
            Rb.linearVelocity = Vector3.zero; // Полная остановка
        }
    
        if (restarting)
        {
            restarting = false; // Сразу сбрасываем флаг
            StartCoroutine(AdCooldown());
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
        }else if (Boss == null)
        {
            infight = false;
        }

        if (!infight && !MAgazine.inmagazine)
        {
            canMove = true;
        }
        if (!infight)
        {
            gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
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

    IEnumerator AdCooldown()
    {
        // Полный сброс перед ожиданием
        gameObject.transform.position = startpos;
        Rb.linearVelocity = Vector3.zero;
        canMove = false;
        MAgazine.inmagazine = true;
        shoot.canshot = false;
        _magazine.Inmagaz();
        boss.maxhpboss = 100;
    
        yield return new WaitForSeconds(1f);
    
        // После рекламы восстанавливаем управление
    
        YGadd.TryShowFullscreenAdWithChance(100);
    }
}

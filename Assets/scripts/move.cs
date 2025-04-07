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
    private MAgazine magazine;

    void Start()
    {
        boss.maxhpboss = 100;
        Rb = GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
        _spawn = new spawn();
        _shoot = new shoot();
        magazine = GetComponent<MAgazine>();
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
        }
        if (other.CompareTag("Coin"))
        {
            score.summ += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Speed"))
        {
            moveSpeed += 2;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Star"))
        {
            score.summ += 100;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("minus"))
        {
            _shoot.damage -= 10;
        }
        else if (other.CompareTag("plus"))
        {
            _shoot.damage += 10;
            Debug.Log(_shoot.damage);
        }
    }

    void Update()
    {
       
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
            magazine.Inmagaz();
            canMove = false;
            score.summ = 0;
            shoot.canshot = false;
            boss.maxhpboss = 100;
            moveSpeed = 10f;
            shoot.CD = 0.5f;
            _shoot.damage = 10;
            restarting = false;
        }
    }
    
    public void Move()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Rb.linearVelocity = new Vector3(-moveSpeed, Rb.linearVelocity.y,_input.x * moveSpeed);
    }
}

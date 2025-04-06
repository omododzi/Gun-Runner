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
    private MAgazine magazine;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
        _spawn = new spawn();
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
            restarting = false;
            canMove = false;
        }
    }
    
    public void Move()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Rb.linearVelocity = new Vector3(-moveSpeed, Rb.linearVelocity.y,_input.x * moveSpeed);
    }
}

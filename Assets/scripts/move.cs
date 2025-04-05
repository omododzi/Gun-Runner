using System;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 _input;
    public float moveSpeed = 10f;
    private Rigidbody Rb;
    private bool isfighting = false;
    public GameObject restartTxT;
    public bool restarting = false;
    private Vector3 startpos;
    public static bool canMove = false;

    private spawn _spawn;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
        _spawn = new spawn();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            restarting = true;
            canMove = false;
        }

        
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
        
        if (restarting)
        {
            gameObject.transform.position = startpos;
            buttonController.Magazine();
            restarting = false;
        }
    }
    
    public void Move()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Rb.linearVelocity = new Vector3(-moveSpeed, Rb.linearVelocity.y,_input.x * moveSpeed);
    }
}

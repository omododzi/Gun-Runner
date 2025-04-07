using System;
using UnityEngine;
using TMPro;
public class wall : MonoBehaviour
{
    public TMP_Text tmpText;
    public static int wallmaxhp;
    public int hp = wallmaxhp;
    private shoot _shoot;

    void Start()
    {
        _shoot = new shoot();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= _shoot.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tmpText.text = "" + hp;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

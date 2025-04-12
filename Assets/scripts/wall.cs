using System;
using UnityEngine;
using TMPro;
public class wall : MonoBehaviour
{
    public TMP_Text tmpText;
    public static int wallmaxhp;
    public int hp = wallmaxhp;

 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= shoot.damage;
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

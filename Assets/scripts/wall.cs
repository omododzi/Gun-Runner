using System;
using UnityEngine;
using TMPro;
public class wall : MonoBehaviour
{
    public TMP_Text tmpText;
    public int hp = 100;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= 10;
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

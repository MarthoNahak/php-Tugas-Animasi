using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        //hurt anim
        if (maxHealth <= 0)
        {
            Wafat();
        }
    }
    void Wafat()
    {
        Destroy(gameObject);
    }
}
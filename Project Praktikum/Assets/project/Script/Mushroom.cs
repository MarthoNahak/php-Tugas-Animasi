using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    Warrior wr;
    // Use this for initialization

    void Start()
    {
        //Warrior adl nama dari game object yg ada di hierarchy
        wr = GameObject.Find("Warrior").GetComponent<Warrior>();
    }
    // Update is called once per frame

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            wr.nyawa--;
        }
        if (wr.nyawa < 0)
        {
            wr.play_again = true;
        }
    }
}
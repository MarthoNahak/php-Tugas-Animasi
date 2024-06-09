using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyingEye : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    private Vector2 currentpos;
    Warrior wr;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentpos = GetComponent<Transform>().position;
        wr = GameObject.Find("Warrior").GetComponent<Warrior>();
    }
    // Update is called once per frame
    void Update()
    {
        float jarakdariplayer = Vector2.Distance(player.position, transform.position);
        if (jarakdariplayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentpos, speed * Time.deltaTime);
        }
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        health = 100;
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;

        if (health <= 0)
        {
            //player dies
            Die();

        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        move();
        turn();
    }

    void move()
    {
        speed = Vector3.Distance(transform.position, player.transform.position) * 0.2f;
        rb.velocity = transform.forward * speed;
        Debug.Log(speed);
    }

    void turn()
    {
        Quaternion rot = Quaternion.LookRotation(player.transform.position - transform.position, player.transform.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 1 + 1 * speed);
    }
}

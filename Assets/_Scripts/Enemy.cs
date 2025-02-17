﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Set in Inspector: Enemy")]

    public float speed = 10f;      // The speed in m/s

    public float fireRate = 0.3f;  // Seconds/shot (Unused)

    public float health = 10;

    public int score = 100;      // Points earned for destroying this



    // This is a Property: A method that acts like a field

    public Vector3 pos
    {                                                     // a


        get
        {

            return (this.transform.position);

        }

        set
        {

            this.transform.position = value;

        }

    }

    private BoundsCheck bndCheck;                                            // a



    void Awake()
    {                                                           // b

        bndCheck = GetComponent<BoundsCheck>();

    }

    void Update()
    {

        Move();



        if (bndCheck != null && bndCheck.offDown)
        {                      // a

            // We're off the bottom, so destroy this GameObject            // b

            Destroy(gameObject);                                         // b

        }

    }



    public virtual void Move()
    {                                             // b

        Vector3 tempPos = pos;

        tempPos.y -= speed * Time.deltaTime;

        pos = tempPos;

    }
    void OnCollisionEnter(Collision coll)
    {

        GameObject otherGO = coll.gameObject;                                  // a

        if (otherGO.tag == "ProjectileHero")
        {                               // b

            Destroy(otherGO);        // Destroy the Projectile

            Destroy(gameObject);     // Destroy this Enemy GameObject

        }
        else
        {

            print("Enemy hit by non-ProjectileHero: " + otherGO.name);     // c

        }

    }

}

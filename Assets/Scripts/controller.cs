using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class controller : MonoBehaviour
{
    private bool checkColl=false;
    public float force;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
            if (timer.NotPause)
            {
                /*
                Vector3 acceleration = Input.acceleration;
                rb.velocity = new Vector3(acceleration.x*15, 0, 0);
                if (Input.touchCount > 0)
                {
                jump();
                }
                */
                if (Input.GetKeyDown(KeyCode.RightArrow) & checkColl)
                    rb.velocity = new Vector3(10, rb.velocity.y, 0);
                if (Input.GetKeyDown(KeyCode.LeftArrow) & checkColl)
                    rb.velocity = new Vector3(-10, rb.velocity.y, 0);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jump();
                }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        checkColl = true;
    }
    void jump()
    {
        if (checkColl)
        {
            rb.velocity = new Vector3(rb.velocity.x,force);
            checkColl = false;

        }
    }
}

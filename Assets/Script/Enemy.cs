using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 0.1f;
    public bool neg;
    // Start is called before the first frame update
    void Start()
    {
        speed= neg?-speed:speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "BatasAtas")
        {
            speed = -0.1f;
        }
        if (coll.gameObject.name == "BatasBawah")
        {
            speed = 0.1f;
        }
    }
}

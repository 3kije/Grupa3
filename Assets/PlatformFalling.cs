using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{

    Rigidbody2D rb;
    public float timeFall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("PlatformFall", timeFall);
            Destroy(gameObject, 2f);
        }
    }
    void PlatformFall()
    {
        rb.isKinematic = false;
    }
}
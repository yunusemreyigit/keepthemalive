using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float x;
    private Rigidbody2D rigidbody;
    void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");

        transform.position += (Vector3)new Vector2(x * speed * Time.deltaTime, 0);
    }
    
}


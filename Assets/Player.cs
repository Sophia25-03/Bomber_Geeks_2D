using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    Rigidbody2D rd;
    float inputX;
    float inputY;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");

            rd.velocity = new Vector2(inputX, inputY) * speed;
        }
    }
}

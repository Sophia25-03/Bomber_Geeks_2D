using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Player : NetworkBehaviour
{
    public int coins;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pedindo uma pirulito para o Server!");
            TalkToServer();
        }
    }

    [Command]
    void TalkToServer()
    {
        Debug.Log("Player pediu um pirulito!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins++;
            MyNetworkManager.spawnedCoins--;
            Destroy(collision.gameObject);
        }
    }
}

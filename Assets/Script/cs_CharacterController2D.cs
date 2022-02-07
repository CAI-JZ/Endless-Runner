using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharacterController2D : MonoBehaviour
{
    Rigidbody2D m_ridgid;

    private float speed = 0;
    private bool IsBournd = false;

    public void StartGame()
    {
        speed = 30;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsBournd = true;
        }
    }


    void GameOver()
    {
        speed = 0;
        Debug.LogWarning("GameOver");
    }


    private void Move(float MoveOffset, bool IsBound)
    {  
        m_ridgid.AddForce(new Vector2(MoveOffset * 100, 0));
        m_ridgid.rotation = (MoveOffset * 20);
       
    }




    // Start is called before the first frame update
    void Start()
    {
        m_ridgid = GetComponent<Rigidbody2D>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        // MoveForward
        m_ridgid.MovePosition(new Vector2(transform.position.x, transform.position.y+speed * Time.deltaTime));

        // Move R/L
        float MoveInput = Input.GetAxis("Horizontal");
        Move(MoveInput,IsBournd);
    }

    private void FixedUpdate()
    {
       
    }
}

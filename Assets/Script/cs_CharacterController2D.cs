using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharacterController2D : MonoBehaviour
{
    Rigidbody2D m_ridgid;

    private float speed = 0;

    public void StartGame()
    {
        speed = 10;

    }

    private void Move(float MoveOffset)
    {
        //m_ridgid.velocity = new Vector2(MoveOffset * Time.deltaTime*6, 0);
        m_ridgid.AddForce(new Vector2(MoveOffset*100, 0));

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
        Move(MoveInput);
    }

    private void FixedUpdate()
    {
       
    }
}

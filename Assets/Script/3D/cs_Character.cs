using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Character : MonoBehaviour
{
    cs_CharacterController controller;
    Animator Anim;

    public float speed = 0;
    public float JumpHight = 400;
    public float DashDistance = 500;
    //public Object CheckGournd;

    
    private bool IsJump;
    private bool IsRoll;
    private bool IsDash;


    public void StartGame()
    {
        speed = 5;
        Anim.SetBool("IsRun", true);
        
    }

    public void GameOver()
    {
        speed = 0;
        controller.Die();
        Debug.Log("GameOver");
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        controller = GetComponent<cs_CharacterController>();
        
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
       
        
        IsJump = Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W);
        IsRoll = Input.GetKeyDown(KeyCode.S);
        IsDash = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.D);

        if (IsJump)
        {
            controller.Jump(JumpHight);
        }

        if (IsDash)
        {
            controller.Dash(DashDistance);
        }

        if (IsRoll)
        {
            controller.Roll();
        }

    }

    private void FixedUpdate()
    {
        //Move
        GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, speed * Time.deltaTime));



       

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cs_CharacterController : MonoBehaviour
{
    private Animator m_Anim;
    private Rigidbody m_Ridgid;
    private CapsuleCollider m_Collider;

    private bool IsOnGround;

    private Vector3 RollCollisionCenter = new Vector3(0, 0.5f, 0);
    private float RollCollisionHight = 1;
    private Vector3 NormalCollisionCenter = new Vector3(0, 1f, 0);
    private float NormalCollisionHight = 2;

    private void ChangeCollider(Vector3 Center, float Hight)
    {
        m_Collider.center = Center;
        m_Collider.height = Hight;
    }


    public void Jump(float JumpHight)
    {
        if(IsOnGround)
        {
            m_Anim.CrossFade("JumpStart_HG01_Anim", 0.1f);
            m_Ridgid.AddForce(new Vector3(0, JumpHight, 0));
        }

    }

    public void Dash(float DashDistance)
    {
        m_Anim.CrossFade("DashFWD_HG01_Anim", 0.1f);
        m_Ridgid.AddForce(new Vector3(0, 0, DashDistance));
    }

    public void Roll()
    {
        m_Anim.CrossFade("RollFWD_HG01_Anim", 0.1f);
    }

    public void Die()
    {
        m_Anim.SetBool("IsDie", true);
    }



    void PhysicsCheck()
    {
        Vector3 pos = transform.position;
        Vector3 offset = new Vector3(0, 0.1f, 0);
        IsOnGround = Physics.Raycast(pos+offset, Vector3.down, 0.5f);     

        if (IsOnGround)
        {
            m_Anim.SetBool("IsGround", true);
            Debug.DrawRay(pos + offset, Vector3.down, Color.red, 0.4f);
        }
        else
        {
            m_Anim.SetBool("IsGround", false);
            Debug.DrawRay(pos + offset, Vector3.down, Color.green, 0.4f);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Ridgid = GetComponent<Rigidbody>();
        m_Collider = GetComponent<CapsuleCollider>();
    
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsCheck();
        
        //Change Collsion when roll
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("RollFWD_HG01_Anim"))
        {
            ChangeCollider(RollCollisionCenter, RollCollisionHight);
        }
        else 
        {
            ChangeCollider(NormalCollisionCenter, NormalCollisionHight);
        }
    }

    private void FixedUpdate()
    {

    }
}

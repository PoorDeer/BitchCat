using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGirlCtr : MonoBehaviour
{
    Animator anim;
    Transform trans;
    Rigidbody2D rigi;
    [SerializeField] LayerMask groundLayer = 0;

    CatGirlStatus catGirlStatus = CatGirlStatus.Idle;

    bool grounded;
    bool faceRight = false;

    public float moveSpeed_run = 10;
    public float moveSpeed_walk = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        trans = transform;
        rigi = GetComponent<Rigidbody2D>();

        ChangeCatStatue(CatGirlStatus.Run);
    }

    // Update is called once per frame
    void Update()
    {
        if (catGirlStatus == CatGirlStatus.Run || catGirlStatus == CatGirlStatus.Jump)
        {
            if (Input.GetButtonDown("Jump") && grounded && rigi.velocity.y <= 0)
            {
                ChangeCatStatue(CatGirlStatus.Jump);
            }

            if (!faceRight)
                transform.position -= new Vector3(moveSpeed_run * Time.deltaTime, 0, 0.0f);
            else
                transform.position += new Vector3(moveSpeed_run * Time.deltaTime, 0, 0.0f);
        }

        if (catGirlStatus == CatGirlStatus.Walk)
        {
            if (!Input.GetButton("Walk"))
            {
                ChangeCatStatue(CatGirlStatus.Run);
            }
            if (!faceRight)
                transform.position -= new Vector3(moveSpeed_walk * Time.deltaTime, 0, 0.0f);
            else
                transform.position += new Vector3(moveSpeed_walk * Time.deltaTime, 0, 0.0f);
        }

        Vector3 frontGround_pos = trans.position - trans.right;
        bool groundCheck_front = Physics2D.Raycast(frontGround_pos, -trans.up, 10f, groundLayer);  
        grounded = Physics2D.Raycast(trans.position, -trans.up, 2, groundLayer);

        if (Input.GetButton("Walk"))
        {
            ChangeCatStatue(CatGirlStatus.Walk);
        }

        if (!groundCheck_front)
        {
            faceRight = !faceRight;

            if(faceRight)
                trans.rotation = Quaternion.Euler(0, 180, 0);
            else
                trans.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void JumpToGround()
    {
        ChangeCatStatue(CatGirlStatus.Run);
    }

    void ChangeCatStatue(CatGirlStatus change_status)
    {
        if (catGirlStatus == change_status) return;

        switch (change_status)
        {
            case CatGirlStatus.Idle:
                anim.Play("Idle");
                break;
            case CatGirlStatus.Walk:
                anim.Play("Walk");
                break;
            case CatGirlStatus.Run:
                anim.Play("Run");
                break;
            case CatGirlStatus.Jump:
                anim.Play("Jump");
                rigi.AddForce(Vector2.up * 300);
                Invoke("JumpToGround", 1.3f);
                break;
            case CatGirlStatus.SawaMango:
                anim.Play("Masturbating"); 
                break;
            case CatGirlStatus.ijiaU:
                anim.Play("Masturbating_Squirt");
                break;
            default:
                break;
        }

        catGirlStatus = change_status;
    }
}

public enum CatGirlStatus
{
    Idle,
    Walk,
    Run,
    Jump,
    SawaMango,
    ijiaU
};

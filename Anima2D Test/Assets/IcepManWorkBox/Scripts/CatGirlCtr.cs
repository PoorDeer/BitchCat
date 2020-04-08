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

    public float fallM = 2.5f; // 完整跳躍後的墜落速度
    public float lowJumpM = 2f; // 提早放開跳躍鍵的墜落速度

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
        if (catGirlStatus == CatGirlStatus.Run)
        {
            if (!faceRight)
                transform.position -= new Vector3(moveSpeed_run * Time.deltaTime, 0, 0.0f);
            else
                transform.position += new Vector3(moveSpeed_run * Time.deltaTime, 0, 0.0f);
        }
            
        Vector3 frontGround_pos = trans.position - trans.right;
        bool groundCheck_front = Physics2D.Raycast(frontGround_pos, -trans.up, 10f, groundLayer);
   
        bool groundCheck = Physics2D.Raycast(trans.position, -trans.up, 2, groundLayer);
  
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rigi.AddForce(Vector2.up * 300);
 
        }

        if (rigi.velocity.y < 0) // 停止往上時
        {
            rigi.velocity += Vector2.up * Physics2D.gravity.y * fallM * Time.deltaTime;
        }
        else if (rigi.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigi.velocity += Vector2.up * Physics2D.gravity.y * lowJumpM * Time.deltaTime;
        }

        if (groundCheck)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (!groundCheck_front)
        {
            faceRight = !faceRight;

            if(faceRight)
                trans.rotation = Quaternion.Euler(0, 180, 0);
            else
                trans.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {

        }

        if (Input.GetButtonDown("Walk"))
        {
            
        }
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

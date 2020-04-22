using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleCtr : MonoBehaviour
{
    Animator anim;

    int orderNum = 0;
    bool shooting;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        ShootOrder();
        orderNum = 3;
    }

    public void ShootOrder()
    {
        orderNum++;
        if (!shooting)
        {
            anim.Play("Atk");
            shooting = true;
        }
    }

    public void ShootDone()
    {
        orderNum--;
        if (orderNum > 0)
        {
            anim.Play("AtkCombo");
        }
        else
        {
            anim.Play("Idle");
            shooting = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    Transform trans;
    void Start()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bom_prefab;
    [SerializeField] GameObject hit_prefab;
    //public float moveSpeed;
    //Transform trans;
    //void Start()
    //{
    //    trans = transform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    trans.Translate(0, moveSpeed * Time.deltaTime, 0);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject ef_clone = Instantiate(bom_prefab);
            ef_clone.transform.position = transform.position;
            ef_clone.transform.rotation = Quaternion.Euler(0, 0, 90);
            ef_clone.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            Destroy(ef_clone, 5);
        }
        if (collision.gameObject.tag == "Player")
        {
            GameObject ef_clone = Instantiate(hit_prefab);
            ef_clone.transform.position = transform.position;
            ef_clone.transform.rotation = Quaternion.Euler(0, 0, 47);
            ef_clone.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            Destroy(ef_clone, 5);
        }
        //Destroy(gameObject);
    }
}

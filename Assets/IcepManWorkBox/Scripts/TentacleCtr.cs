using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleCtr : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        ShootOrder();
    }
    void Update()
    {
   
    }

    public void ShootOrder()
    {
        float nextShoot_T = Random.Range(TentacleBrain.nextShoot_Time, 8);
        StartCoroutine(ShootOrder(nextShoot_T));
    }

    IEnumerator ShootOrder(float toShoot_t)
    {
        yield return new WaitForSeconds(toShoot_t);
        anim.Play("Atk");
 
        yield return new WaitForSeconds(2.5f);

        ShootOrder();
    }
}

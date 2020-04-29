using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleBrain : MonoBehaviour
{
    int[] fireOrder = new int[20];

    int fireNum = 5;//攻擊的砲管數

    void Start()
    {
        for (int i = 0; i < fireNum; i++)
        {
            fireOrder[i] = Random.Range(1, 20);

            for (int j = 0; j < i; j++)
            {
                if (fireOrder[j] == fireOrder[i])
                {
                    j = 0;
                    fireOrder[i] = Random.Range(0, 10);
                }
            }
        }
    }

    void Update()
    {
        
    }
}

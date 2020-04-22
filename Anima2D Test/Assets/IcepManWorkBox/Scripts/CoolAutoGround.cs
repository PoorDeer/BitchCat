using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolAutoGround : MonoBehaviour
{
    Transform trans;

    bool toBig = false;
    float changeTime = 2;

    bool onWork = true;

    public float powerLevel = 0.01f;

    void Start()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (onWork)
        {
            if (trans.localScale.x < 5)
            {
                powerLevel = 0.08f;
            }
            trans.localScale += new Vector3(powerLevel, 0, 0);
            changeTime -= Time.deltaTime;

            if (changeTime < 0)
            {
                changeTime = Random.Range(1, 2);
                if (powerLevel < 0)
                {
                    powerLevel = Random.Range(0.01f, 0.05f);
                }
                else
                    powerLevel = Random.Range(-0.03f, -0.05f);
            }
        }
  
    }

    public void StopChageSize()
    {
        onWork = false;
    }
}

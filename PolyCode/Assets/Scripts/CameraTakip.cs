using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTakip : MonoBehaviour
{


    public Transform target;
    Vector3 distance;
    public float sValue;

    // Start is called before the first frame update
    void Start()
    {

        distance = target.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y  >=0)
        {
            Takip();
        }
        
    }


    void Takip()
    {
        Vector3 currentPos = transform.position;

        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, sValue * Time.deltaTime);
    }
}

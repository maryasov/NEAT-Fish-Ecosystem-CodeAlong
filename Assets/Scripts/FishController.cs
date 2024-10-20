using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController: MonoBehaviour
{
    [Range(-1f, 1f)]
    public float a,t;
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        MoveFish(a, t);
    }

    public void MoveFish(float v, float h)
    {
        // Getting Next Position
        Vector3 input = Vector3.Lerp(Vector3.zero, new Vector3(0, v*2f, 0), 0.1f);
        input = transform.TransformDirection(input);

        // Movement of Agent
        transform.position += input;

        // Rotation of Agent
        transform.eulerAngles += new Vector3(0, 0, (h*90)*0.1f);
    }
}

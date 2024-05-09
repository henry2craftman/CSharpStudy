using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    Vector3 targetPos;
    float currentTime = 0;
    bool isMovingToB = true;

    private void Start()
    {
        targetPos = targetB.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 2) currentTime = 0;

        transform.position = Vector3.Lerp(transform.position, targetPos, currentTime / 2);

        if(Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            if(isMovingToB)
            {
                isMovingToB = false;
                targetPos = targetA.position;
            }
            else
            {
                isMovingToB = true;
                targetPos = targetB.position;
            }
        }
    }
}

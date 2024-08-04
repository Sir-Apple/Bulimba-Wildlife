using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellowpalm : MonoBehaviour
{
    public float moveSpeed = 1;
    public float thinkingRate = 0.015f;
    public float maxMoveRange = 30;
    public float distanceOC;                                //Distance between original position and Current position
    public float lookRotateSpeed;
    public float randomDirectionRate;


    private Vector3 oriPosition;                            //Original position
    private Vector3 curPosition;                            //Current position
    private bool isAlive = true;
    private bool isOutRange;                                //is out of max range
    private Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        isOutRange = false;

        oriPosition = transform.position;
        lookRotateSpeed = 1f;

        StartCoroutine(Thinking());
        StartCoroutine(RandomDirection());
    }

    IEnumerator Thinking()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(thinkingRate);

            distanceOC = Vector3.Distance(oriPosition, transform.position);//Distance between original position and Current position

            if (distanceOC > maxMoveRange)
            {
                isOutRange = true;
                //Start IEnumerator
                StartCoroutine(GoBackToOriPosition());

            }

            if (!isOutRange)
            {
                Move();
            }
        }
    }

    private void Move()
    {


        //Move - roam
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    IEnumerator GoBackToOriPosition()
    {
        while (Vector3.Distance(oriPosition, transform.position) >= 5)
        {
            yield return new WaitForSeconds(thinkingRate);

            //Look at original position
            GlobalTools.Instance.LookAtObject(oriPosition, transform, lookRotateSpeed);

            //Move
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        isOutRange = false;
    }

    IEnumerator RandomDirection()
    {
        while (isAlive)
        {
            direction = Random.rotation;

            direction.x = 0;
            direction.z = 0;
            direction.w = 1;
            transform.rotation = direction;
            yield return new WaitForSeconds(randomDirectionRate);
        }

    }
}

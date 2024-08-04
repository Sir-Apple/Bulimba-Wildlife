using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Tree_Snake : MonoBehaviour
{
    public GameObject player;
    public float roamSpeed;

    public float chaseRange;
    public float chaseSpeed;
    public float chaseTime;

    public float attackRange;
    public float attackRate;
    public int damage;

    public float maxMoveRange;

    public delegate void EnemyAttack(int dmg);
    private EnemyAttack enemyAttack;

    private bool isOutRange;                                //is out of max range

    public float thinkingRate;
    private bool isAlive;
    private float lookRotateSpeed;
    public float distance;                                  //Distance between player and snake
    public float distanceOC;                                //Distance between original position and Current position
    private Vector3 oriPosition;                            //Original position
    private Vector3 curPosition;                            //Current position

    public int losePointsByATK = 10;
    public float randomDirectionRate = 3f;
    public Quaternion direction;

    private AudioSource source;

    private void Start()
    {
        isAlive = true;
        isOutRange = false;

        oriPosition = transform.position;
        //thinkingRate = 0.2f;
        lookRotateSpeed = 1f;
        //Start IEnumerator
        StartCoroutine(Thinking());
        StartCoroutine(RandomDirection());

        //Add delegates
        enemyAttack += PlayerManager.Instance.DecHealth;
        enemyAttack += Bars.Instance.DecHealth;

        source = GetComponent<AudioSource>();
    }

    IEnumerator Thinking()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(thinkingRate);

            distance = Vector3.Distance(player.transform.position, transform.position); //distance between player and snake
            distanceOC = Vector3.Distance(oriPosition, transform.position); //Distance between original position and Current position

            if (distanceOC > maxMoveRange)
            {
                isOutRange = true;
                //Start IEnumerator
                StartCoroutine(GoBackToOriPosition());

            }

            if (distanceOC < maxMoveRange && !isOutRange)
            {
                
                if (distance < attackRange)
                {
                    popUpWindow();
                    Attack(damage); //Attack method
                    yield return new WaitForSeconds(attackRate); // one attack per second

                }
                else if (distance < chaseRange)
                {
                    snakeHiss();
                    //Face to player
                    GlobalTools.Instance.LookAtObject(player.transform, transform, lookRotateSpeed);

                    //Move - chase
                    transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);

                    
                }
                else if (distance > chaseRange)
                {
                    //Random direction
                    //transform.LookAt(new Vector3(0f,0f, direction));
                    direction.x = 0;
                    direction.z = 0;
                    direction.w = 1;
                    transform.rotation = direction;
                    //Move - roam
                    transform.Translate(Vector3.forward * roamSpeed * Time.deltaTime);

                    source.Stop();
                }
            }
        }
    }

    public void snakeHiss()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        
    }
    IEnumerator RandomDirection()
    {
        while (isAlive)
        {
            direction = Random.rotation;
            yield return new WaitForSeconds(randomDirectionRate);
        }

    }
    //If the snake reachs the max move range, it will go back to original position
    IEnumerator GoBackToOriPosition()
    {
        while (Vector3.Distance(oriPosition, transform.position) >= 5)
        {
            yield return new WaitForSeconds(thinkingRate);

            //Look at original position
            GlobalTools.Instance.LookAtObject(oriPosition, transform, lookRotateSpeed);

            //Move
            transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
        }

        isOutRange = false;
    }
    public void Attack(int dmg)
    {
        PointManager.Instance.DecPoints(losePointsByATK);
        enemyAttack(dmg);
        //Debug.Log("Attack: " + dmg);
    }

    public void popUpWindow()
    {
        GameManager.Instance.commonTreeSnakeInfoPopup();
    }
}

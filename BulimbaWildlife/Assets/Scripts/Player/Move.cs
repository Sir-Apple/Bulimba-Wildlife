using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float walkSpeed = 7f;
    public float fastMoveSpeed = 14f;
    public float moveSpeed = 7f;

    public GameObject standingModel;
    public GameObject flyingModel;
    private CharacterController CC;
    public float PositionX;
    public float PositionY;
    Animator anima;

    // This bool might be redundant now but kept just in case
    public bool isFastMove = false;

    public bool allowFlying = true;

    public AudioSource flying;
    public bool allowAttack;
    public GameObject AttackTarget;

    private Vector3 oriPosition;

    private void Start()
    {
        //Debug.Log("start");
        CC = this.gameObject.GetComponent<CharacterController>();
        anima = gameObject.GetComponent<Animator>();
        anima.SetBool("Walk", false);
        allowAttack = false;
        oriPosition = this.gameObject.transform.position;
    }
    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
    }
    //  Joystick move
    void OnJoystickMove(MovingJoystick move)
    {
        if (move.joystickName != "MoveJoystick")       //name of Joystick
        {
            return;
        }

        PositionX = move.joystickAxis.x;             //   Get offset X
        PositionY = move.joystickAxis.y;      //    Get offset Y

        if (PositionY != 0 || PositionX != 0)
        {                
            //  Current position and joystick's offset
            transform.LookAt(new Vector3(transform.position.x + PositionX, transform.position.y, transform.position.z + PositionY));
            anima.SetBool("Walk", true);

            //  Move
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            CC.Move(transform.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            anima.SetBool("Walk", false);
        }
    }

    public void FastMove()
    {
        if (allowFlying)
        {
            flying.Play();
            allowFlying = false;
            standingModel.SetActive(false);
            flyingModel.SetActive(true);
            moveSpeed = fastMoveSpeed;
            isFastMove = true;
            Vector3 curPos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(curPos.x, curPos.y + 3f, curPos.z);

            // Stops the player from flying after 4 seconds
            StartCoroutine(flyingCountdown(5));

            // Prevents the player from flying for a short amount of time
            StartCoroutine(flyingCooldown(9));
        }
    }

    IEnumerator flyingCountdown(float time)
    {
        yield return new WaitForSeconds(time);

        flying.Stop();
        standingModel.SetActive(true);
        flyingModel.SetActive(false);
        moveSpeed = walkSpeed;
        isFastMove = false;
        Vector3 curPos = this.gameObject.transform.position;
        //this.gameObject.transform.position = new Vector3(curPos.x, curPos.y - 3f, curPos.z);
        //this.gameObject.transform.position = oriPosition;
        this.gameObject.transform.position = new Vector3(curPos.x, oriPosition.y, curPos.z);
    }

    IEnumerator flyingCooldown(float time)
    {
        yield return new WaitForSeconds(time);

        allowFlying = true;
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Snake")
        {
            allowAttack = true;
            AttackTarget = other.gameObject;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Snake")
        {
            allowAttack = false;
            AttackTarget = null;
        }
    }

    public void attack()
    {
        if (allowAttack)
        {
            AttackTarget.GetComponent<EnemyHealth>().DecHealth();
        }
    }

    private void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
    }
}

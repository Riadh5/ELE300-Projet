using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class MLMoveAndCollect : Agent {

    [SerializeField] private Transform Coin;
    [SerializeField] private Transform Portal;

    public CharacterController2D controller;
    public Animator animator;

    private float runSpeed = 100f;
    bool jump = false;
    
    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(-5.94999981f, -1.75f, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Coin.position);
        sensor.AddObservation(Portal.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float HorizontalMove = actions.ContinuousActions[0];
        float Vjump = actions.ContinuousActions[1];

        float initialDistance = Vector3.Distance(transform.position, Portal.transform.position);

        if(HorizontalMove > 0f)
        {
            SetReward(0.1f);
        }

        if(HorizontalMove < 0f)
        {
            SetReward(-0.1f);
        }

        if (Vjump > 0f)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        //Animation Stuff
        if (HorizontalMove > 0.01f)
        {
            animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        }

        if (jump == true)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        controller.Move(HorizontalMove * Time.fixedDeltaTime * runSpeed, false, jump);

        float currentDistance = Vector3.Distance(transform.position, Portal.transform.position);

        if (currentDistance < initialDistance)
        {
            SetReward(1f);
        }
        else
        {
            SetReward(-1f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            SetReward(3f);

            EndEpisode();

            Debug.Log("Coin (+) REWARD");

        }

        if (other.gameObject.CompareTag("Death"))
        {
            SetReward(-1f);

            Debug.Log("Death (-) REWARD");
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            SetReward(10f);

            EndEpisode();

            Debug.Log("Portal (+) REWARD");
        }

        if (other.gameObject.CompareTag("Fail"))
        {
            SetReward(-100f);

            EndEpisode();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

}

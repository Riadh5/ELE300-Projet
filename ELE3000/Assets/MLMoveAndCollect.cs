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

    private float runSpeed = 75f;

    public GameObject SpawnPoint;

    public override void Initialize()
    {
        SpawnPoint.transform.position = new Vector3(-5.95f, -1.75f, 0f);
        Time.timeScale = 1f;
    }
    
    public override void OnEpisodeBegin()
    {
        transform.position = SpawnPoint.transform.position;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Portal.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float HorizontalMove = actions.DiscreteActions[1];
        bool Vjump = actions.DiscreteActions[0] == 1;

        if(HorizontalMove > 0.5f)
        {
            HorizontalMove = 1f;
        }
        else
        {
            HorizontalMove = -1f;
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

        if (Vjump == true)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        controller.Move(HorizontalMove * Time.fixedDeltaTime * runSpeed, false, Vjump);

        AddReward(-1 / MaxStep);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AddReward(1f);

            Debug.Log("Coin (+) REWARD");

        }

        if (other.gameObject.CompareTag("Death"))
        {
            AddReward(-1f);

            EndEpisode();

            Debug.Log("Death (-) REWARD");
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            AddReward(10f);

            EndEpisode();

            Debug.Log("Portal (+) REWARD");
        }

        if (other.gameObject.CompareTag("Fail"))
        {
            AddReward(-10f);

            EndEpisode();
        }

        if (other.gameObject.CompareTag("Flag"))
        {
            AddReward(1f);

            FindFarthestClone();

            Destroy(other.gameObject);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void FindFarthestClone()
    {
        GameObject[] allClones = GameObject.FindGameObjectsWithTag("clone");

        float farthestRight = float.MinValue;

        Vector3 farthestRightPosition = Vector3.zero;

        foreach (GameObject Clone in allClones)
        {
            if (Clone.transform.position.x > farthestRight)
            {
                farthestRight = Clone.transform.position.x;
                farthestRightPosition = Clone.transform.position;
            }
        }

        SpawnPoint.transform.position = farthestRightPosition;
        Instantiate(SpawnPoint);

        Debug.Log("New flag on : " + farthestRightPosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class MLMoveAndCollect : Agent {

    //Calling position inside unity
    [SerializeField] private Transform Coin;
    [SerializeField] private Transform Portal;

    //Calling needed functions
    public CharacterController2D controller;
    public Animator animator;

    //Calling necessary objects
    private float runSpeed = 60f;
    public GameObject SpawnPoint;
    public GameObject[] allRespawns;

    //Start position and time called at the beginning
    public override void Initialize()
    {
        SpawnPoint.transform.position = new Vector3(-5.95f, -1.75f, 0f);
        Time.timeScale = 1f;
    }
    
    //Every EpisodeEnd() this is called to respawn the gameObject
    public override void OnEpisodeBegin()
    {
        transform.position = SpawnPoint.transform.position;
    }

    //Collects the position of the clone and the portal to know where to end up
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Portal.position);
    }

    //Manages the movements and animator 
    public override void OnActionReceived(ActionBuffers actions)
    {
        //random values generated between 0 and 1 for movement and jumping
        float HorizontalMove = actions.DiscreteActions[1];
        bool Vjump = actions.DiscreteActions[0] == 1;

        //Creates a middle point for left and right movements AJOUTER UN RANDOM FAIL SAFE
        if(HorizontalMove > 0.5f)
        {
            HorizontalMove = 1f;
        }
        else
        {
            HorizontalMove = -1f;
        }

        //Animation Stuff [STILL BUGGED OUT]
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

        //Actual movement command
        controller.Move(HorizontalMove * Time.fixedDeltaTime * runSpeed, false, Vjump);

        //Incentive to do the minimum amount of movement possible
        AddReward(-1 / MaxStep);

    }

    //Reward structure
    private void OnTriggerEnter2D(Collider2D other)
    {
        // +1 on coin
        if (other.gameObject.CompareTag("Coin"))
        {
            AddReward(3f);

            Debug.Log("Coin (+) REWARD");

        }

        // -1 on death
        if (other.gameObject.CompareTag("Death"))
        {
            AddReward(-1f);

            EndEpisode();

            Debug.Log("Death (-) REWARD");
        }

        // +10 on portal
        if (other.gameObject.CompareTag("Portal"))
        {
            AddReward(10f);

            //Calls after win
            WeTheBest();
            DestroyFlag();
            
            // RandomPortal(); WORK IN PROGRESS

            EndEpisode();
        }

        // -10 on fail (fail is the caracter leaving the map)
        if (other.gameObject.CompareTag("Fail"))
        {
            AddReward(-10f);

            EndEpisode();
        }

        // +1 on flag or checkpoint
        if (other.gameObject.CompareTag("Flag"))
        {
            AddReward(1f);

            //Puts a flag/checkpoint on the farthest clone on set positions
            FindFarthestClone();

            other.gameObject.SetActive(false);
        }

    }

    //Animator stuff [BUGGED]
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    //Creates a flag where to farthest clone is
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
    }

    //After reaching a portal the following happens
    void WeTheBest()
    {
        SpawnPoint.transform.position = new Vector3(-5.95f, -1.75f, 0f);

        //Re-activates the checkpoints
        foreach (GameObject check in allRespawns)
        {
            check.SetActive(true);
        }

        GameObject[] allclones = GameObject.FindGameObjectsWithTag("clone");

        //Puts every clone back to the beginning
        foreach (GameObject clone in allclones)
        {
            clone.transform.position = SpawnPoint.transform.position;
        }

        GameObject[] allcoins = GameObject.FindGameObjectsWithTag("Coin");

        //Re-activates the coins in the level
        foreach (GameObject coin in allcoins)
        {
            coin.SetActive(true);
        }
    }

    //Removes flags
    void DestroyFlag()
    {
        GameObject[] OldFlags = GameObject.FindGameObjectsWithTag("Respawn");

        foreach (GameObject flag in OldFlags)
        {
            Destroy(flag);
        }
    }

    void RandomPortal()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                Portal.transform.position = new Vector3(43.4599991f, -2.61590004f, 0f);
                break;
            case 2:
                Portal.transform.position = new Vector3(36.5699997f, -2.61590004f, 0f);
                break;
            case 3:
                Portal.transform.position = new Vector3(38.8499985f, 1.94000006f, 0f);
                break;
            case 4:
                Portal.transform.position = new Vector3(25.6900005f, 1.41999996f, 0f);
                break;
            default:
                Debug.LogError("Invalid choice!");
                break;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    public float accelerationTime = 2f;
    private Vector2 movement;
    private float timeLeft;
    public float runSpeed = 40f;

    public CharacterController2D controller;
    public Animator animator;

    private float timer = 0f;
    private bool isUpdating = true;

    bool jump = false;

    public GameObject SpawnPoint;


    void Update()
    {
        timeLeft -= Time.deltaTime;

        bool Boolean = (Random.value > 0.5f);

        //Randomizer

        if (timeLeft <= 0)
        {
            jump = Boolean;

            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            timeLeft += accelerationTime;
        }

        //Animator stuff
        if (jump == true)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (movement[0] > 0.01f)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement[0]));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(movement[0]));
        }

        if (isUpdating)
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
            {
                isUpdating = false;
                StartCoroutine(StopUpdating());
            }
        }

        SpawnPoint.transform.position = Vector3.zero;

    }


    IEnumerator StopUpdating()
    {
        yield return new WaitForSeconds(10f);
        enabled = false;

        animator.SetBool("IsJumping", false);
        animator.SetFloat("Speed", 0f);

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

            Clone.SetActive(false);
        }

        Debug.Log("Farthest right object position: " + farthestRightPosition);

        SpawnPoint.transform.position = farthestRightPosition;

        Instantiate(SpawnPoint);

    }


    void FixedUpdate()
    {
        controller.Move(movement[0] * Time.fixedDeltaTime * runSpeed, false, jump);
        jump = false;

        isUpdating = true;

    }


    public void OnLanding()
    {
        // remet la valeur à 0 pour l'évenement d'atterissage
        animator.SetBool("IsJumping", false);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    Animator playerAnimator;
    NavMeshAgent navMeshAgent;
    bool pRunning = false;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                navMeshAgent.destination = hit.point;
            }
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            pRunning = false;
        }
        else
        {
            pRunning = true;
        }
        playerAnimator.SetBool("isRunning", pRunning);
    }
}


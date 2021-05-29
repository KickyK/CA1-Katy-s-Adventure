using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
 
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    /*void UpdateAnimator()
    {
        anim.SetBool("MovingForward", false);
        anim.SetBool("MovingBackward", false);
        anim.SetBool("MovingLeft", false);
        anim.SetBool("MovingRight", false);

       

        if (myAgent.z > 0.1f)
            anim.SetBool("MovingForward", true);
        else if(myAgent.z < -0.1f)
            anim.SetBool("MovingBackward", true);
        if (myAgent.x > 0.1f)
            anim.SetBool("MovingRight", true);
        else if (myAgent.x < -0.1f)
            anim.SetBool("MovingLeft", true);
    }
    */
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn)) {
                myAgent.SetDestination (hitInfo.point);
            }

        }
    }
}

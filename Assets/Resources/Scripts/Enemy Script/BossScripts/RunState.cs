using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : StateMachineBehaviour
{
    Rigidbody2D rb;
    Transform player;
    NavMeshAgent agent;
    BossController BossController;
    float punchRange = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossController = animator.GetComponent<BossController>();
        //player = BossController.PlayerToChase;
        agent = BossController.BossAgent;
        agent.isStopped = false;

        player = BossController.player;
        agent.destination = player.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (agent.remainingDistance <= agent.stoppingDistance && !stateInfo.IsName("BigPunchAnim"))
        //if((Mathf.Abs(Vector2.Distance(animator.transform.position,player.position)) <= punchRange) && !stateInfo.IsName("BigPunchAnim"))
        {
            agent.isStopped = true;
            animator.SetTrigger("BigPunch");
        }
        agent.destination = player.position;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}

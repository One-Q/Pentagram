using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        //Debug.Log("chase state !");
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        if (controller.chaseTarget != null)
        {
            controller.navMeshAgent.SetDestination(controller.chaseTarget.position);
            controller.navMeshAgent.isStopped = false;
        }
        

    }
}
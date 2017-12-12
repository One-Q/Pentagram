﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        //Debug.Log("patrol state !");
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.SetDestination(controller.wayPointList[controller.nextWayPoint].position);
        //controller.navMeshAgent.Resume();
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
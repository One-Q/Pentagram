using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(StateController controller)
    {

        
        GameObject player = (GameObject)GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(controller.gameObject.transform.position, player.transform.position);
        
        if (distance >= 20f) return false; // si le joueur sort de la zone l'enemy retourne en patrouille 

        bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
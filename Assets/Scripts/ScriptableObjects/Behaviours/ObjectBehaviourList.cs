using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Behaviours/ObjectBehavoiursList")]
public class ObjectBehaviourList : ObjectBehaviour {

	public ObjectBehaviour[] objectBehaviours;

	public override void Execute (GameObject obj){
		if(objectBehaviours.Length > 0 ){
			foreach (var items in objectBehaviours) {
				items.Execute (obj);
			}
		}
	}

}

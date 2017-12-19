using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName="Behaviours/DisplayGameOver")]
public class DisplayGameOverBehaviour : ObjectBehaviour {

	public override void Execute (GameObject obj)
	{
		SceneManager.LoadScene ("GameOver");
	}
	
}

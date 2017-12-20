using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Transform> wayPointsForAI;
    //private StateController m_StateController;
    public Transform spawnPoint;                          


    public List<GameObject> Enemy;
    public List<GameObject> Captain;

    
    // Use this for initialization
    void Start () {
        SetupAI(wayPointsForAI);

    }
	
	
    public void SetupAI(List<Transform> wayPointList)
	{

        for(int i=0; i<Enemy.Count; i++)
        {
            GameObject instance = Instantiate(Enemy[i], new Vector3(spawnPoint.position.x +i, spawnPoint.position.y+i, spawnPoint.position.z+i), spawnPoint.rotation,transform) as GameObject;
            StateController m_StateController = instance.GetComponent<StateController>();
            m_StateController.SetupAI(true, wayPointList);

        }



        for (int i = 0; i < Captain.Count; i++)
        {
            GameObject instance = Instantiate(Captain[i], new Vector3(spawnPoint.position.x + i, spawnPoint.position.y + i, spawnPoint.position.z + i), spawnPoint.rotation,transform) as GameObject;
            StateController m_StateController = instance.GetComponent<StateController>();
            m_StateController.SetupAI(true, wayPointList);

        }





    }

}

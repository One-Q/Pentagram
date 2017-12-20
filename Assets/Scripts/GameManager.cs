using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Transform> wayPointsForAI;
    //private StateController m_StateController;
    public Transform spawnPoint;                          


    public GameObject Instance;



    // Use this for initialization
    void Start () {
        SetupAI(wayPointsForAI);

    }
	
	
    public void SetupAI(List<Transform> wayPointList)
	{
        GameObject instance = Instantiate(Instance, spawnPoint.position, spawnPoint.rotation) as GameObject;
        StateController m_StateController = instance.GetComponent<StateController>();
        m_StateController.SetupAI(true, wayPointList);



    }

}

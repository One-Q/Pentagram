using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Transform> wayPointsForAI;
    private StateController m_StateController;

    // public GameObject[] m_Instance;
    public GameObject Instance;



    // Use this for initialization
    void Start () {
        SetupAI(wayPointsForAI);

    }
	
	
    public void SetupAI(List<Transform> wayPointList)
	{
        /*foreach (GameObject i in m_Instance)
        {
            m_StateController = i.GetComponent<StateController>();
            m_StateController.SetupAI(true, wayPointList);
        }*/
        m_StateController = Instance.GetComponent<StateController>();
        m_StateController.SetupAI(true, wayPointList);



    }

}

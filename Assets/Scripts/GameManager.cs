using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Transform> wayPointsForAI;
    private StateController m_StateController;

    public GameObject m_Instance;



    // Use this for initialization
    void Start () {
        SetupAI(wayPointsForAI);

    }
	
	
    public void SetupAI(List<Transform> wayPointList)
		{
			m_StateController = m_Instance.GetComponent<StateController> ();
			m_StateController.SetupAI (true, wayPointList);
		}

}

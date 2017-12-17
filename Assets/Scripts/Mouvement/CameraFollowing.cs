using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour {
	
		public GameObject obj;       

		private Vector3 offset;    

		// Use this for initialization
		void Start () 
		{
		offset = transform.position - obj.transform.position;
		}

		void Update () 
		{
            if(obj != null)
        {
            transform.position = obj.transform.position + offset;
        }
    }
	}

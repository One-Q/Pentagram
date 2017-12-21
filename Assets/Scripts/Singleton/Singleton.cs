using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Singleton<T> {
	//On doit spécifier le type donc where T:Singleton<T>
	private static T instance;

	public static T Instance{
		get { 
				if (!instance) {
					//Chercher sur la scéne l'instance
					instance = FindObjectOfType<T> ();
					//Si j'en trouve un
					if (!instance) {
						Debug.LogError ("There should be atleast one object of type " + typeof(T) + " on the scene");
					}
				}
				return instance;
			}
	}


	void Awake(){
		if (instance) {
			Destroy (gameObject);
		} else {
			instance = (T)this;
			DontDestroyOnLoad (this);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbItem : ScriptableObject{
		public string id;
		public string description;
		public string sprite;
		public string type;

		public void Init(string i, string d, string s,string t){
			this.id = i;
			this.description = d;
			this.sprite = s;
			this.type = t;
		}
}

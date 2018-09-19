using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour {
	public void ChangeScene( string sceneName){
		Application.LoadLevel(sceneName);
	}
}

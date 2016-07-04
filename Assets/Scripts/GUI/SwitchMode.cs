using UnityEngine;
using System.Collections;

public class SwitchMode : MonoBehaviour {
	private bool mode = true;
	public GameObject[] characters;
	public GameObject camera;


	void start(){
	}
	
	// Update is called once per frame
	public void ChangeMode() {
		characters = GameObject.FindGameObjectsWithTag("Player");
		camera = GameObject.FindWithTag("MainCamera");
		if (mode == true){
			characters[0].GetComponent<PlayerControl>().changeMode(false);
			camera.GetComponent<CameraController>().changeMode(false);
			mode = false;
		}else{
			characters[0].GetComponent<PlayerControl>().changeMode(true);
			camera.GetComponent<CameraController>().changeMode(true);
			mode = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Vector3 myPos = new Vector3(0, 20, -20);
	public Transform myPlay;
	private bool moveMode = true;
	 
	void Update()
	{
		if (moveMode == true){
            ControlMove();
        }else{
            ClickToMove();
        }
	}
	public void changeMode(bool newMode){
		moveMode = newMode;
		Debug.Log("ishouldchangecamaera");
	}
	
	void ControlMove () {
        Debug.Log("ControlMove");
    }

    void ClickToMove (){
        Debug.Log("ClickToMove");
        transform.localRotation =  Quaternion.Euler(40,0,0);
       	transform.position = myPlay.position + myPos;
    }	
}

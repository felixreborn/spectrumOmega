using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Vector3 myPos;
	public Transform myPlay;
	 
	void Update()
	{
	   transform.position = myPlay.position + myPos;
	}
	// Use this for initialization
	void Start () {
	
	}
	
}

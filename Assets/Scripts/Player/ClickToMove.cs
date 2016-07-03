using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	// Use this for initialization
	private Vector3 target;
	private float speed = 5;
	private bool moveTo = false;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move (){
		if (Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, 2000)){
				target = hit.point;
				// Debug.Log("Where i want to go");
				// Debug.Log(hit.point);
				// Debug.Log("Where i am");
				// Debug.Log(transform.position);
				moveTo = true;
				//navigationAgent.SetDestination(hit.point);
			}
		}
		if (moveTo == true){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		if (moveTo && (transform.position.x < target.x+0.5 && transform.position.x > target.x-0.5) && (transform.position.z < target.z+0.5 && transform.position.z > target.z-0.5)){
			Debug.Log("I AM HERE");
			moveTo = false;
		}
		
	}
}

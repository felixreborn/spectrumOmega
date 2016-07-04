using UnityEngine;
using System.Collections;
  
public class PlayerControl : MonoBehaviour
{
    public Transform myCamera;
    private Vector3 target;
    Vector2 rot;
    private float speed = 5;
    private bool moveTo = false;
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
        Debug.Log("ishouldchangeplayer");
    }
        
    
    void ControlMove () {
        Debug.Log("ControlMove");
        myCamera.position = transform.position;
        myCamera.localRotation = transform.localRotation;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward,out hit, 100 ))
            {
                TerrainL.SetBlock(hit, new BlockAir());
            }
        }
  
        rot= new Vector2(
            rot.x + Input.GetAxis("Mouse X") ,
            rot.y + Input.GetAxis("Mouse Y"));
 
        transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);
  
        transform.position += (transform.forward * Input.GetAxis("Vertical"))/speed;
        transform.position += (transform.right * Input.GetAxis("Horizontal"))/speed;
    }

    void ClickToMove (){
        Debug.Log("ClickToMove");
        if (Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100)){
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 movimiento;
    public CharacterController cont;
    Vector2 mousePosition;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if(playerPlane.Raycast(ray, out hitDist)){
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.z = Input.GetAxisRaw("Vertical");
        cont.Move(movimiento * speed * Time.deltaTime);
        //Vector2 anterior = mousePosition;
        //mousePosition = Input.mousePosition;
        /*if(anterior != mousePosition)
        {
            Debug.Log(mousePosition);
            Debug.Log(Screen.width);
            Debug.Log(Screen.height);
        }*/
    }
    private void FixedUpdate()
    {
        
    }
}

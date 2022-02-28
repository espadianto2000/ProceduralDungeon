using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 3f;
    Vector3 movimiento;
    public CharacterController cont;
    Vector2 mousePosition;
    public Camera cam;
    public bool corriendo = false;
    public Animator animador;
    public gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camara").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if(playerPlane.Raycast(ray, out hitDist) && gm.InputEnable){
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.z = Input.GetAxisRaw("Vertical");
        if ((movimiento.x != 0 || movimiento.z != 0) && !animador.GetBool("corriendo") && gm.InputEnable)
        {
            corriendo = true;
            animador.SetBool("corriendo", true);
        }
        else if ((movimiento.x == 0 && movimiento.z == 0) && animador.GetBool("corriendo") && gm.InputEnable)
        {
            corriendo = false;
            animador.SetBool("corriendo", false);
        }
        if(gm.InputEnable)
        {
            cont.Move(movimiento * speed * Time.deltaTime);
        }
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && animador.GetCurrentAnimatorClipInfo(1)[0].clip.name != "Attack02" && gm.InputEnable)
        {
            animador.SetTrigger("atacar");
        }
    }
}

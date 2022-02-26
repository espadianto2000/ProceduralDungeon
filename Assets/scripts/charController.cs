using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 movimiento;
    public CharacterController cont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.x =Input.GetAxisRaw("Horizontal");
        movimiento.z = Input.GetAxisRaw("Vertical");
        cont.Move(movimiento * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        
    }
}

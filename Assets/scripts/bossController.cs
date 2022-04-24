using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public GameObject player;
    public float timer=5;
    public int estado=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            player = GameObject.Find("player");
        }
        catch
        {

        }
        if (player != null)
        {
            if(estado == 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }
            else if(estado == 1)
            {
                //ataque fuego
                Debug.Log("atacar fuego");
            }
            else if(estado == 2)
            {
                //ataque fisico
                Debug.Log("atacar fisico");
            }
            if(timer <= 0)
            {
                int atk = Random.Range(0, 2);
                switch (atk)
                {
                    case 0:
                        estado = 1;
                        break;
                    case 1:
                        estado = 2;
                        break;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    public void cambiarEstado()
    {
        estado = 0;
        timer = 4;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("obstaculo"))
        {
            Destroy(collision.gameObject);
        }
    }
}

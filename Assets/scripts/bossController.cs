using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public GameObject player;
    public float timer=5;
    public int estado=0;
    public Animator anim;
    private bool atk = false;
    private bool caminando = false;
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
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
                if (!caminando)
                {
                    anim.SetTrigger("caminar");
                    caminando = true;
                }
                Debug.Log("diferencia entre quaternions: " + (transform.rotation.normalized * targetRotation.normalized));
                if(Vector3.Distance(player.transform.position, transform.position) > 2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), 1f * Time.deltaTime);
                    /*if (!caminando)
                    {
                        anim.SetTrigger("caminar");
                        caminando = true;
                    }*/
                }
                else
                {
                    /*if (caminando)
                    {
                        anim.SetTrigger("pararCaminar");
                        caminando = false;
                    }*/
                }
            }
            else if(estado == 1 && !atk)
            {
                //ataque fuego
                Debug.Log("atacar fuego");
                anim.SetTrigger("atk1");
                atk = true;
            }
            else if(estado == 2 && !atk)
            {
                //ataque fisico
                Debug.Log("atacar fisico");
                anim.SetTrigger("atk2");
                atk = true;
            }
            if(timer <= 0)
            {
                caminando = false;
                if(Vector3.Distance(player.transform.position, transform.position) > 2.5f)
                {
                    estado = 1;
                }
                else
                {
                    estado = 2;
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
        atk = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("obstaculo"))
        {
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("sword") && player.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(1)[0].clip.name == "Clip1")
        {
            if (GetComponent<statsBoss1>().vulnerable)
            {
                GetComponent<statsBoss1>().vulnerable = false;
                GetComponent<statsBoss1>().recibirDano(player.GetComponent<statsJugador>().danoMelee, other.GetComponent<atacando>().player.transform.position, 0);
            } 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent agent;
    public statsEnemigo stats;
    public Vector3 posicionEstatica=new Vector3(0,0,0);
    public bool knock = false;
    private IEnumerator coroutine;
    Vector3 direction;
    public float knockSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        agent.speed = stats.velocidad;
        agent.acceleration = stats.velocidad * 2;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (!(/*Vector3.Distance(player.transform.position, transform.position) < 0.5f ||*/ knock))
        {
            //agent.updatePosition = true;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            knock = false;
            agent.velocity = direction * knockSpeed;
            agent.speed = stats.velocidad;
            agent.angularSpeed = 180;
            agent.acceleration = stats.velocidad * 2;
        }
    }

    void Update()
    {
        
        /*float distX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distZ = Mathf.Abs(transform.position.z - player.transform.position.z);*/
        
        /*else
        {
            posicionEstatica = transform.position;
            agent.SetDestination(posicionEstatica);
            agent.updatePosition = false;
        }*/
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        targetRotation.x = 0;
        targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        /*if (distX+distZ > 3f)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }*/

    }
    public void knocks(Vector3 dir, float knockbackMelee, int tipoAtaque)
    {
        StartCoroutine(knockback(dir,knockbackMelee,tipoAtaque));
    }
    IEnumerator knockback(Vector3 dir, float knockbackMelee, int tipoAtaque)
    {
        direction = dir.normalized;
        Debug.Log("direccion normalizada: " + dir.normalized);
        //Vector3 velocidadG = transform.GetComponent<Rigidbody>().velocity;
        //Vector3 velocidadAngG = transform.GetComponent<Rigidbody>().angularVelocity;
        //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if(tipoAtaque == 1)
        {
            knockSpeed = knockbackMelee *0.25f;
            knock = true;
            /*agent.speed = stats.velocidad;
            agent.angularSpeed = 0;
            agent.acceleration = stats.velocidad * 3;*/
            /*yield return new WaitForSeconds(0.05f);
            knock = false;
            agent.speed = stats.velocidad;
            agent.angularSpeed = 180;
            agent.acceleration = stats.velocidad * 2;*/
            yield return null;
            //transform.GetComponent<Rigidbody>().AddForce(dir.normalized * knockbackMelee, ForceMode.Impulse);
        }else if(tipoAtaque == 0)
        {
            knockSpeed = knockbackMelee * 2.5f;
            knock = true;
            /*agent.speed = stats.velocidad;
            agent.angularSpeed = 0;
            agent.acceleration = stats.velocidad * 3;*/
            /*yield return new WaitForSeconds(0.05f);
            knock = false;
            agent.speed = stats.velocidad;
            agent.angularSpeed = 180;
            agent.acceleration = stats.velocidad * 2;*/
            yield return null;
            //transform.GetComponent<Rigidbody>().AddForce(dir.normalized * knockbackMelee, ForceMode.Impulse);
        }
        /*
        if(tipoAtaque == 1)
        {
            //coroutine = activarKnock(velocidadG, velocidadAngG, 0.03f);
            //StartCoroutine(coroutine);
            //Invoke("activarKnock", 0.04f, velocidadG,velocidadAngG);
        }
        else if(tipoAtaque == 0)
        {
            //coroutine = activarKnock(velocidadG, velocidadAngG, 0.1f);
            //StartCoroutine(coroutine);
            //Invoke("activarKnock", 0.1f, velocidadG, velocidadAngG);
        }*/
    }
    IEnumerator activarKnock(Vector3 velocidadG, Vector3 velocidadAngG, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        knock = false;
        //transform.GetComponent<Rigidbody>().velocity = velocidadG;
        //transform.GetComponent<Rigidbody>().angularVelocity = velocidadAngG;
        //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return null;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<statsJugador>().recibirDano(this.GetComponent<statsEnemigo>().danoMelee);
        }
    }
}

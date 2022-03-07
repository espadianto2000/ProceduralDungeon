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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = stats.velocidad;
        agent.acceleration = stats.velocidad * 2;
        float distX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distZ = Mathf.Abs(transform.position.z - player.transform.position.z);
        if (Vector3.Distance(player.transform.position, transform.position) > 0.5f && !knock)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            posicionEstatica = transform.position;
            agent.SetDestination(posicionEstatica);
        }
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
    public void knockback(Vector3 dir, float knockbackMelee)
    {
        Debug.Log("empujando");
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().AddForce(dir.normalized * knockbackMelee, ForceMode.Impulse);
        knock = true;
        Invoke("activarKnock", 0.075f);

    }
    void activarKnock()
    {
        knock = false;
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}

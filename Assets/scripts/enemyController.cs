using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent agent; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float distX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distZ = Mathf.Abs(transform.position.z - player.transform.position.z);
        agent.SetDestination(player.transform.position);
        /*if (distX+distZ > 3f)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }*/

    }
}

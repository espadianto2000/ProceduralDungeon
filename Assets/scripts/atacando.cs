using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacando : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo") && player.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(1)[0].clip.name == "Clip1")
        {
            if(other.GetComponent<statsEnemigo>().vulnerable == true)
            {
                Debug.Log("Se hace daño al enemigo");
                other.GetComponent<statsEnemigo>().recibirDano(player.GetComponent<statsJugador>().danoMelee);
            }
            else
            {
                Debug.Log("no recibe daño");
            }
        }
    }
}

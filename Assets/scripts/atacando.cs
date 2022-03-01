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
            Debug.Log("recibir daño");
            other.GetComponent<statsEnemigo>().recibirDano(player.GetComponent<statsJugador>().danoMelee);
            if(other.GetComponent<statsEnemigo>().vida < 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}

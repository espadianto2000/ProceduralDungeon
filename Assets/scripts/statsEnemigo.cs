using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsEnemigo : MonoBehaviour
{
    public float vidaMax;
    public float vida;
    public float velocidad;
    public int danoMelee;
    public int danoRango;
    public float rango;
    public bool vulnerable = true;

    public GameObject damageInd;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void recibirDano(float dano, Vector3 player, float knockbackMelee, int tipoAtaque)
    {
        //vulnerable = false;
        Vector3 direccion = transform.position-player;
        direccion.y = 0;
        transform.GetComponent<enemyController>().knocks(direccion, knockbackMelee, tipoAtaque);
        vida = vida - dano;
        GameObject ind = Instantiate(damageInd, transform.position, Quaternion.identity);
        ind.GetComponent<DamagePopup>().setDamageValue(dano);
    }
}

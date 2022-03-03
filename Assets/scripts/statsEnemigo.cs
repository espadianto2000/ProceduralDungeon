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
    public void recibirDano(float dano)
    {
        vulnerable = false;
        vida = vida - dano;
    }
}

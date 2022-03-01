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
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recibirDano(float dano)
    {
        vida = vida - dano;
    }
}

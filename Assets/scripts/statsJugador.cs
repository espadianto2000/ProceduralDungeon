using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class statsJugador : MonoBehaviour
{
    public int vidaMax;
    public int vida;
    public float velocidad;
    public float danoMelee;
    public float danoRango;
    public float velocidadAtaqueMelee;
    public float velocidadAtaqueRango;
    public float cooldownMelee;
    public float rangoMelee;
    public float rangoRango;
    public float knockbackMelee;

    public charController control;
    public Animator animations;
    public GameObject espada;
    public GameObject contenedorBarraVida;
    public GameObject contenedorContenedoresVida;
    public GameObject ContenedorVida;
    public GameObject cuadradoVida;

    private bool pGracia = false;
    // Start is called before the first frame update
    void Start()
    {
        control.speed = velocidad;
        animations.SetFloat("multipleSpeedMelee", velocidadAtaqueMelee);
        espada.transform.localScale = new Vector3(espada.transform.localScale.x, rangoMelee, espada.transform.localScale.z);
        vida = vidaMax;
        animations.SetFloat("multipleSpeedThrow", velocidadAtaqueRango);
        float cont = vidaMax / 2;
        for (int i =0; i < Math.Floor(cont); i++)
        {
            Instantiate(ContenedorVida, contenedorContenedoresVida.transform);
        }
        for(int j = 0; j < vida; j++)
        {
            Instantiate(cuadradoVida, contenedorBarraVida.transform);
        }
    }

// Update is called once per frame
    private void FixedUpdate()
    {
        if (pGracia)
        {
            if (this.GetComponentInChildren<SkinnedMeshRenderer>().enabled)
            {
                this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
            else
            {
                this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            }
        }
    }
    public void CambiarVidaMax(int vidaExtra)
    {
        int cont = contenedorContenedoresVida.transform.childCount;
        vidaMax += vidaExtra;
        int vidaAntes = vida;
        if (vidaExtra > 0)
        {
            vida += vidaExtra;
        }
        float temp = (vidaMax / 2);
        if (cont < Math.Floor(temp))
        {
            for(int i = 0; i < (Math.Floor(temp) - cont); i++)
            {
                Instantiate(ContenedorVida, contenedorContenedoresVida.transform);
                Instantiate(cuadradoVida, contenedorBarraVida.transform);
                Instantiate(cuadradoVida, contenedorBarraVida.transform);
            }
        }
        else
        {
            for (int i = 0; i < cont - (Math.Floor(temp)); i++)
            {
                Destroy(contenedorContenedoresVida.transform.GetChild(0).gameObject);
            }
            if (vidaAntes > vidaMax)
            {
                Debug.Log("vida antes: " + vidaAntes);
                for (int j = 0; j < (vidaAntes - vidaMax); j++)
                {
                    Destroy(contenedorBarraVida.transform.GetChild(j).gameObject);
                }
                vida = vidaMax;
            }
        }
    }
    public void cambiarVida(int punt)
    {
        Debug.Log("se llama al cambiar vida");
        for(int i = 0; i < punt; i++){
            Debug.Log("se entra al bucle 1 vez");
            if (vida < vidaMax)
            {
                Debug.Log("se suma 1 de vida");
                vida++;
                Instantiate(cuadradoVida, contenedorBarraVida.transform);
            }
        }
        
    }
    public void cambiarVelocidad(float velocidadExtra, bool multiplier)
    {
        if (multiplier)
        {
            velocidad = velocidad * velocidadExtra;
        }
        else
        {
            velocidad = velocidad + velocidadExtra;
        }
        control.speed = velocidad;
    }
    public void cambiarDanoMelee(float danoExtra, bool multiplier)
    {
        if (multiplier)
        {
            danoMelee = danoMelee * danoExtra;
        }
        else
        {
            danoMelee = danoMelee + danoExtra;
        }
    }
    public void cambiarDanoRango(float danoExtra, bool multiplier)
    {
        if (multiplier)
        {
            danoRango = danoRango * danoExtra;
        }
        else
        {
            danoRango = danoRango + danoExtra;
        }
    }
    public void cambiarVelocidadAtaqueMelee(float velocidadExtra, bool multiplier)
    {
        if (multiplier)
        {
            velocidadAtaqueMelee = velocidadAtaqueMelee * velocidadExtra;
        }
        else
        {
            velocidadAtaqueMelee = velocidadAtaqueMelee + velocidadExtra;
        }
        animations.SetFloat("multipleSpeedMelee", velocidadAtaqueMelee);
    }
    public void cambiarVelocidadAtaqueRango(float velocidadExtra, bool multiplier)
    {
        if (multiplier)
        {
            velocidadAtaqueRango = velocidadAtaqueRango * velocidadExtra;
        }
        else
        {
            velocidadAtaqueRango = velocidadAtaqueRango + velocidadExtra;
        }
        animations.SetFloat("multipleSpeedThrow", velocidadAtaqueRango);
    }
    public void cambiarCooldownMelee(float cooldownExtra, bool multiplier)
    {
        if (multiplier)
        {
            cooldownMelee = cooldownMelee * cooldownExtra;
        }
        else
        {
            cooldownMelee = cooldownMelee + cooldownExtra;
        }
    }
    public void cambiarTamañoEspada(float rangoExtra, bool multiplier)
    {
        if (multiplier)
        {
            rangoMelee = rangoMelee * rangoExtra;
        }
        else
        {
            rangoMelee = rangoMelee + rangoExtra;
        }
        espada.transform.localScale = new Vector3(espada.transform.localScale.x,rangoMelee, espada.transform.localScale.z);
    }
    public void cambiarRangoDistancia(float rangoExtra, bool multiplier)
    {
        if (multiplier)
        {
            rangoRango = rangoRango * rangoExtra;
        }
        else
        {
            rangoRango = rangoRango + rangoExtra;
        }
        // TODO
        // cambiar tiempo de vida de proyectil
    }
    public void cambiarKnockbackMelee(float knockbackExtra, bool multiplier)
    {
        if (multiplier)
        {
            knockbackMelee = knockbackMelee * knockbackExtra;
        }
        else
        {
            knockbackMelee = knockbackMelee + knockbackExtra;
        }
    }
    public void recibirDano(int dano)
    {
        if (!pGracia)
        {
            pGracia = true;
            vida -= dano;
            Invoke("disolverGracia", 1f);
            for(int i = 0; i < dano; i++)
            {
                if (contenedorBarraVida.transform.childCount >= 1)
                {
                    Destroy(contenedorBarraVida.transform.GetChild(0).gameObject);
                }
            }
        }
    }
    private void disolverGracia()
    {
        pGracia = false;
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }
}

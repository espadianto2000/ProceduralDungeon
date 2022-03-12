using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        control.speed = velocidad;
        animations.SetFloat("multipleSpeedMelee", velocidadAtaqueMelee);
        espada.transform.localScale = new Vector3(espada.transform.localScale.x, rangoMelee, espada.transform.localScale.z);
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarVidaMax(int vidaExtra)
    {
        vidaMax += vidaExtra;
        vida += vidaExtra;
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
}

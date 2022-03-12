using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulnerablesEnemigos : MonoBehaviour
{
    public GameObject trail;
    public AudioSource audioEspada;
    public AudioClip swing;
    // Start is called before the first frame update
    public void ActivarVulnerabilidad()
    {
        trail.SetActive(false);
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
        foreach (GameObject en in enemigos)
        {
            en.GetComponent<statsEnemigo>().vulnerable = true;
        }
    }
    public void slash()
    {
        audioEspada.clip = swing;
        audioEspada.Play();
    }
}

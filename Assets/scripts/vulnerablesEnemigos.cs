using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulnerablesEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public void ActivarVulnerabilidad()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
        foreach (GameObject en in enemigos)
        {
            en.GetComponent<statsEnemigo>().vulnerable = true;
        }
    }
}

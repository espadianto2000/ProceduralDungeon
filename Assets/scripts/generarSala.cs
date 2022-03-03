using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarSala : MonoBehaviour
{
    public int Direccion;
    public bool destroyer = false;

    private salas salas;
    private int rand;
    public bool spawned = false;
    public GameObject salaGenerada=null;
    // Start is called before the first frame update
    void Start()
    {
        salas = GameObject.FindGameObjectWithTag("salas").GetComponent<salas>();
        Invoke("Spawn", 0.1F);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (destroyer)
        { 
            other.gameObject.SetActive(false);
            //Debug.Log("desactivando: " + other.name + "; de: " + other.transform.parent.name);
            //Destroy(other.gameObject);
        }
        else
        {
            if (other.CompareTag("SpawnPoint"))
            {
                if (other.GetComponent<generarSala>().spawned == true)
                {
                    //Debug.Log("destruyendo: " + gameObject.name + "; de: " + gameObject.transform.parent.name);
                    Destroy(gameObject);
                }
                if (spawned == false && other.GetComponent<generarSala>().spawned == false)
                {
                    Invoke("SpawnMuro",0.1F);
                }
                spawned = true;
            }
        }
        
    }
    void Spawn()
    {
        if (spawned == false)
        {
            spawned = true;
            GameObject inst = null;
            switch (Direccion)
            {
                case 1:
                    rand = Random.Range(0, salas.salasDer.Count);
                    inst = Instantiate(salas.salasDer[rand], transform.position, new Quaternion(0, 0, 0, 0));
                    salas.salasInstanciadas.Add(inst);
                    salaGenerada = inst.gameObject;
                    //Debug.Log("Instanciado: " + inst.name + "; desde: " + transform.parent.name);
                    break;
                case 2:
                    rand = Random.Range(0, salas.salasAba.Count);
                    inst = Instantiate(salas.salasAba[rand], transform.position, new Quaternion(0, 0, 0, 0));
                    salas.salasInstanciadas.Add(inst);
                    salaGenerada = inst.gameObject;
                    //Debug.Log("Instanciado: " + inst.name + "; desde: " + transform.parent.name);
                    break;
                case 3:
                    rand = Random.Range(0, salas.salasIzq.Count);
                    inst = Instantiate(salas.salasIzq[rand], transform.position, new Quaternion(0, 0, 0, 0));
                    salas.salasInstanciadas.Add(inst);
                    salaGenerada = inst.gameObject;
                    //Debug.Log("Instanciado: " + inst.name + "; desde: " + transform.parent.name);
                    break;
                case 4:
                    rand = Random.Range(0, salas.salasArr.Count);
                    inst = Instantiate(salas.salasArr[rand], transform.position, new Quaternion(0, 0, 0, 0));
                    salas.salasInstanciadas.Add(inst);
                    salaGenerada = inst.gameObject;
                    //Debug.Log("Instanciado: " + inst.name + "; desde: " + transform.parent.name);
                    break;
            }
            destroyer = true;
            salas.contadorSalas++;
            salas.timer = 0.75f;
        }
    }
    void SpawnMuro()
    {
        Instantiate(salas.SpawnMuros, transform.position, Quaternion.identity);
    }
    
}

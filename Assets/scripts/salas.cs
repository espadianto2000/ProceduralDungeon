using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salas : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> salasIzq;
    public List<GameObject> salasArr;
    public List<GameObject> salasDer;
    public List<GameObject> salasAba;
    public int contadorSalas;
    public int Limite1; 
    public int Limite2;
    public bool lim1=false;
    public bool lim2=false;
    public float timer = 3;
    public bool spawnedBoss = false;

    public List<GameObject> salasInstanciadas;
    public GameObject boss;
    public GameObject SpawnMuros;
    public GameObject muros;
    public bool juegoListo = false;
    public GameObject player;
    public GameObject SalaLimite;
    public UnityEngine.AI.NavMeshSurface surface;

    private void Update()
    {
        if (!spawnedBoss)
        {
            if (contadorSalas >= Limite1 && lim1 == false)
            {
                salasIzq.RemoveRange(salasIzq.Count - 5, 5);
                salasDer.RemoveRange(salasDer.Count - 5, 5);
                salasArr.RemoveRange(salasArr.Count - 5, 5);
                salasAba.RemoveRange(salasAba.Count - 5, 5);
                for (int i = 0; i < 4; i++)
                {
                    salasIzq.Add(salasIzq[0]);
                    salasDer.Add(salasDer[0]);
                    salasArr.Add(salasArr[0]);
                    salasAba.Add(salasAba[0]);
                }
                lim1 = true;
            }
            if (contadorSalas >= Limite2 && lim2 == false)
            {
                salasIzq.RemoveRange(1, 8);
                salasDer.RemoveRange(1, 8);
                salasArr.RemoveRange(1, 8);
                salasAba.RemoveRange(1, 8);
                lim2 = true;
            }
            if (timer <= 0 && spawnedBoss == false)
            {
                var jefe = Instantiate(boss, salasInstanciadas[salasInstanciadas.Count - 1].transform.position, Quaternion.identity);
                jefe.transform.parent = salasInstanciadas[salasInstanciadas.Count - 1].transform;
                spawnedBoss = true;
                
            }
            else
            {
                timer = timer - Time.deltaTime;
            }
        }else if (!juegoListo)
        {
            borrarSpawners();
            juegoListo = true;
            Invoke("refrescarNavMesh", 0.5f);
        }
        
    }
    void borrarSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach(GameObject sp in spawners)
        {
            Vector3 temp = sp.transform.position;
            GameObject padre = sp.GetComponent<generarSala>().salaGenerada;
            Destroy(sp.gameObject);
            if (padre != null)
            {
                var lim = Instantiate(SalaLimite, temp, Quaternion.identity);
                lim.transform.SetParent(padre.transform);
            }
        }
        GameObject[] spawnmuros = GameObject.FindGameObjectsWithTag("spawnMuro");
        foreach (GameObject sp in spawnmuros)
        {
            Destroy(sp.gameObject);
        }
            player.SetActive(true);
    }
    void refrescarNavMesh()
    {
        surface.BuildNavMesh();
    }

}


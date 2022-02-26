using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateCam : MonoBehaviour
{
    public GameObject cam;
    public salas salas;
    public bool entrada = false;
    public GameObject player;
    public bool moverjugador = false;
    public Vector3 destino;
    public GameObject puertas;
    public List<GameObject> pr;
    public bool finalizado = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camara");
        salas = GameObject.FindGameObjectWithTag("salas").GetComponent<salas>();
        player = GameObject.Find("player");
        //Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(player == null)
        {
            player = GameObject.Find("player");
            Debug.Log(player);
        }*/
        if (entrada)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, transform.position+new Vector3(0,50,0), 10 * Time.deltaTime);
            if(Vector3.Distance(cam.transform.position, transform.position + new Vector3(0, 50, 0))<0.01f)
            {
                player.GetComponent<charController>().enabled = true;
                entrada = false;
            }
        }
        if (moverjugador)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, destino, 10 * Time.deltaTime);
            if(Vector3.Distance(player.transform.position, destino) < 0.01f)
            {
                //Debug.Log("moviendo hacia: " + destino);
                moverjugador = false;
                if (!finalizado)
                {
                    GameObject puerta1 = Instantiate(puertas, transform.position + new Vector3(5.5f, 0.95f, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
                    GameObject puerta3 = Instantiate(puertas, transform.position + new Vector3(-5.5f, 0.95f, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
                    GameObject puerta2 = Instantiate(puertas, transform.position + new Vector3(0, 0.95f, 5.5f), new Quaternion(0, 0, 0, 0));
                    GameObject puerta4 = Instantiate(puertas, transform.position + new Vector3(0, 0.95f, -5.5f), new Quaternion(0, 0, 0, 0));
                    pr.Add(puerta1);
                    pr.Add(puerta2);
                    pr.Add(puerta3);
                    pr.Add(puerta4);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            entrada = true;
            Debug.Log("se ha entrado a la sala en: " + transform.position);
            if(other.transform.position.x ==transform.position.x && other.transform.position.z == transform.position.z)
            {
                Debug.Log("sala Inicial");
            }
            else
            {
                //Debug.Log("se debe mover");
                float posXJ = player.transform.position.x;
                float posZJ = player.transform.position.z;
                float destX = transform.position.x;
                float destZ = transform.position.z;
                if ((posXJ - destX) > 3)
                {
                    destX += 4.25f;
                }
                else if((posXJ - destX) < -3)
                {
                    destX -= 4.25f;
                }
                else { destX = posXJ; }
                if((posZJ - destZ) > 3)
                {
                    destZ += 4.25f;
                }
                else if((posZJ - destZ) < -3)
                {
                    destZ -= 4.25f;
                }
                else { destZ = posZJ; }
                destino = new Vector3(destX, 1.1f, destZ);
                Debug.Log("moviendo hacia: " + destino);
                other.GetComponent<charController>().enabled = false;
                moverjugador = true;
            }
            //cam.transform.position = transform.position + new Vector3(0,50,0);
        }
    }
    public void FinalizarSala()
    {
        finalizado = true;
        foreach (GameObject p in pr)
        {
            Destroy(p);
        }
        
    }
}

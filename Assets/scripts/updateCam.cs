using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Unity.Services.Core;
//using Unity.Services.Analytics;

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
    public float velocidadTemp = -500f;
    public gameManager gm;
    public List<GameObject> enemigosInstanciados;
    public int contadorEnemigos=-1000;
    public bool spawnEnemigos = true;
    public GameObject premio = null;
    public GameObject PanelInfo;
    public GameObject map;
    public GameObject salaIn;
    public GameObject salaOut;
    public GameObject boss;
    public bool contenidoGenerado = false;
    public bool spawnPortal=false;
    public List<GameObject> trampas;
    private dificultadAdaptable dl;
    public int danoRecibidoEnSala = 0;
    public int danoEnem1 = 0;
    public int danoEnem2 = 0;
    public int danoEnem3 = 0;
    public int danoEnem4 = 0;
    public bool[] tipoEnems = new bool[4];
    public float tiempoSala = -1;
    private AudioManager am;
    public string nombreBoss;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < tipoEnems.Length; i++)
        {
            tipoEnems[i] = false;
        }
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        cam = GameObject.Find("Camara");
        salas = GameObject.FindGameObjectWithTag("salas").GetComponent<salas>();
        player = GameObject.Find("player");
        PanelInfo = gm.panelInfo;
        map = GameObject.Find("mapa");
        //Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (entrada)
        {
            gm.InputEnable = false;
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, transform.position+new Vector3(0,50,0), 10 * Time.deltaTime);
            if(Vector3.Distance(cam.transform.position, transform.position + new Vector3(0, 50, 0))<0.01f)
            {
                gm.InputEnable = true;
                if (spawnEnemigos && !finalizado)
                {
                    if (boss != null)
                    {
                        boss.SetActive(true);
                        contadorEnemigos = 1;
                        spawnPortal = true;
                        nombreBoss = boss.name;
                    }
                    else
                    {
                        
                        foreach (GameObject en in enemigosInstanciados)
                        {
                            en.SetActive(true);
                        }
                        contadorEnemigos = enemigosInstanciados.Count;
                        foreach(GameObject tramp in trampas)
                        {
                            tramp.SetActive(true);
                        }
                    }
                }
                entrada = false;
            }
        }
        if (moverjugador)
        {
            //player.GetComponent<charController>().speed = 0f;
            player.transform.position = Vector3.MoveTowards(player.transform.position, destino, 5 * Time.deltaTime);
            if(Vector3.Distance(player.transform.position, destino) < 0.01f)
            {
                //Debug.Log("moviendo hacia: " + destino);
                if (premio != null)
                {
                    PanelInfo.GetComponent<seguirMouse>().actualizar(premio);
                }
                player.GetComponentInChildren<Animator>().SetBool("corriendo", false);
                moverjugador = false;
                //player.GetComponent<charController>().cuerpo.transform.localPosition = new Vector3(-0.08f, -0.5f, -0.15f);
                player.GetComponent<charController>().animador.Play("Idle_Battle");
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
                    tiempoSala = 0;
                }
            }
        }
        if(contadorEnemigos == 0 && !finalizado)
        {
            
            if (gm.identificado)
            {
                //Debug.Log("Analytics : " + gm.identificadorMaq + "--" + "salaFinalizada");
                /*AnalyticsService.Instance.CustomData("salaFinalizada", new Dictionary<string, object>
                {
                    { "UserRun",gm.identificadorMaq},
                    { "nivelActual", dl.nivelDificultad },
                    { "tiempo", tiempoSala },
                    { "danoRecibido", danoRecibidoEnSala },
                    { "salaJefe", spawnPortal }
                });
                try
                {
                    AnalyticsService.Instance.Flush();
                }
                catch
                {

                }*/
                //analytics
                /*Debug.Log("salaFinalizada: " + Analytics.IsCustomEventEnabled("salaFinalizada"));
                AnalyticsResult anRes = Analytics.CustomEvent("salaFinalizada-"+ gm.identificadorMaq +"-"+ dl.nivelDificultad, new Dictionary<string, object>
                {
                    { "tiempo", tiempoSala },
                    { "danoRecibido", danoRecibidoEnSala },
                    { "salaJefe", spawnPortal }
                });
                Debug.Log("analyticsResult salaFinalizada: " + anRes);
                Analytics.FlushEvents();*/
                tiempoSala = -1;
            }
            salas.salasSuperadas++;
            FinalizarSala();
            if (spawnPortal)
            {
                if (premio != null)
                {
                    Destroy(premio.gameObject);
                }
                GetComponent<generarDistribucion>().instanciarPremio();
                PanelInfo.GetComponent<seguirMouse>().actualizar(premio);
                premio.SetActive(true);
                Instantiate(gm.portal, new Vector3(transform.position.x,0.5f,transform.position.z), Quaternion.Euler(new Vector3(-90,0,0)));
                mandarEvaluadorBoss();
            }
            else
            {
                mandarEvaluadorEnemigos();
            }
            Debug.Log("desempeņo enem1: " + dl.GetComponent<evaluadorDeDesempeņo>().valoraciones[0]);
            Debug.Log("desempeņo enem2: " + dl.GetComponent<evaluadorDeDesempeņo>().valoraciones[1]);
            Debug.Log("desempeņo enem3: " + dl.GetComponent<evaluadorDeDesempeņo>().valoraciones[2]);
            Debug.Log("desempeņo enem4: " + dl.GetComponent<evaluadorDeDesempeņo>().valoraciones[3]);
            List<int>[] temp = dl.GetComponent<evaluadorDeDesempeņo>().listaDeArrays[dl.nivel];
            /*for(int i = 0; i < temp.Length; i++)
            {
                foreach(int val in temp[i])
                {
                    Debug.Log("enem " + i + ": " + val);
                }
            }*/
            dl.actualizarModelosEnemigos();
        }
    }
    public void mandarEvaluadorEnemigos()
    {
        if (tipoEnems[0])
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaEnemigo1(dl.nivel, danoEnem1);
        }
        if (tipoEnems[1])
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaEnemigo2(dl.nivel, danoEnem2);
        }
        if (tipoEnems[2])
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaEnemigo3(dl.nivel, danoEnem3);
        }
        if (tipoEnems[3])
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaEnemigo4(dl.nivel, danoEnem4);
        }
    }
    public void mandarEvaluadorBoss()
    {
        if (nombreBoss.Contains("Red"))
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaBoss1(dl.nivel, danoRecibidoEnSala);
        }
        if (nombreBoss.Contains("among us"))
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaBoss2(dl.nivel, danoRecibidoEnSala);
        }
        if (nombreBoss.Contains("GruntPol"))
        {
            dl.GetComponent<evaluadorDeDesempeņo>().ocurrenciaBoss3(dl.nivel, danoRecibidoEnSala);
        }
    }
    private void FixedUpdate()
    {
        tiempoSala += tiempoSala >= 0 ? Time.fixedDeltaTime : 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (!finalizado && boss != null)
            {
                am.activarBoss();
            }else if (spawnPortal)
            {
                if (am.estado != 3)
                {
                    am.activarWin();
                }
            }
            else if(transform.position.x != 0 && transform.position.z != 0)
            {
                if (am.estado != 1)
                {
                    am.activarGameplay();
                }
            }
            other.GetComponent<charController>().salaActual = this;
            if (!contenidoGenerado)
            {
                dl = GameObject.Find("dificultad").GetComponent<dificultadAdaptable>();
                //float t1 = Time.realtimeSinceStartup;
                GetComponent<generarDistribucion>().generarElementos2(dl.numObs,dl.numEnemigos,dl.numTrampas);
                GetComponent<generarDistribucion>().instanciarElementos(dl);
                contenidoGenerado = true;
                //float t2 = Time.realtimeSinceStartup;
                
                //Debug.Log("tiempo de algoritmo inSala: " + (t2 - t1));
            }
            salaOut.SetActive(false);
            salaIn.SetActive(true);
            entrada = true;
            player.GetComponent<charController>().animador.Play("RunForwardBattle");
            //Debug.Log("se ha entrado a la sala en: " + transform.position);
            if(Mathf.Abs(other.transform.position.x - transform.position.x) < 0.1f && Mathf.Abs(other.transform.position.z - transform.position.z) < 0.1f)
            {
                //Debug.Log("sala Inicial");
                spawnEnemigos = false;
                finalizado = true;
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
                    destX += 4.5f;
                }
                else if((posXJ - destX) < -3)
                {
                    destX -= 4.5f;
                }
                else { destX = posXJ; }
                if((posZJ - destZ) > 3)
                {
                    destZ += 4.5f;
                }
                else if((posZJ - destZ) < -3)
                {
                    destZ -= 4.5f;
                }
                else { destZ = posZJ; }
                destino = new Vector3(destX, 0.6f, destZ);
                //Debug.Log("moviendo hacia: " + destino);

                velocidadTemp = other.GetComponent<statsJugador>().velocidad;
                moverjugador = true;
            }
            map.transform.position = transform.position + new Vector3(0, 60, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            salaIn.SetActive(false);
            salaOut.SetActive(true);
        }
    }
    public void FinalizarSala()
    {
        finalizado = true;
        if (premio != null)
        {
            gm.numeroPremiosNivel++;
            premio.SetActive(true);
        }
        foreach (GameObject p in pr)
        {
            Destroy(p);
        }
    }
}

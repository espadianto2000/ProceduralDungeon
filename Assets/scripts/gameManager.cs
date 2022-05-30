using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InputEnable = true;
    public GameObject panelInfo;
    public Vector2 hotspot;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    Ray ray;
    RaycastHit hit;
    public GameObject modeloSalaInicial;
    public GameObject modeloSalas;
    public salas salasActuales;
    public GameObject player;
    public GameObject portal;
    public bool paused = false;
    public GameObject cargaNv;
    public GameObject panelCarga;
    public GameObject menuPausa;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("present"))
            {
                panelInfo.SetActive(true);
                Cursor.visible = false;
            }
            else
            {
                if (panelInfo.active)
                {
                    panelInfo.SetActive(false);
                    Cursor.visible = true;
                    ajustarMouse();
                }
            }
        }
        if (Input.GetKeyDown("p"))
        {
            if (paused)
            {
                reanudar();
            }
            else
            {
                pausar();
            }
        }
    }
    public void ajustarMouse()
    {
        hotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }
    public void reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }
    public void NextLevel()
    {
        InputEnable = false;
        GameObject[] objs = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject obj in objs)
        {
            if(obj.name != "NavMesh" && obj.name != "GameManager" && obj.name != "Directional Light" && obj.name != "EventSystem" && obj.name != "Canvas" && obj.name != "cargaNivel")
            {
                if(obj.name.Contains("salas"))
                {
                    //hacer algo con las salas y luego eliminar
                    Destroy(obj);
                }
                else if(obj.name == "Camara" || obj.name =="mapa")
                {
                    obj.transform.position = new Vector3(0, obj.transform.position.y, 0);
                }
                else if(obj.name == "player")
                {
                    obj.transform.position = new Vector3(0, 0.5f, 0);
                    obj.transform.rotation = Quaternion.Euler(Vector3.zero);
                    obj.SetActive(false);
                }
                else if (obj.name == "dificultad")
                {
                    obj.GetComponent<dificultadLineal>().cambiarNivel(obj.GetComponent<dificultadLineal>().nivelDificultad + 1);
                    cargaNv.GetComponent<Camera>().orthographicSize = 30 + (20 * (obj.GetComponent<dificultadLineal>().nivelDificultad - 1));
                }
                else
                {
                    Destroy(obj);
                }
            }
        }
        GameObject sl = Instantiate(modeloSalas, Vector3.zero, Quaternion.Euler(Vector3.zero));
        salasActuales = sl.GetComponent<salas>();
        panelCarga.GetComponent<panelCarga>().mostrarMapaCarga();
        Instantiate(modeloSalaInicial, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
}

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

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.name);
            
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
    }
    public void ajustarMouse()
    {
        hotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }
    public void NextLevel()
    {
        GameObject[] objs = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject obj in objs)
        {
            if(obj.name != "NavMesh" && obj.name != "GameManager" && obj.name != "Directional Light" && obj.name != "EventSystem" && obj.name != "Canvas")
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
                    obj.transform.position = new Vector3(0, 0.686f, 0);
                    obj.transform.rotation = Quaternion.Euler(Vector3.zero);
                    obj.SetActive(false);
                }
                else
                {
                    Destroy(obj);
                }
            }
        }
        GameObject sl = Instantiate(modeloSalas, Vector3.zero, Quaternion.Euler(Vector3.zero));
        salasActuales = sl.GetComponent<salas>();
        Instantiate(modeloSalaInicial, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
}

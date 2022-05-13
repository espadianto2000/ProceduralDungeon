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
}

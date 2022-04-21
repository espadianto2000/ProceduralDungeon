using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InputEnable = true;
    public GameObject panelInfo;

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
                panelInfo.SetActive(false);
                Cursor.visible = true;
            }
        }
    }
}

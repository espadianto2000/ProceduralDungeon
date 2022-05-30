using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class panelCarga : MonoBehaviour
{
    public GameObject mapa;
    public GameObject carga;
    public GameObject titulo1;
    public GameObject titulo2;
    public GameObject boton;
    private bool desvanecer = false;
    public gameManager gm;
    public Color temp1;
    public Color temp2;
    public Color temp3;

    private void Start()
    {
        temp1 = new Color(255f, 255f, 255f, 255f);
        temp2 = new Color(255f, 255f, 255f, 255f);
        temp3 = new Color(0f, 0f, 0f, 255f);
    }
    // Update is called once per frame
    void Update()
    {
        if (desvanecer)
        {
            temp1.a -= Time.deltaTime / 1.5f;
            temp2.a -= Time.deltaTime / 1.5f;
            temp3.a -= Time.deltaTime / 1.5f;
            mapa.GetComponent<RawImage>().color = temp1;
            carga.GetComponent<TextMeshProUGUI>().color = temp2;
            GetComponent<Image>().color = temp3;
            if(temp1.a <= 0)
            {
                desvanecer = false;
                gm.InputEnable = true;
                gameObject.SetActive(false);
            }
        }
    }
    public void ocultarBotonYTitulo()
    {
        titulo1.SetActive(false);
        titulo2.SetActive(false);
        boton.SetActive(false);
    }
    public void mostrarMapaCarga()
    {
        mapa.SetActive(true);
        carga.SetActive(true);
        gameObject.SetActive(true);
        mapa.GetComponent<RawImage>().color = new Color(255f,255f,255f,255f);
        carga.GetComponent<TextMeshProUGUI>().color = new Color(255f, 255f, 255f, 255f);
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 255f);
        temp1.a = 1;
        temp2.a = 1;
        temp3.a = 1;
    }
    public void desvanecerElementos()
    {
        desvanecer = true;
    }
}

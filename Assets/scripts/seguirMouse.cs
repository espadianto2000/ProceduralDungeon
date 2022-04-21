using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class seguirMouse : MonoBehaviour
{
    public Canvas myCanvas;
    public GameObject TextoStat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);*/
        //transform.position = Input.mousePosition + new Vector3((GetComponent<RectTransform>().sizeDelta.x)/2, (GetComponent<RectTransform>().sizeDelta.y)/2,0);
        transform.position = Input.mousePosition /*+ new Vector3(((GetComponent<RectTransform>().rect.width) / 2)+20, ((GetComponent<RectTransform>().rect.height) / 2)+10, 0)*/;
    }
    public void actualizar(GameObject obj)
    {
        statsRegalo stats = obj.GetComponent<statsRegalo>();
        for(int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        if (stats.cambiarVidaMax != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if(stats.cambiarVidaMax<0)
            texto.GetComponent<TextMeshProUGUI>().text = "Vida max: " + stats.cambiarVidaMax;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Vida max: +" + stats.cambiarVidaMax; }
        }
        if (stats.cambiarVida != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarVida < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Vida: " + stats.cambiarVida;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Vida: +" + stats.cambiarVida; }
        }
        if(stats.cambiarVelocidad != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarVelocidad < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Velocidad: " + stats.cambiarVelocidad;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Velocidad: +" + stats.cambiarVelocidad; }
        }
        if (stats.cambiarDanoMelee != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarDanoMelee < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Daño Melee: " + stats.cambiarDanoMelee;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Daño Melee: +" + stats.cambiarDanoMelee; }
        }
        if (stats.cambiarDanoRango != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarDanoRango < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Daño Rango: " + stats.cambiarDanoRango;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Daño Rango: +" + stats.cambiarDanoRango; }
        }
        if (stats.cambiarVelocidadAtaqueRango != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarVelocidadAtaqueRango < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Vel. Atk Rango: " + stats.cambiarVelocidadAtaqueRango;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Vel. Atk Rango: +" + stats.cambiarVelocidadAtaqueRango; }
        }
        if (stats.cambiarCooldownMelee != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarCooldownMelee < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Cooldown Melee: " + stats.cambiarCooldownMelee;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Cooldown Melee: +" + stats.cambiarCooldownMelee; }
        }
        if (stats.cambiarTamañoEspada != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarVida < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Tamaño Espada: " + stats.cambiarTamañoEspada;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Tamaño Espada: +" + stats.cambiarTamañoEspada; }
        }
        if (stats.cambiarRangoDistancia != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarRangoDistancia < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Rango Dist.: " + stats.cambiarRangoDistancia;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Rango Dist.: +" + stats.cambiarRangoDistancia; }
        }
        if (stats.cambiarKnockbackMelee != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.cambiarKnockbackMelee < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Knock. Melee: " + stats.cambiarKnockbackMelee;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Knock. Melee: +" + stats.cambiarKnockbackMelee; }
        }
        if (stats.recibirDano != 0)
        {
            GameObject texto = Instantiate(TextoStat, transform);
            if (stats.recibirDano < 0)
                texto.GetComponent<TextMeshProUGUI>().text = "Vida: " + stats.recibirDano;
            else { texto.GetComponent<TextMeshProUGUI>().text = "Vida: +" + stats.recibirDano; }
        }
    }
}

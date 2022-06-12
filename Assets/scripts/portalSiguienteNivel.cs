using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Unity.Services.Core;
//using Unity.Services.Analytics;

public class portalSiguienteNivel : MonoBehaviour
{
    public gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            //Debug.Log("Analytics : " + gm.identificadorMaq + "--" + "nivelFinalizado");
            /*AnalyticsService.Instance.CustomData("nivelFinalizado", new Dictionary<string, object>
                {
                    { "UserRun",gm.identificadorMaq},
                    { "nivelActual", GameObject.Find("dificultad").GetComponent<dificultadLineal>().nivelDificultad },
                    { "tiempo", gm.tiempoNivel },
                    { "danoRecibido", other.GetComponent<charController>().danoNivel },
                    { "PremiosNivel", gm.numeroPremiosNivel},
                    { "salasNivel", GameObject.Find("salas(Clone)").GetComponent<salas>().contadorSalas+1},
                    { "salasCompletadas", GameObject.Find("salas(Clone)").GetComponent<salas>().salasSuperadas}
                });
            try
            {
                AnalyticsService.Instance.Flush();
            }catch
            {
            }*/

            //analytics
            Debug.Log("nivelFinalizado: "+Analytics.IsCustomEventEnabled("nivelFinalizado"));
            GameObject dl = GameObject.Find("dificultad");
            dl.GetComponent<evaluadorDeDesempeño>().pasoNivel(dl.GetComponent<dificultadAdaptable>().nivel + 1);
            AnalyticsResult anRes = Analytics.CustomEvent("nivelFinalizado-"+ gm.identificadorMaq+"-"+ dl.GetComponent<dificultadAdaptable>().nivel+"dif: "+dl.GetComponent<dificultadAdaptable>().nivelDificultad, new Dictionary<string, object>
                {
                    { "tiempo", gm.tiempoNivel },
                    { "danoRecibido", other.GetComponent<charController>().danoNivel },
                    { "PremiosNivel", gm.numeroPremiosNivel},
                    { "salasNivel", GameObject.Find("salas(Clone)").GetComponent<salas>().contadorSalas+1},
                    { "salasCompletadas", GameObject.Find("salas(Clone)").GetComponent<salas>().salasSuperadas},
                    {"valoracionesEnemigosSigNivel","("+dl.GetComponent<evaluadorDeDesempeño>().valoraciones[0]+","+dl.GetComponent<evaluadorDeDesempeño>().valoraciones[1]+","+dl.GetComponent<evaluadorDeDesempeño>().valoraciones[2]+","+dl.GetComponent<evaluadorDeDesempeño>().valoraciones[3]+")" },
                    {"factorDeIncremento",dl.GetComponent<evaluadorDeDesempeño>().factorCrecimiento }
                });
            Debug.Log("analyticsResult nivelFinalizado: " + anRes);
            Analytics.FlushEvents();
            other.GetComponent<charController>().danoNivel = 0;
            gm.numeroPremiosNivel = 0;
            //Debug.Log("nivel: " + GameObject.Find("dificultad").GetComponent<dificultadAdaptable>().nivel);
            gm.NextLevel();
        }
    }
}

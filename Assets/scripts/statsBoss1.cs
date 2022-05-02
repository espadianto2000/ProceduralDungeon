using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsBoss1 : MonoBehaviour
{
    public float vidaMax;
    public float vida;
    public float velocidad;
    public int danoMelee;
    public int danoRango;
    public float rango;
    public bool vulnerable = true;
    public bool muerto;

    public GameObject damageInd;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0 && !muerto)
        {
            muerto = true;
            GetComponent<bossController>().timer = 100;
            GetComponent<bossController>().anim.SetTrigger("morir");
            GetComponent<bossController>().desactivarAreaFuego();
            GetComponent<bossController>().desactivarFuego();
            GetComponent<bossController>().enabled = false;

        }
    }
    public void recibirDano(float dano, Vector3 player, int tipoAtaque)
    {
        //vulnerable = false;
        Vector3 direccion = transform.position - player;
        direccion.y = 0;
        vida = vida - dano;
        GameObject ind = Instantiate(damageInd, transform.position, Quaternion.identity);
        ind.GetComponent<DamagePopup>().setDamageValue(dano);
    }
    public void destruir()
    {
        transform.parent.GetComponentInChildren<updateCam>().contadorEnemigos -= 1;
        Invoke("eliminar", 4f);
    }
    private void eliminar()
    {
        Destroy(gameObject);
    }
}

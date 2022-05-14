using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            gm.NextLevel();
        }
    }
}

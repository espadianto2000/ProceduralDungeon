using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarDistribucion : MonoBehaviour
{
    public float[,] matriz = new float[10,10];
    public float[,] acumulado1 = new float[10, 10];
    public float[,] acumulado2 = new float[10, 10];
    public float[,] acumulado3 = new float[10, 10];
    public float[,] acumulado4 = new float[10, 10];
    public float[,] mapeado = new float[10, 10];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            //string cadena = "";
            for(int j = 0; j < 10; j++)
            {
                matriz[i,j] = Random.Range(1, 20);
            }
        }
        //formar caminos en cruz
        /*int centroTempx = Random.Range(4, 5);
        int centroTempy = Random.Range(4, 5);
        findPathGreedy(centroTempx, centroTempy, 0, Random.Range(4, 5));
        findPathGreedy(centroTempx, centroTempy, 9, Random.Range(4, 5));
        findPathGreedy(centroTempx, centroTempy, Random.Range(4, 5),0);
        findPathGreedy(centroTempx, centroTempy, Random.Range(4, 5),9);
        mapeado[4, 0] = true;
        mapeado[5, 0] = true;
        mapeado[4, 9] = true;
        mapeado[5, 9] = true;
        mapeado[0, 4] = true;
        mapeado[0, 5] = true;
        mapeado[9, 4] = true;
        mapeado[9, 5] = true;*/
        //formar caminos entrelazados
        findPathGreedy(4, 0, 0, 5);
        findPathGreedy(4, 0, 5, 9);
        findPathGreedy(4, 0, 9, 5);
        findPathGreedy(5, 9, 0, 4);
        findPathGreedy(5, 9, 9, 4);
        findPathGreedy(0, 4, 9, 5);
        mapeado[4, 0] = 9;
        mapeado[5, 0] = 9;
        mapeado[4, 9] = 9;
        mapeado[5, 9] = 9;
        mapeado[0, 4] = 9;
        mapeado[0, 5] = 9;
        mapeado[9, 4] = 9;
        mapeado[9, 5] = 9;

        generarElementos(40, 5, 5);

        for (int i=0; i < 10; i++)
        {
            string fila = "";
            for(int j = 0; j < 10; j++)
            {
                if (mapeado[i, j] == 9)
                {
                    fila += "," + 1;
                }else fila += "," + mapeado[i, j];

            }
            Debug.Log(fila);
            fila = "";
        }
        Debug.Log("----------");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void findPathSum(int xIni,int yIni,int xFin, int yFin)
    {
        //intento minimun path sum de 2 direcciones
        if(xIni > xFin)
        {
            acumulado1[xIni,yIni] = matriz[xIni,yIni];
            for(int x = xIni-1;x>xFin-1; x--)
            {
                acumulado1[x, yIni] = matriz[x + 1, yIni] + matriz[x,yIni];
            }
            for(int y = yIni+1; y < yFin + 1; y++)
            {
                acumulado1[xIni, y] = matriz[xIni, y-1] + matriz[xIni, y];
            }
        }
        else if(xIni < xFin)
        {
            acumulado1[xIni, yIni] = matriz[xIni, yIni];
            for (int x = xIni+1; x < xFin+1 ; x++)
            {
                if (acumulado1[x, yIni] != 0)
                {
                    acumulado1[x, yIni] = matriz[x - 1, yIni] + matriz[x, yIni];
                }
                
            }
            for (int y = yIni + 1; y < yFin + 1; y++)
            {
                acumulado1[xIni, y] = matriz[xIni, y + 1] + matriz[xIni, y];
            }
        }
        else if(xIni == xFin)
        {

        }
    }
    void findPathGreedy(int xIni, int yIni, int xFin, int yFin)
    {
        int direccionX = 0;
        int direccionY = 0;
        int x = xIni;
        int y = yIni;
        if (xIni < xFin) { direccionX = 1; } else direccionX = -1;
        if (yIni < yFin) { direccionY = 1; } else direccionY = -1;
        while (x != xFin && y != yFin)
        {
            if (matriz[x + direccionX, y] < matriz[x, y + direccionY]) { x = x + direccionX; mapeado[x, y] = 1; } else { y = y + direccionY; mapeado[x, y] = 1; }
        }
        while(x != xFin)
        {
            x = x + direccionX; mapeado[x, y] = 1;
        }
        while (y != yFin)
        {
            y = y + direccionY; mapeado[x, y] = 1;
        }
    }
    void generarElementos(int mxObs, int mxEnem, int mxTramp)
    {
        List<int> opciones = new List<int> { 2, 2, 3, 3, 4, 4, 5, 5};
        //obstaculo = 3;
        //enemigo = 4;
        //trampa = 5;
        //premio = 6;
        //espacioVacio = 2
        int contObs = 0;
        int contEnem = 0;
        int contTramp = 0;
        bool premio = false;
        for(int x = 0; x <5; x++)
        {
            for(int y = 0; y < 10; y++)
            {
                if (mapeado[x, y] == 0)
                {
                    mapeado[x, y] = opciones[Random.Range(0, opciones.Count)];
                    if(mapeado[x,y] == 5){contTramp += 1;}
                    else if (mapeado[x, y] == 4) { contEnem += 1; }
                    else if (mapeado[x, y] == 3) { contObs += 1; }
                }
                if (contObs >= mxObs) { opciones.RemoveAll(item => item == 3); }
                if (contEnem >= mxEnem) { opciones.RemoveAll(item => item == 4); }
                if (contTramp >= mxTramp) { opciones.RemoveAll(item => item == 5); }

                if (mapeado[9 - x, 9 - y] == 0)
                {
                    mapeado[9-x, 9-y] = opciones[Random.Range(0, opciones.Count)];
                    if (mapeado[9 - x, 9 - y] == 5) { contTramp += 1; }
                    else if (mapeado[9 - x, 9 - y] == 4) { contEnem += 1; }
                    else if (mapeado[9 - x, 9 - y] == 3) { contObs += 1; }
                }
                if (contObs >= mxObs) { opciones.RemoveAll(item => item == 3); }
                if (contEnem >= mxEnem) { opciones.RemoveAll(item => item == 4); }
                if (contTramp >= mxTramp) { opciones.RemoveAll(item => item == 5); }
            }
        }
        while (!premio)
        {
            int randomX = Random.Range(0, 9);
            int randomY = Random.Range(0, 9);
            if (mapeado[randomX, randomY]==1){
                mapeado[randomX, randomY] = 6;
                premio = true;
            }
        }
    }

    void generarElementos2(int mxObs, int mxEnem, int mxTramp)
    {
        //ruta a puertas = 1
        //ruta nueva = 2
        //obstaculos = 3
        //enemigos = 4
        //trampa = 5
        //premio = 6
    }
}

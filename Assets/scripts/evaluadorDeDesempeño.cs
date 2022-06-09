using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class evaluadorDeDesempeño : MonoBehaviour
{
    
    public List<int>[] desempenoNiv1 = new List<int>[4];
    public List<int>[] desempenoNiv2 = new List<int>[4];
    public List<int>[] desempenoNiv3 = new List<int>[4];
    public List<int>[] desempenoNiv4 = new List<int>[4];
    public List<int>[] desempenoNiv5 = new List<int>[4];
    public List<int>[] desempenoNiv6 = new List<int>[4];
    public List<int>[] desempenoNiv7 = new List<int>[4];
    public List<int>[] desempenoNiv8 = new List<int>[4];
    public List<int>[] desempenoNiv9 = new List<int>[4];
    public List<int>[] desempenoNiv10 = new List<int>[4];
    public List<int>[] desempenoNiv11 = new List<int>[4];
    public List<int>[] desempenoNiv12 = new List<int>[4];
    public List<int>[] desempenoNiv13 = new List<int>[4];
    public List<int>[] desempenoNiv14 = new List<int>[4];
    public List<int>[] desempenoNiv15 = new List<int>[4];
    public List<int>[] desempenoNiv16 = new List<int>[4];
    public List<int>[] desempenoNiv17 = new List<int>[4];
    public List<int>[] desempenoNiv18 = new List<int>[4];
    public List<int>[] desempenoNiv19 = new List<int>[4];
    public List<int>[] desempenoNiv20 = new List<int>[4];
    public List<int> desempenoBoss1 = new List<int>();
    public List<int> desempenoBoss2 = new List<int>();
    public List<int> desempenoBoss3 = new List<int>();
    public List<List<int>[]> listaDeArrays = new List<List<int>[]>();
    public float[] valoraciones = new float[4];
    // Start is called before the first frame update
    void Start()
    {
        listaDeArrays.Add(desempenoNiv1);
        listaDeArrays.Add(desempenoNiv2);
        listaDeArrays.Add(desempenoNiv3);
        listaDeArrays.Add(desempenoNiv4);
        listaDeArrays.Add(desempenoNiv5);
        listaDeArrays.Add(desempenoNiv6);
        listaDeArrays.Add(desempenoNiv7);
        listaDeArrays.Add(desempenoNiv8);
        listaDeArrays.Add(desempenoNiv9);
        listaDeArrays.Add(desempenoNiv10);
        listaDeArrays.Add(desempenoNiv11);
        listaDeArrays.Add(desempenoNiv12);
        listaDeArrays.Add(desempenoNiv13);
        listaDeArrays.Add(desempenoNiv14);
        listaDeArrays.Add(desempenoNiv15);
        listaDeArrays.Add(desempenoNiv16);
        listaDeArrays.Add(desempenoNiv17);
        listaDeArrays.Add(desempenoNiv18);
        listaDeArrays.Add(desempenoNiv19);
        listaDeArrays.Add(desempenoNiv20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ocurrenciaEnemigo1(int nivel, int danoRecibido)
    {
        if (listaDeArrays[nivel-1][0].Count >= 20)
        {
            listaDeArrays[nivel - 1][0].RemoveAt(0);
            listaDeArrays[nivel - 1][0].Add(danoRecibido);
        }
        else { listaDeArrays[nivel - 1][0].Add(danoRecibido); }
        /*switch (nivel)
        {
            case 1:
                if (desempenoNiv1[0].Count >= 20)
                {
                    desempenoNiv1[0].RemoveAt(0);
                    desempenoNiv1[0].Add(danoRecibido);
                }
                else{ desempenoNiv1[0].Add(danoRecibido); }
                break;
            case 2:
                if (desempenoNiv2[0].Count >= 20)
                {
                    desempenoNiv2[0].RemoveAt(0);
                    desempenoNiv2[0].Add(danoRecibido);
                }
                else { desempenoNiv2[0].Add(danoRecibido); }
                break;
            case 3:
                if (desempenoNiv3[0].Count >= 20)
                {
                    desempenoNiv3[0].RemoveAt(0);
                    desempenoNiv3[0].Add(danoRecibido);
                }
                else { desempenoNiv3[0].Add(danoRecibido); }
                break;
            case 4:
                if (desempenoNiv4[0].Count >= 20)
                {
                    desempenoNiv4[0].RemoveAt(0);
                    desempenoNiv4[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv4[0].Add(danoRecibido);
                }
                break;
            case 5:
                if (desempenoNiv5[0].Count >= 20)
                {
                    desempenoNiv5[0].RemoveAt(0);
                    desempenoNiv5[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv5[0].Add(danoRecibido);
                }
                break;
            case 6:
                if (desempenoNiv6[0].Count >= 20)
                {
                    desempenoNiv6[0].RemoveAt(0);
                    desempenoNiv6[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv6[0].Add(danoRecibido);
                }
                break;
            case 7:
                if (desempenoNiv7[0].Count >= 20)
                {
                    desempenoNiv7[0].RemoveAt(0);
                    desempenoNiv7[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv7[0].Add(danoRecibido);
                }
                break;
            case 8:
                if (desempenoNiv8[0].Count >= 20)
                {
                    desempenoNiv8[0].RemoveAt(0);
                    desempenoNiv8[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv8[0].Add(danoRecibido);
                }
                break;
            case 9:
                if (desempenoNiv9[0].Count >= 20)
                {
                    desempenoNiv9[0].RemoveAt(0);
                    desempenoNiv9[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv9[0].Add(danoRecibido);
                }
                break;
            case 10:
                if (desempenoNiv10[0].Count >= 20)
                {
                    desempenoNiv10[0].RemoveAt(0);
                    desempenoNiv10[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv10[0].Add(danoRecibido);
                }
                break;
            case 11:
                if (desempenoNiv11[0].Count >= 20)
                {
                    desempenoNiv11[0].RemoveAt(0);
                    desempenoNiv11[0].Add(danoRecibido);
                }
                else { desempenoNiv11[0].Add(danoRecibido); }
                break;
            case 12:
                if (desempenoNiv12[0].Count >= 20)
                {
                    desempenoNiv12[0].RemoveAt(0);
                    desempenoNiv12[0].Add(danoRecibido);
                }
                else { desempenoNiv12[0].Add(danoRecibido); }
                break;
            case 13:
                if (desempenoNiv13[0].Count >= 20)
                {
                    desempenoNiv13[0].RemoveAt(0);
                    desempenoNiv13[0].Add(danoRecibido);
                }
                else { desempenoNiv13[0].Add(danoRecibido); }
                break;
            case 14:
                if (desempenoNiv14[0].Count >= 20)
                {
                    desempenoNiv14[0].RemoveAt(0);
                    desempenoNiv14[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv14[0].Add(danoRecibido);
                }
                break;
            case 15:
                if (desempenoNiv15[0].Count >= 20)
                {
                    desempenoNiv15[0].RemoveAt(0);
                    desempenoNiv15[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv15[0].Add(danoRecibido);
                }
                break;
            case 16:
                if (desempenoNiv16[0].Count >= 20)
                {
                    desempenoNiv16[0].RemoveAt(0);
                    desempenoNiv16[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv16[0].Add(danoRecibido);
                }
                break;
            case 17:
                if (desempenoNiv17[0].Count >= 20)
                {
                    desempenoNiv17[0].RemoveAt(0);
                    desempenoNiv17[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv17[0].Add(danoRecibido);
                }
                break;
            case 18:
                if (desempenoNiv18[0].Count >= 20)
                {
                    desempenoNiv18[0].RemoveAt(0);
                    desempenoNiv18[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv18[0].Add(danoRecibido);
                }
                break;
            case 19:
                if (desempenoNiv19[0].Count >= 20)
                {
                    desempenoNiv19[0].RemoveAt(0);
                    desempenoNiv19[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv19[0].Add(danoRecibido);
                }
                break;
            case 20:
                if (desempenoNiv20[0].Count >= 20)
                {
                    desempenoNiv20[0].RemoveAt(0);
                    desempenoNiv20[0].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv20[0].Add(danoRecibido);
                }
                break;
        }*/
    }
    public void ocurrenciaEnemigo2(int nivel, int danoRecibido)
    {
        if (listaDeArrays[nivel - 1][1].Count >= 20)
        {
            listaDeArrays[nivel - 1][1].RemoveAt(0);
            listaDeArrays[nivel - 1][1].Add(danoRecibido);
        }
        else { listaDeArrays[nivel - 1][1].Add(danoRecibido); }
        /*switch (nivel)
        {
            case 1:
                if (desempenoNiv1[1].Count >= 20)
                {
                    desempenoNiv1[1].RemoveAt(0);
                    desempenoNiv1[1].Add(danoRecibido);
                }
                else { desempenoNiv1[1].Add(danoRecibido); }
                break;
            case 2:
                if (desempenoNiv2[1].Count >= 20)
                {
                    desempenoNiv2[1].RemoveAt(0);
                    desempenoNiv2[1].Add(danoRecibido);
                }
                else { desempenoNiv2[1].Add(danoRecibido); }
                break;
            case 3:
                if (desempenoNiv3[1].Count >= 20)
                {
                    desempenoNiv3[1].RemoveAt(0);
                    desempenoNiv3[1].Add(danoRecibido);
                }
                else { desempenoNiv3[1].Add(danoRecibido); }
                break;
            case 4:
                if (desempenoNiv4[1].Count >= 20)
                {
                    desempenoNiv4[1].RemoveAt(0);
                    desempenoNiv4[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv4[1].Add(danoRecibido);
                }
                break;
            case 5:
                if (desempenoNiv5[1].Count >= 20)
                {
                    desempenoNiv5[1].RemoveAt(0);
                    desempenoNiv5[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv5[1].Add(danoRecibido);
                }
                break;
            case 6:
                if (desempenoNiv6[1].Count >= 20)
                {
                    desempenoNiv6[1].RemoveAt(0);
                    desempenoNiv6[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv6[1].Add(danoRecibido);
                }
                break;
            case 7:
                if (desempenoNiv7[1].Count >= 20)
                {
                    desempenoNiv7[1].RemoveAt(0);
                    desempenoNiv7[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv7[1].Add(danoRecibido);
                }
                break;
            case 8:
                if (desempenoNiv8[1].Count >= 20)
                {
                    desempenoNiv8[1].RemoveAt(0);
                    desempenoNiv8[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv8[1].Add(danoRecibido);
                }
                break;
            case 9:
                if (desempenoNiv9[1].Count >= 20)
                {
                    desempenoNiv9[1].RemoveAt(0);
                    desempenoNiv9[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv9[1].Add(danoRecibido);
                }
                break;
            case 10:
                if (desempenoNiv10[1].Count >= 20)
                {
                    desempenoNiv10[1].RemoveAt(0);
                    desempenoNiv10[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv10[1].Add(danoRecibido);
                }
                break;
            case 11:
                if (desempenoNiv11[1].Count >= 20)
                {
                    desempenoNiv11[1].RemoveAt(0);
                    desempenoNiv11[1].Add(danoRecibido);
                }
                else { desempenoNiv11[1].Add(danoRecibido); }
                break;
            case 12:
                if (desempenoNiv12[1].Count >= 20)
                {
                    desempenoNiv12[1].RemoveAt(0);
                    desempenoNiv12[1].Add(danoRecibido);
                }
                else { desempenoNiv12[1].Add(danoRecibido); }
                break;
            case 13:
                if (desempenoNiv13[1].Count >= 20)
                {
                    desempenoNiv13[1].RemoveAt(0);
                    desempenoNiv13[1].Add(danoRecibido);
                }
                else { desempenoNiv13[1].Add(danoRecibido); }
                break;
            case 14:
                if (desempenoNiv14[1].Count >= 20)
                {
                    desempenoNiv14[1].RemoveAt(0);
                    desempenoNiv14[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv14[1].Add(danoRecibido);
                }
                break;
            case 15:
                if (desempenoNiv15[1].Count >= 20)
                {
                    desempenoNiv15[1].RemoveAt(0);
                    desempenoNiv15[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv15[1].Add(danoRecibido);
                }
                break;
            case 16:
                if (desempenoNiv16[1].Count >= 20)
                {
                    desempenoNiv16[1].RemoveAt(0);
                    desempenoNiv16[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv16[1].Add(danoRecibido);
                }
                break;
            case 17:
                if (desempenoNiv17[1].Count >= 20)
                {
                    desempenoNiv17[1].RemoveAt(0);
                    desempenoNiv17[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv17[1].Add(danoRecibido);
                }
                break;
            case 18:
                if (desempenoNiv18[1].Count >= 20)
                {
                    desempenoNiv18[1].RemoveAt(0);
                    desempenoNiv18[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv18[1].Add(danoRecibido);
                }
                break;
            case 19:
                if (desempenoNiv19[1].Count >= 20)
                {
                    desempenoNiv19[1].RemoveAt(0);
                    desempenoNiv19[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv19[1].Add(danoRecibido);
                }
                break;
            case 20:
                if (desempenoNiv20[1].Count >= 20)
                {
                    desempenoNiv20[1].RemoveAt(0);
                    desempenoNiv20[1].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv20[1].Add(danoRecibido);
                }
                break;
        }*/
    }
    public void ocurrenciaEnemigo3(int nivel, int danoRecibido)
    {
        if (listaDeArrays[nivel - 1][2].Count >= 20)
        {
            listaDeArrays[nivel - 1][2].RemoveAt(0);
            listaDeArrays[nivel - 1][2].Add(danoRecibido);
        }
        else { listaDeArrays[nivel - 1][2].Add(danoRecibido); }
        /*switch (nivel)
        {
            case 1:
                if (desempenoNiv1[2].Count >= 20)
                {
                    desempenoNiv1[2].RemoveAt(0);
                    desempenoNiv1[2].Add(danoRecibido);
                }
                else { desempenoNiv1[2].Add(danoRecibido); }
                break;
            case 2:
                if (desempenoNiv2[2].Count >= 20)
                {
                    desempenoNiv2[2].RemoveAt(0);
                    desempenoNiv2[2].Add(danoRecibido);
                }
                else { desempenoNiv2[2].Add(danoRecibido); }
                break;
            case 3:
                if (desempenoNiv3[2].Count >= 20)
                {
                    desempenoNiv3[2].RemoveAt(0);
                    desempenoNiv3[2].Add(danoRecibido);
                }
                else { desempenoNiv3[2].Add(danoRecibido); }
                break;
            case 4:
                if (desempenoNiv4[2].Count >= 20)
                {
                    desempenoNiv4[2].RemoveAt(0);
                    desempenoNiv4[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv4[2].Add(danoRecibido);
                }
                break;
            case 5:
                if (desempenoNiv5[2].Count >= 20)
                {
                    desempenoNiv5[2].RemoveAt(0);
                    desempenoNiv5[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv5[2].Add(danoRecibido);
                }
                break;
            case 6:
                if (desempenoNiv6[2].Count >= 20)
                {
                    desempenoNiv6[2].RemoveAt(0);
                    desempenoNiv6[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv6[2].Add(danoRecibido);
                }
                break;
            case 7:
                if (desempenoNiv7[2].Count >= 20)
                {
                    desempenoNiv7[2].RemoveAt(0);
                    desempenoNiv7[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv7[2].Add(danoRecibido);
                }
                break;
            case 8:
                if (desempenoNiv8[2].Count >= 20)
                {
                    desempenoNiv8[2].RemoveAt(0);
                    desempenoNiv8[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv8[2].Add(danoRecibido);
                }
                break;
            case 9:
                if (desempenoNiv9[2].Count >= 20)
                {
                    desempenoNiv9[2].RemoveAt(0);
                    desempenoNiv9[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv9[2].Add(danoRecibido);
                }
                break;
            case 10:
                if (desempenoNiv10[2].Count >= 20)
                {
                    desempenoNiv10[2].RemoveAt(0);
                    desempenoNiv10[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv10[2].Add(danoRecibido);
                }
                break;
            case 11:
                if (desempenoNiv11[2].Count >= 20)
                {
                    desempenoNiv11[2].RemoveAt(0);
                    desempenoNiv11[2].Add(danoRecibido);
                }
                else { desempenoNiv11[2].Add(danoRecibido); }
                break;
            case 12:
                if (desempenoNiv12[2].Count >= 20)
                {
                    desempenoNiv12[2].RemoveAt(0);
                    desempenoNiv12[2].Add(danoRecibido);
                }
                else { desempenoNiv12[2].Add(danoRecibido); }
                break;
            case 13:
                if (desempenoNiv13[2].Count >= 20)
                {
                    desempenoNiv13[2].RemoveAt(0);
                    desempenoNiv13[2].Add(danoRecibido);
                }
                else { desempenoNiv13[2].Add(danoRecibido); }
                break;
            case 14:
                if (desempenoNiv14[2].Count >= 20)
                {
                    desempenoNiv14[2].RemoveAt(0);
                    desempenoNiv14[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv14[2].Add(danoRecibido);
                }
                break;
            case 15:
                if (desempenoNiv15[2].Count >= 20)
                {
                    desempenoNiv15[2].RemoveAt(0);
                    desempenoNiv15[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv15[2].Add(danoRecibido);
                }
                break;
            case 16:
                if (desempenoNiv16[2].Count >= 20)
                {
                    desempenoNiv16[2].RemoveAt(0);
                    desempenoNiv16[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv16[2].Add(danoRecibido);
                }
                break;
            case 17:
                if (desempenoNiv17[2].Count >= 20)
                {
                    desempenoNiv17[2].RemoveAt(0);
                    desempenoNiv17[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv17[2].Add(danoRecibido);
                }
                break;
            case 18:
                if (desempenoNiv18[2].Count >= 20)
                {
                    desempenoNiv18[2].RemoveAt(0);
                    desempenoNiv18[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv18[2].Add(danoRecibido);
                }
                break;
            case 19:
                if (desempenoNiv19[2].Count >= 20)
                {
                    desempenoNiv19[2].RemoveAt(0);
                    desempenoNiv19[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv19[2].Add(danoRecibido);
                }
                break;
            case 20:
                if (desempenoNiv20[2].Count >= 20)
                {
                    desempenoNiv20[2].RemoveAt(0);
                    desempenoNiv20[2].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv20[2].Add(danoRecibido);
                }
                break;
        }*/
    }
    public void ocurrenciaEnemigo4(int nivel, int danoRecibido)
    {
        if (listaDeArrays[nivel - 1][3].Count >= 20)
        {
            listaDeArrays[nivel - 1][3].RemoveAt(0);
            listaDeArrays[nivel - 1][3].Add(danoRecibido);
        }
        else { listaDeArrays[nivel - 1][3].Add(danoRecibido); }
        /*switch (nivel)
        {
            case 1:
                if (desempenoNiv1[3].Count >= 20)
                {
                    desempenoNiv1[3].RemoveAt(0);
                    desempenoNiv1[3].Add(danoRecibido);
                }
                else { 
                    desempenoNiv1[3].Add(danoRecibido); }
                break;
            case 2:
                if (desempenoNiv2[3].Count >= 20)
                {
                    desempenoNiv2[3].RemoveAt(0);
                    desempenoNiv2[3].Add(danoRecibido);
                }else { 
                    desempenoNiv2[3].Add(danoRecibido); }
                break;
            case 3:
                if (desempenoNiv3[3].Count >= 20)
                {
                    desempenoNiv3[3].RemoveAt(0);
                    desempenoNiv3[3].Add(danoRecibido);
                }else { 
                    desempenoNiv3[3].Add(danoRecibido); }
                break;
            case 4:
                if (desempenoNiv4[3].Count >= 20)
                {
                    desempenoNiv4[3].RemoveAt(0);
                    desempenoNiv4[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv4[3].Add(danoRecibido);
                }
                break;
            case 5:
                if (desempenoNiv5[3].Count >= 20)
                {
                    desempenoNiv5[3].RemoveAt(0);
                    desempenoNiv5[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv5[3].Add(danoRecibido);
                }
                break;
            case 6:
                if (desempenoNiv6[3].Count >= 20)
                {
                    desempenoNiv6[3].RemoveAt(0);
                    desempenoNiv6[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv6[3].Add(danoRecibido);
                }
                break;
            case 7:
                if (desempenoNiv7[3].Count >= 20)
                {
                    desempenoNiv7[3].RemoveAt(0);
                    desempenoNiv7[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv7[3].Add(danoRecibido);
                }
                break;
            case 8:
                if (desempenoNiv8[3].Count >= 20)
                {
                    desempenoNiv8[3].RemoveAt(0);
                    desempenoNiv8[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv8[3].Add(danoRecibido);
                }
                break;
            case 9:
                if (desempenoNiv9[3].Count >= 20)
                {
                    desempenoNiv9[3].RemoveAt(0);
                    desempenoNiv9[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv9[3].Add(danoRecibido);
                }
                break;
            case 10:
                if (desempenoNiv10[3].Count >= 20)
                {
                    desempenoNiv10[3].RemoveAt(0);
                    desempenoNiv10[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv10[3].Add(danoRecibido);
                }
                break;
            case 11:
                if (desempenoNiv11[3].Count >= 20)
                {
                    desempenoNiv11[3].RemoveAt(0);
                    desempenoNiv11[3].Add(danoRecibido);
                }
                else { desempenoNiv11[3].Add(danoRecibido); }
                break;
            case 12:
                if (desempenoNiv12[3].Count >= 20)
                {
                    desempenoNiv12[3].RemoveAt(0);
                    desempenoNiv12[3].Add(danoRecibido);
                }
                else { desempenoNiv12[3].Add(danoRecibido); }
                break;
            case 13:
                if (desempenoNiv13[3].Count >= 20)
                {
                    desempenoNiv13[3].RemoveAt(0);
                    desempenoNiv13[3].Add(danoRecibido);
                }
                else { desempenoNiv13[3].Add(danoRecibido); }
                break;
            case 14:
                if (desempenoNiv14[3].Count >= 20)
                {
                    desempenoNiv14[3].RemoveAt(0);
                    desempenoNiv14[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv14[3].Add(danoRecibido);
                }
                break;
            case 15:
                if (desempenoNiv15[3].Count >= 20)
                {
                    desempenoNiv15[3].RemoveAt(0);
                    desempenoNiv15[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv15[3].Add(danoRecibido);
                }
                break;
            case 16:
                if (desempenoNiv16[3].Count >= 20)
                {
                    desempenoNiv16[3].RemoveAt(0);
                    desempenoNiv16[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv16[3].Add(danoRecibido);
                }
                break;
            case 17:
                if (desempenoNiv17[3].Count >= 20)
                {
                    desempenoNiv17[3].RemoveAt(0);
                    desempenoNiv17[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv17[3].Add(danoRecibido);
                }
                break;
            case 18:
                if (desempenoNiv18[3].Count >= 20)
                {
                    desempenoNiv18[3].RemoveAt(0);
                    desempenoNiv18[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv18[3].Add(danoRecibido);
                }
                break;
            case 19:
                if (desempenoNiv19[3].Count >= 20)
                {
                    desempenoNiv19[3].RemoveAt(0);
                    desempenoNiv19[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv19[3].Add(danoRecibido);
                }
                break;
            case 20:
                if (desempenoNiv20[3].Count >= 20)
                {
                    desempenoNiv20[3].RemoveAt(0);
                    desempenoNiv20[3].Add(danoRecibido);
                }
                else
                {
                    desempenoNiv20[3].Add(danoRecibido);
                }
                break;
        }*/
    }
    public void ocurrenciaBoss1(int nivel, int danoRecibido)
    {
        if (desempenoBoss1.Count >= 10)
        {
            desempenoBoss1.RemoveAt(0);
            desempenoBoss1.Add(danoRecibido);
        }
        else { desempenoBoss1.Add(danoRecibido); }
    }
    public void ocurrenciaBoss2(int nivel, int danoRecibido)
    {
        if (desempenoBoss2.Count >= 10)
        {
            desempenoBoss2.RemoveAt(0);
            desempenoBoss2.Add(danoRecibido);
        }
        else { desempenoBoss2.Add(danoRecibido); }
    }
    public void ocurrenciaBoss3(int nivel, int danoRecibido)
    {
        if (desempenoBoss3.Count >= 10)
        {
            desempenoBoss3.RemoveAt(0);
            desempenoBoss3.Add(danoRecibido);
        }
        else { desempenoBoss3.Add(danoRecibido); }
    }
    public void ajustarDesempeno(int nivelDificultad, int tipoEnem)
    {
        int valorInicial = -(int)(Math.Floor(listaDeArrays[nivelDificultad-1][tipoEnem].Count / 5f));
        int cont = 0;
        float peso = 1;
        float valorTotal = 0;
        for(int i = listaDeArrays[nivelDificultad - 1][tipoEnem].Count-1; i >= 0; i--)
        {
            if(cont == 5)
            {
                peso -= 0.25f;
                cont = 0;
            }
            valorTotal += listaDeArrays[nivelDificultad - 1][tipoEnem][i] * peso;
            cont++;
        }
        valoraciones[tipoEnem] = valorTotal;
    }
    public void pasoNivel(int nuevoNivel)
    {
        ajustarDesempeno(nuevoNivel, 0);
        ajustarDesempeno(nuevoNivel, 1);
        ajustarDesempeno(nuevoNivel, 2);
        ajustarDesempeno(nuevoNivel, 3);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaManager : Singleton<MonedaManager>
{
    public int MonedasTotales { get; private set; }
    private string MONEDAS_KEY = "MIS_MONEDAS";

    protected override void Awake()
    {
        base.Awake();
        MonedasTotales = PlayerPrefs.GetInt(MONEDAS_KEY);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AñadirMonedas(1);
        }
    }

    public void AñadirMonedas(int cantidad)
    {
        MonedasTotales += cantidad;
        PlayerPrefs.SetInt(MONEDAS_KEY, MonedasTotales);
        PlayerPrefs.Save();
    }

    public void GastarMonedas(int cantidad)
    {
        if (MonedasTotales >= cantidad)
        {
            MonedasTotales -= cantidad;
            PlayerPrefs.SetInt(MONEDAS_KEY, MonedasTotales);
            PlayerPrefs.Save();
        }
    }
}

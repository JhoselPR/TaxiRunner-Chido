using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    
     [SerializeField] private int valorMoneda = 10;
  
       private void ObtenerMoneda()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.itemClip);
         MonedaManager.Instancia.AñadirMonedas(valorMoneda);
        GameManager.Instancia.MonedasObtenidasEnEsteNivel += valorMoneda;
       
        gameObject.SetActive(false);
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObtenerMoneda();
        }
    }
}

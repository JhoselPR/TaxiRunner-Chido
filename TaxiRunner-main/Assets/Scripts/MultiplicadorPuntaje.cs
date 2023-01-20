using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicadorPuntaje : MonoBehaviour
{
      [SerializeField] private float valor;
    [SerializeField] private float duracion;   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.itemClip);
            GameManager.Instancia.ValorMultiplicador = valor;
            GameManager.Instancia.IniciarConteoMultiplicador(duracion);
            gameObject.SetActive(false);
        }
    }
}

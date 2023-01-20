using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour

{
     [Header("Paneles")] 
    [SerializeField] private GameObject panelMenuInicio;
   [SerializeField] private GameObject panelMenuGameOver;
    [Header("Textos")] 
    [SerializeField] private TextMeshProUGUI diamantesObtenidosTMP;
    [SerializeField] private TextMeshProUGUI puntajeTMP;
    [SerializeField] private TextMeshProUGUI diamantesTotalesTMP;
    [SerializeField] private TextMeshProUGUI mejorPuntajeTMP;
    [SerializeField] private TextMeshProUGUI diamantesGameOverTMP;
     [SerializeField] private TextMeshProUGUI puntajeGameOverTMP;
     private void Start()
    {
        ActualizarMenu();
    }
    
     private void ActualizarMenu()
    {
        diamantesTotalesTMP.text = MonedaManager.Instancia.MonedasTotales.ToString();
         mejorPuntajeTMP.text = GameManager.Instancia.MejorPuntaje.ToString();
        
    }

    private void Update()
    {
        diamantesObtenidosTMP.text = GameManager.Instancia.MonedasObtenidasEnEsteNivel.ToString();
        puntajeTMP.text = GameManager.Instancia.Puntaje.ToString();
        
    }
    public void Jugar()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        panelMenuInicio.SetActive(false);
        GameManager.Instancia.CambiarEstado(EstadosDelJuego.Jugando);
    }

     private void ActualizarGameOver()
    {
        panelMenuGameOver.SetActive(true);
        puntajeGameOverTMP.text = GameManager.Instancia.Puntaje.ToString();
        diamantesGameOverTMP.text = GameManager.Instancia.MonedasObtenidasEnEsteNivel.ToString();
    }
     public void Reintentar()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void TiendaPersonajes()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        SceneManager.LoadScene("Tienda");
    }
     private void RespuestaCambioEstado(EstadosDelJuego nuevoEstado)
    {
        if (nuevoEstado == EstadosDelJuego.GameOver)
        {
            ActualizarGameOver();
        }
    }
       private void OnEnable()
    {
        
        GameManager.EventoCambioDeEstado += RespuestaCambioEstado;
    }

    private void OnDisable()
    {
        GameManager.EventoCambioDeEstado -= RespuestaCambioEstado;
    }
}

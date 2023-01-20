using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUTienda : MonoBehaviour

{
 [SerializeField] private PersonajeCard[] cards;
    [SerializeField] private GameObject buttonComprar;
    [SerializeField] private GameObject buttonSeleccionar;
    [SerializeField] private GameObject textoSeleccionado;
    [SerializeField] private TextMeshProUGUI costoPersonajeTMP;
    
       [SerializeField] private GameObject[] personajes;

    
    [SerializeField] private TextMeshProUGUI textoDiamantesTotales;
    [SerializeField] private RawImage fondoImagen;
    [SerializeField] private float xValor;
    [SerializeField] private float yValor;
    

 private PersonajeCard cardClickeado;
  private PersonajeCard cardCargado;
  private void Start()
    {
        cardCargado = cards[PersonajeManager.Instancia.PersonajeSeleccionadoIndex];
        ActualizarInfo(cardCargado);
    }

    

    // Update is called once per frame
    void Update()
    {
        textoDiamantesTotales.text = MonedaManager.Instancia.MonedasTotales.ToString();
         fondoImagen.uvRect = new Rect(fondoImagen.uvRect.position 
                                      + new Vector2(xValor, yValor) * Time.deltaTime, fondoImagen.uvRect.size);
    }
      public void RegresarAlMenu()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        SceneManager.LoadScene("SampleScene");
    }
 private void MostrarPersonajeSeleccionado(PersonajeCard card)
    {
        for (int i = 0; i < personajes.Length; i++)
        {
            personajes[i].SetActive(false);
        }
        
        personajes[card.Index].SetActive(true);
    }
    private void RespuestaEventoClickCard(PersonajeCard card)
    {
        cardClickeado = card;
        ActualizarInfo(card);
       
    }
     private void ActualizarInfo(PersonajeCard card)
    {
        MostrarUISegunCondicion(card);
        MostrarPersonajeSeleccionado(card);
    }

     public void ComprarPersonaje()
    {
        if (MonedaManager.Instancia.MonedasTotales >= cardClickeado.Costo)
        {
            SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
            cardClickeado.ComprarPersonaje();
            ActualizarInfo(cardClickeado);
            MonedaManager.Instancia.GastarMonedas(cardClickeado.Costo);
        }
    }
      public void SeleccionarPersonaje()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].DeseleccionarPersonaje();
        }
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        
       PersonajeManager.Instancia.SeleccionarPersonaje(cardClickeado);
        cardClickeado.SeleccionarPersonaje();
        ActualizarInfo(cardClickeado);
    }
     private void MostrarUISegunCondicion(PersonajeCard card)
    {
        if (card.Comprado)
        {
             if (card.Seleccionado)
            {
                buttonComprar.SetActive(false);
                buttonSeleccionar.SetActive(false);
                textoSeleccionado.SetActive(true);
            }
            else
            {
                buttonComprar.SetActive(false);
                buttonSeleccionar.SetActive(true);
                textoSeleccionado.SetActive(false);
            }
           
        }
        else
        {
            costoPersonajeTMP.text = card.Costo.ToString();
            buttonComprar.SetActive(true);
            buttonSeleccionar.SetActive(false);
            textoSeleccionado.SetActive(false);
        }
    }
    
      private void OnEnable()
    {
        PersonajeCard.EventoClickCard += RespuestaEventoClickCard;
    }

    private void OnDisable()
    {
        PersonajeCard.EventoClickCard -= RespuestaEventoClickCard;
    }
}

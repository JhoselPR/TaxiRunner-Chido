using System;
using UnityEngine;
public class PersonajeCard: MonoBehaviour
{
    public static event Action<PersonajeCard> EventoClickCard;
    [SerializeField] private bool libre;
     [SerializeField] private int index;
    [SerializeField] private int costo;
     

     public int Costo => costo;

    public int Index => index;
    public bool Comprado => PlayerPrefs.GetInt(CARD_COMPRADO_KEY + index) == 1;
    public bool Seleccionado => PlayerPrefs.GetInt(CARD_SELECCIONADO_KEY + index) == 1;

     private string CARD_COMPRADO_KEY = "COMPRADO";
      private string CARD_SELECCIONADO_KEY = "SELECCIONADO";
       private string CARD_LIBRE_KEY = "LIBRE";

         private void Awake()
    {
        //PlayerPrefs.DeleteKey(CARD_COMPRADO_KEY + index);
         //PlayerPrefs.DeleteKey(CARD_SELECCIONADO_KEY + index);
         //PlayerPrefs.DeleteKey(CARD_LIBRE_KEY + index);
         
        if (libre)
        {
            if (PlayerPrefs.GetInt(CARD_LIBRE_KEY + index) == 0)
            {
                ComprarPersonaje();
                SeleccionarPersonaje();
                PlayerPrefs.SetInt(CARD_LIBRE_KEY + index, 1);
            }
        }
    }
 public void ClickCard()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        EventoClickCard?.Invoke(this);
    }
    public void ComprarPersonaje()
    {
        PlayerPrefs.SetInt(CARD_COMPRADO_KEY + index, 1);
    }
       public void SeleccionarPersonaje()
    {
        PlayerPrefs.SetInt(CARD_SELECCIONADO_KEY + index, 1);
    }
     public void DeseleccionarPersonaje()
    {
        PlayerPrefs.SetInt(CARD_SELECCIONADO_KEY + index, 0);
    }
 
}

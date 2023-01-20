using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeManager : Singleton<PersonajeManager>
{
       public int PersonajeSeleccionadoIndex => PlayerPrefs.GetInt(ULTIMO_SELECCIONADO_KEY, 0);
    private string ULTIMO_SELECCIONADO_KEY = "PERSONAJE_SELECCIONADO";

    public void SeleccionarPersonaje(PersonajeCard card)
    {
        PlayerPrefs.SetInt(ULTIMO_SELECCIONADO_KEY, card.Index);
    }
}

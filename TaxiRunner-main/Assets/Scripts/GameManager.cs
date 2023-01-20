using System;
using System.Collections;
using UnityEngine;

public enum EstadosDelJuego{

    Inicio,
    Jugando,
    GameOver

}

public class GameManager : Singleton<GameManager>
{
    public static event Action<EstadosDelJuego> EventoCambioDeEstado;

      [Header("Personajes")] 
    [SerializeField] private GameObject[] personajes;
    
  [SerializeField] private int velocidadMundo = 1;
  public int MejorPuntaje => PlayerPrefs.GetInt(MEJOR_PUNTAJE_KEY);

public int Puntaje => (int) distanciaRecorrida + MonedasObtenidasEnEsteNivel;
        
        public float ValorMultiplicador { get; set; }
  public EstadosDelJuego EstadoActual {get;set;}
   public int MonedasObtenidasEnEsteNivel { get; set; }
   public Transform PersonajeActivo { get; private set; }

   
    private string MEJOR_PUNTAJE_KEY = "MI_MEJOR_PUNTAJE";
    private int mejorPuntajeCheck;
      private float distanciaRecorrida;
      

  protected override void Awake()
    {
        base.Awake();
        ActivarPersonajeSeleccionado();
    }



  private void Start()
    {
        ValorMultiplicador = 1f;
        mejorPuntajeCheck = MejorPuntaje;
         Debug.Log(MejorPuntaje);
    }

  private void Update() {
   

    if (EstadoActual == EstadosDelJuego.Inicio || EstadoActual == EstadosDelJuego.GameOver)
        {
            return;
        }
        
        distanciaRecorrida += Time.deltaTime * velocidadMundo * ValorMultiplicador;
  }
   private void ActivarPersonajeSeleccionado()
    {
        for (int i = 0; i < personajes.Length; i++)
        {
            personajes[i].SetActive(false);
        }

        PersonajeActivo = personajes[PersonajeManager.Instancia.PersonajeSeleccionadoIndex].transform;
        PersonajeActivo.gameObject.SetActive(true);
    }
      private IEnumerator COMultiplicadorConteo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        ValorMultiplicador = 1;
    }
  public void IniciarConteoMultiplicador(float tiempo)
    {
        StartCoroutine(COMultiplicadorConteo(tiempo));
    }
  public void CambiarEstado(EstadosDelJuego nuevoEstado){

    if(EstadoActual != nuevoEstado){

        EstadoActual = nuevoEstado;
        EventoCambioDeEstado?.Invoke(EstadoActual);
    }

    



  }

   private void ActualizarMejorPuntaje()
    {
        if (Puntaje > mejorPuntajeCheck)
        {
            PlayerPrefs.SetInt(MEJOR_PUNTAJE_KEY, Puntaje);
        }
    }
    

  private void RespuestaEventoCambioEstado(EstadosDelJuego nuevoEstado)
    {
        if (nuevoEstado == EstadosDelJuego.GameOver)
        {
            ActualizarMejorPuntaje();
        }
    }
 private void OnEnable()
    {
      
        EventoCambioDeEstado += RespuestaEventoCambioEstado;
    }

    private void OnDisable()
    {
       
        EventoCambioDeEstado -= RespuestaEventoCambioEstado;
    }

}

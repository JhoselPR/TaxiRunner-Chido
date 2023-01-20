using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipodeBloques{
Normal,Coches
}
public class Bloques : MonoBehaviour
{

      [Header("Potenciadores")] 
    [SerializeField] private float probabilidadMinima;
    [SerializeField] private GameObject[] potenciadores;

  [SerializeField] private float posicionZ;

   
     [SerializeField]private TipodeBloques tipobloque;
      public TipodeBloques TipoDebloque => tipobloque;
      [SerializeField] private Tren[] trenes;
      [SerializeField] private Tren trenSeleccionado1;
      [SerializeField] private Tren trenSeleccionado2;
      [SerializeField] private Tren trenSeleccionado3;
      

        [Header("Diamantes")]
    [SerializeField] private GameObject[] diamantes;
      private List<GameObject> diamantesLista = new List<GameObject>();
    private bool diamantesReferenciados;

      public void InicializarBloque(){
               if(tipobloque ==  TipodeBloques.Coches){
                  SeleccionarTren();
                
                    
      }
      ObtenerDiamantes();
                      ActivarDiamantes();
                      SeleccionarPotenciador();
      }
         private void SeleccionarPotenciador()
    {
        if (potenciadores == null || potenciadores.Length == 0)
        {
            return;
        }

        for (int i = 0; i < potenciadores.Length; i++)
        {
            potenciadores[i].SetActive(false);
        }

        float probabilidadRandom = Random.Range(0f, 100f);
        if (probabilidadRandom <= probabilidadMinima)
        {
            int itemRandomIndex = Random.Range(0, potenciadores.Length);
            potenciadores[itemRandomIndex].SetActive(true);
        }
    }
 private void SeleccionarTren(){

        if (trenes == null || trenes.Length == 0)
    {
        return;
    }
 
    for (int i = 0; i < trenes.Length; i++) // <---------
    {
        trenes[i].gameObject.SetActive(false);
        trenes[i].transform.position = 
            new Vector3(trenes[i].transform.position.x, trenes[i].transform.position.y, posicionZ);
    }
    
    int index1 = Random.Range(0,2);
    trenes[index1].gameObject.SetActive(true);
    trenSeleccionado1 = trenes[index1];

    int index2 = Random.Range(3,6);
    trenes[index2].gameObject.SetActive(true);
    trenSeleccionado2 = trenes[index2];

    int index3 = Random.Range(7,9);
    trenes[index3].gameObject.SetActive(true);
    trenSeleccionado3 = trenes[index3];

  



          
            }

      private void ObtenerDiamantes()
    {
        if (diamantesReferenciados)
        {
            return;
        }

        foreach (GameObject parent in diamantes)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject diamante = parent.transform.GetChild(i).gameObject;
                diamantesLista.Add(diamante);
            }
        }

        diamantesReferenciados = true;
    }
 private void ActivarDiamantes()
    {
        if (diamantesLista.Count == 0 || diamantesLista == null)
        {
            return;
        }

        foreach (GameObject diamante in diamantesLista)
        {
            diamante.SetActive(true);
        }
    }
      private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player")){
                  trenSeleccionado1.PuedeMoverse=true;
                  trenSeleccionado1.Player=other.GetComponent<PlayerController>();
                    trenSeleccionado2.PuedeMoverse=true;
                  trenSeleccionado2.Player=other.GetComponent<PlayerController>();
                    trenSeleccionado3.PuedeMoverse=true;
                  trenSeleccionado3.Player=other.GetComponent<PlayerController>();
                
            }
            
      }
        
   

      }
     
      

      

      
       
      
      



    


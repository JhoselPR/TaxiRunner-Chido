
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private float MovDer;
    [SerializeField]private float MovVer;
    [SerializeField]private float velMov;
    [SerializeField]private float contsX=1000f;
    [SerializeField]private float gravedad=20f;
  
[SerializeField]private float limiteSuperior=25f;
      [SerializeField]private float limiteInferior=-25f;
      private float Rotacional;

     [SerializeField] private float posVertical=0f;
    private CharacterController Jugador;
    private int carrilActual;

  
    private Vector3 Rotacion;
    private Vector3 direccion;
    

  


    private void Start() {
        
    

        
        
        Jugador=GetComponent<CharacterController>();



    } 
    private void Update()
    {

        if(GameManager.Instancia.EstadoActual==EstadosDelJuego.Inicio || GameManager.Instancia.EstadoActual==EstadosDelJuego.GameOver){
            return;
        }


        MovDer=Input.GetAxis("Horizontal");
        MovVer=Input.GetAxis("Vertical");
        direccion=new Vector3(MovDer*contsX,0,velMov);
        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direccion),10*Time.deltaTime);

        
       

        if(Jugador.isGrounded){

            posVertical=-gravedad*Time.deltaTime;
            direccion.y=posVertical;

          


        }else{

            posVertical-=gravedad*Time.deltaTime;
            direccion.y=posVertical;

            
        }

         
        Jugador.Move(direccion*Time.deltaTime);
         
        
       

     
   
        
         if(transform.position.x<=limiteInferior){

            direccion=Vector3.zero;
            transform.position=new Vector3(limiteInferior,transform.position.y,transform.position.z);

        }
           if(transform.position.x>=limiteSuperior){

            direccion=Vector3.zero;
            transform.position=new Vector3(limiteSuperior,transform.position.y,transform.position.z);

        }

        

        
        
    }

     private void OnControllerColliderHit(ControllerColliderHit hit) {

        if(hit.collider.CompareTag("Obstaculo")){


            if(GameManager.Instancia.EstadoActual == EstadosDelJuego.GameOver){

                return;
            }
            SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.colisionClip);
            Debug.Log("Game Over");
           GameManager.Instancia.CambiarEstado(EstadosDelJuego.GameOver);




        }
        
    }


  
   
   
}

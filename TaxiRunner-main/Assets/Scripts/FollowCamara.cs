using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour
{
  
   private Vector3 offset;
    void Start()
    {

        offset=transform.position-GameManager.Instancia.PersonajeActivo.position;


        
    }

    
     void LateUpdate()
    {

        Vector3 newPosition=new Vector3(transform.position.x,transform.position.y,offset.z+GameManager.Instancia.PersonajeActivo.position.z);
        transform.position=newPosition;

       
        
    }
}

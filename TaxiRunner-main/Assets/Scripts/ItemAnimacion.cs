using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimacion : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool activarRotacion;
    [SerializeField] private bool activarScale;

     [Header("Rotacion")] 
    [SerializeField] private Vector3 anguloRotacion;
    [SerializeField] private float velocidadRotacion;


    void Update()
    {
        if (activarRotacion)
        {
            transform.Rotate(anguloRotacion * velocidadRotacion * Time.deltaTime);
        }
         
    }
}

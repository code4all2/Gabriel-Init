using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
   [SerializeField] private float velocidade = 10f; // variavel global 
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidade, ForceMode.Impulse);
    }

    
    void Update()
    {
      
    }
}

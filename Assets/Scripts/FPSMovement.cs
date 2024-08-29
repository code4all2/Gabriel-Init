using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    /**
     tipos de variaveis 
    numerico: int - inteiros; float - frações
    letras: string
    boleano: bool
    Vector3/2
    Transform     
     */
    private float speed = 4f; 
    private Vector2 input;
    private Vector3 direction;
    private Transform cam;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, cam.eulerAngles.y, transform.eulerAngles.z);

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        direction = input.x * Vector3.right + input.y * Vector3.forward;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

    }
}

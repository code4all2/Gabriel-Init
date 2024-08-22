using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform bocaDaArma;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(bala, bocaDaArma.position, bocaDaArma.rotation);
    }
}

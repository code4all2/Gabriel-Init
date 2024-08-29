using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform bocaDaArma;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bala, bocaDaArma.position, bocaDaArma.rotation);
        }
    }
}

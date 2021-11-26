using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.AI;

public class Walk : MonoBehaviour
{
    public int Contador;
    public Text Puntuacion;
    public Text win;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Contador = Contador + 1;
        Puntuacion.text = "Galletas : " + Contador;
        actualizarmarcador();
        if (Contador >= 4)
        {
            win.gameObject.SetActive(true);
        }

    }

    private void actualizarmarcador()
    {
        Puntuacion.text = "Galletas : " + Contador;
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Contador = 0;
        actualizarmarcador();
        win.gameObject.SetActive(false);
    }

}
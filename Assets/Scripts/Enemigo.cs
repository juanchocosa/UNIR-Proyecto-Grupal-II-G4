using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] List<Transform> puntosDeRuta;
    float velocidad = 2f;
    float distanciaCambio = 0.2f;
    byte siguientePunto = 0;
    bool ida = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntosDeRuta[siguientePunto].transform.position, velocidad * Time.deltaTime);

        if(transform.position.x > puntosDeRuta[siguientePunto].transform.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        else if (transform.position.x < puntosDeRuta[siguientePunto].transform.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }

        if (Vector3.Distance(transform.position, puntosDeRuta[siguientePunto].transform.position) < distanciaCambio)
        {
            if (ida)
            {
                siguientePunto++;
            }
            else
            {
                siguientePunto--;
            }

            if (siguientePunto >= puntosDeRuta.Count)
            {
                if (ida)
                {
                    siguientePunto--;
                    ida = false;
                }
                else
                {
                    siguientePunto++;
                    ida = true;
                }
            }
        }
    }
}

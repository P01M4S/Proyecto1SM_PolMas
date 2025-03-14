using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //Variebles de numeros enteros y decimales
public int numeroEntero = 5;
private float numeroDecimal = 7.5f;

bool boleana = true; //Verdadero o Falso

string cadenaTexto = "Yepa, ya estoy por aqui";

    // Start is called before the first frame update
    void Start()
    {
     Calculos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Calculos()
{
            Debug.Log(numeroEntero);
        numeroEntero = 17;
        Debug.Log(numeroEntero);

        numeroEntero = 7 + 5;

        numeroEntero++;

        numeroEntero += 2;
}
}

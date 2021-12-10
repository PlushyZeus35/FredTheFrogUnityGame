using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    //REFERENCIA AL TEXTO DE LA INTERFAZ
    public Text totalFruitsCollected;
    //NUMERO TOTAL DE FRUTAS
    public int totalFruits;
    //NUMERO DE FRUTAS QUE QUEDAN POR COGER
    public int currentFruits;
    //NUMERO DE FRUTAS RECOGIDAS
    public int fruitsCollected;
    void Start()
    {   //INICIAMOS EL NUMERO TOTAL DE FRUTAS CON LAS FRUTAS QUE HAY EN EL FRUITMANAGER
        totalFruits = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        //RECONTAMOS CONTINUAMENTE CUANTAS FRUTAS HAY EN EL FRUITMANAGER
        currentFruits = transform.childCount;
        //CALCULAMOS EL NUMERO DE FRUTAS RECOGIDAS EN FUNCIÓN DEL NUMERO DE FRUTAS QUE HAY FRENTE A LAS QUE HABÍA
        fruitsCollected = totalFruits - currentFruits;
        //ACTUALIZAMOS EL TEXTO CONTADOR DE LA INTERFAZ
        totalFruitsCollected.text = fruitsCollected.ToString();
    }
}

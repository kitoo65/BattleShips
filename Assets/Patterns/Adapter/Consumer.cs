using UnityEngine;
using System;

namespace Patterns.Adapter
{
    //3, creamos un consumidor, para nuestra prueba.
    public class Consumer : MonoBehaviour
    {

        private FileDataStoreAdapter _fileDataStoreAdapter;
        //3 El consumidor, busca los datos, se crea una "data" a guardar, 
        //Y luego al recibir con el SetData, se serializa en un JSOn, 
        //Y el json se transforma en un archivo.
        private void Awake()
        {
            _fileDataStoreAdapter = new FileDataStoreAdapter();
            var data = new Data("Dato 1", 123);
            _fileDataStoreAdapter.SetData(data,"Data1");

        }

        private void Start()
        {
            //4. El consumidor tambien el start, busca la informacion del fichero.
            var data = _fileDataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);

        }
    }
}
using Patterns.Adapter;
using UnityEngine;
namespace Patterns.Strategy
{
    public partial class Consumer
    {
        private readonly DataStore _dataStore;
        //Este es el constructor, de forma que no sabrá cuál adapter utiliza.
        public Consumer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
        //Luego de armar este codigo, vemos como inyectar la dependencia. Para esto, 
        //Se utiliza la clase installer, que ya hemos visto en el proyecto principal.

        public void Save()
        {
            var data = new Data("Dato3",999);
            _dataStore.SetData(data,"Dato3");
        }

        public void Load()
        {
           var data = _dataStore.GetData<Data>("Dato3");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}
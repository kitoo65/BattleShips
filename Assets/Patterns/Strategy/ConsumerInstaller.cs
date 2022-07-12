using Patterns.Adapter;
using UnityEngine;
namespace Patterns.Strategy
{
        //Aqui es donde yo creo esta clase, que lo que hace es
        //Determinar qué tipo de adapter utilizamos.
public class ConsumerInstaller : MonoBehaviour
    {
    
        private void Awake()
        {
        var consumer = new Consumer(GetDataStore());
        consumer.Save();
        consumer.Load();
        }
        private DataStore GetDataStore()
        {
            var isEven = Random.Range(0,99) % 2 == 0;
            if (isEven)
            {
                return new PlayerPrefsAdapter();
            }
                return new FileDataStoreAdapter();
            }
    }
}
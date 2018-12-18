using System;

namespace CardCreator.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Pokémon TCG Card Creator");
            callback(item, null);
        }
    }
}
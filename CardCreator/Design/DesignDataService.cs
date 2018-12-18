using System;
using Editor.Model;

namespace Editor.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Pokémon TCG Card Creator");
            callback(item, null);
        }
    }
}
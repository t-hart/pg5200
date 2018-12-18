using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using UI.Tile;

namespace UI.ViewModel
{
    public class UpdateTileMessage : MessageBase
    {
        public ITile TileData { get; }

        public UpdateTileMessage(ITile tileData)
        {
            TileData = tileData;
        }
    }
}

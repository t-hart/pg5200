using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.ViewModel
{
    class CardTabViewModel : ITab<IFieldable>
    {
        public IFieldable ContentViewModel { get; set; }
    }
}

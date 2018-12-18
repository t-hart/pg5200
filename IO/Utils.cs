using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IO
{
    public static class Utils
    {
        // ReSharper disable once InconsistentNaming
        public static void PerformIO<T>(Func<IIOResult<T>> operation) where T : class
        {
            var result = operation();
            if (result.IsError) { Alert(result.Err); }
        }

        public static void Alert(Exception e) => MessageBox.Show(e.Message);
    }
}

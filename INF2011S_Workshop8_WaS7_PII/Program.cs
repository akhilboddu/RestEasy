using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF2011S_Workshop8_WaS7_PII.PresentationLayer;
using INF2011S_Workshop8_WaS7_PII.BusinessLayer;

namespace INF2011S_Workshop8_WaS7_PII
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RestEasyMDIParent());
        }
    }
}

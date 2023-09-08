using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IncrementService
{
    class Program
    {
        static void Main(string[] args)
        {
            IncrementService service = new IncrementService();

            try
            {
                ServiceBase.Run(service);
                ServiceLogger.Log("Log", "Servicio iniciado");
            }
            catch (Exception ex)
            {
                ServiceLogger.Log("Log", "Service_Error al crear servicio", ex.Message);
            }
            
        }
    }
}
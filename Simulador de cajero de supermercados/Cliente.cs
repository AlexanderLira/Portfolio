using System;

namespace Simulador_de_cajero_de_supermercados
{
    internal class Cliente
    {
        public int Id { get; set; }
        public int CantidadProductos { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraInicioAtencion { get; set; }
        public DateTime? HoraFinalizacion { get; set; }

        // "esperando", "siendo_atendido", "finalizado"
        public string Estado { get; set; } 
        public int? CajeroAsignado { get; set; }

        public Cliente(int id, int cantidadProductos)
        {
            Id = id;
            CantidadProductos = cantidadProductos;
            HoraEntrada = DateTime.Now;
            Estado = "esperando";
        }

        public int CalcularTiempoAtencion()
        {
            // 3 segundos base + 3 segundos por cada 10 productos
            int tiempoBase = 3000;
            int tiempoExtra = (CantidadProductos / 10) * 3000;
            return tiempoBase + tiempoExtra;
        }

        public int TiempoEsperaMs()
        {
            if (HoraInicioAtencion.HasValue)
            {
                return (int)(HoraInicioAtencion.Value - HoraEntrada).TotalMilliseconds;
            }
            return (int)(DateTime.Now - HoraEntrada).TotalMilliseconds;
        }
    }
}

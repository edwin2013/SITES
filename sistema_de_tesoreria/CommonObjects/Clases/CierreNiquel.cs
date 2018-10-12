using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CierreNiquel : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }


      

        protected Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected bool _terminado = false;

        public bool Terminado
        {
            get { return _terminado; }
            set { _terminado = value; }
        }

        public bool Activo
        {
            get { return !_terminado; }
        }

        public bool Cargas_listas
        {
            get { return this.cargasListas(); }
        }

        protected BindingList<PedidoNiquel> _cargas = new BindingList<PedidoNiquel>();

        public BindingList<PedidoNiquel> Cargas
        {
            get { return _cargas; }
            set { _cargas = value; }
        }

        protected BindingList<DescargaATM> _descargas = new BindingList<DescargaATM>();

        public BindingList<DescargaATM> Descargas
        {
            get { return _descargas; }
            set { _descargas = value; }
        }

        protected BindingList<DescargaATMFull> _descargas_full = new BindingList<DescargaATMFull>();

        public BindingList<DescargaATMFull> Descargas_full
        {
            get { return _descargas_full; }
            set { _descargas_full = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_descargas = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_descargas
        {
            get { return _montos_descargas; }
            set { _montos_descargas = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_mesa_descargas = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_mesa_descargas
        {
            get { return _montos_mesa_descargas; }
            set { _montos_mesa_descargas = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_cola_descargas = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_cola_descargas
        {
            get { return _montos_cola_descargas; }
            set { _montos_cola_descargas = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_descargas_full = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_descargas_full
        {
            get { return _montos_descargas_full; }
            set { _montos_descargas_full = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_mesa_descargas_full = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_mesa_descargas_full
        {
            get { return _montos_mesa_descargas_full; }
            set { _montos_mesa_descargas_full = value; }
        }

        protected BindingList<MontoCierreATMs> _montos_cola_descargas_full = new BindingList<MontoCierreATMs>();

        public BindingList<MontoCierreATMs> Montos_cola_descargas_full
        {
            get { return _montos_cola_descargas_full; }
            set { _montos_cola_descargas_full = value; }
        }

        protected decimal _monto_cola_descargas_colones;

        public decimal Monto_cola_descargas_colones
        {
            get { return _monto_cola_descargas_colones; }
        }

        protected decimal _monto_cola_descargas_dolares;

        public decimal Monto_cola_descargas_dolares
        {
            get { return _monto_cola_descargas_dolares; }
        }

        protected decimal _monto_mesa_descargas_colones;

        public decimal Monto_mesa_descargas_colones
        {
            get { return _monto_mesa_descargas_colones; }
        }

        protected decimal _monto_mesa_descargas_dolares;

        public decimal Monto_mesa_descargas_dolares
        {
            get { return _monto_mesa_descargas_dolares; }
        }

        protected decimal _monto_cola_descargas_full_colones;

        public decimal Monto_cola_descargas_full_colones
        {
            get { return _monto_cola_descargas_full_colones; }
        }

        protected decimal _monto_cola_descargas_full_dolares;

        public decimal Monto_cola_descargas_full_dolares
        {
            get { return _monto_cola_descargas_full_dolares; }
        }

        protected decimal _monto_mesa_descargas_full_colones;

        public decimal Monto_mesa_descargas_full_colones
        {
            get { return _monto_mesa_descargas_full_colones; }
        }

        protected decimal _monto_mesa_descargas_full_dolares;

        public decimal Monto_mesa_descargas_full_dolares
        {
            get { return _monto_mesa_descargas_full_dolares; }
        }

        protected decimal _monto_colones_descargas;

        public decimal Monto_colones_descargas
        {
            get { return _monto_colones_descargas; }
        }

        protected decimal _monto_dolares_descargas;

        public decimal Monto_dolares_descargas
        {
            get { return _monto_dolares_descargas; }
        }

        protected decimal _monto_colones_descargas_full;

        public decimal Monto_colones_descargas_full
        {
            get { return _monto_colones_descargas_full; }
        }

        protected decimal _monto_dolares_descargas_full;

        public decimal Monto_dolares_descargas_full
        {
            get { return _monto_dolares_descargas_full; }
        }

        public decimal Diferencia_colones_descargas
        {
            get { return _monto_colones_descargas - (_monto_mesa_descargas_colones + _monto_cola_descargas_colones); }
        }

        public decimal Diferencia_dolares_descargas
        {
            get { return _monto_dolares_descargas - (_monto_mesa_descargas_dolares + _monto_cola_descargas_dolares); }
        }

        public decimal Diferencia_colones_descargas_full
        {
            get { return _monto_colones_descargas_full - (_monto_mesa_descargas_full_colones + _monto_cola_descargas_full_colones); }
        }

        public decimal Diferencia_dolares_descargas_full
        {
            get { return _monto_dolares_descargas_full - (_monto_mesa_descargas_full_dolares + _monto_cola_descargas_full_dolares); }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreNiquel(Colaborador cajero,
                          int id = 0,
                          Colaborador coordinador = null,
                          Camara camara = null,
                          DateTime? fecha = null, 
                          bool terminado = false)
        {
            this.DB_ID = id;

            _cajero = cajero;
            _coordinador = coordinador;
            _camara = camara;
            _fecha = fecha ?? DateTime.Now;
            _terminado = terminado;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una carga al cierre.
        /// </summary>
        /// <param name="carga">Carga a agregar</param>
        public void agregarCarga(PedidoNiquel carga)
        {
            _cargas.Add(carga);
        }

        /// <summary>
        /// Quitar una carga del cierre.
        /// </summary>
        /// <param name="carga">Carga a quitar</param>
        public void quitarCarga(PedidoNiquel carga)
        {
            _cargas.Remove(carga);
        }

        /// <summary>
        /// Agregar una descarga al cierre.
        /// </summary>
        /// <param name="descarga">Descarga a agregar</param>
        public void agregarDescarga(DescargaATM descarga)
        {
            _descargas.Add(descarga);
        }

        /// <summary>
        /// Quitar una descarga del cierre.
        /// </summary>
        /// <param name="descarga">Descarga a quitar</param>
        public void quitarDescarga(DescargaATM descarga)
        {
            _descargas.Remove(descarga);
        }

        /// <summary>
        /// Agregar una descarga al cierre.
        /// </summary>
        /// <param name="descarga">Descarga a agregar</param>
        public void agregarDescargaFull(DescargaATMFull descarga)
        {
            _descargas_full.Add(descarga);
        }

        /// <summary>
        /// Quitar una descarga del cierre.
        /// </summary>
        /// <param name="descarga">Descarga a quitar</param>
        public void quitarDescargaFull(DescargaATMFull descarga)
        {
            _descargas_full.Remove(descarga);
        }

        /// <summary>
        /// Crear los montos de cierre por denominación para las descargas normales.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los montos</param>
        public void crearMontosDescargas(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                MontoCierreATMs monto_mesa_descarga = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.MesaDescarga);
                MontoCierreATMs monto_cola_descarga = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.ColaDescarga);

                this.agregarMontoCierre(monto_mesa_descarga);
                this.agregarMontoCierre(monto_cola_descarga);
            }

        }

        /// <summary>
        /// Crear los montos de cierre por denominación para las descargas full.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los montos</param>
        public void crearMontosDescargasFull(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                if (denominacion.Moneda != Monedas.Euros)
                {

                    if (denominacion.Moneda == Monedas.Colones)
                    {
                        if (denominacion.Valor > 500)
                        {
                            MontoCierreATMs monto_mesa_descarga_full = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.MesaDescargaFull);
                            MontoCierreATMs monto_cola_descarga_full = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.ColaDescargaFull);
                            this.agregarMontoCierre(monto_mesa_descarga_full);
                            this.agregarMontoCierre(monto_cola_descarga_full);
                        }
                    }
                    else
                    {
                        MontoCierreATMs monto_mesa_descarga_full = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.MesaDescargaFull);
                        MontoCierreATMs monto_cola_descarga_full = new MontoCierreATMs(denominacion: denominacion, tipo: TiposMontoCierre.ColaDescargaFull);
                        this.agregarMontoCierre(monto_mesa_descarga_full);
                        this.agregarMontoCierre(monto_cola_descarga_full);
                    }
                }

               

               
            }

        }

        /// <summary>
        /// Agregar un monto por denominación en mesa para descargas.
        /// </summary>
        /// <param name="monto">Monto a agregar</param>
        public void agregarMontoCierre(MontoCierreATMs monto)
        {

            switch (monto.Tipo)
            {
                case TiposMontoCierre.MesaDescarga:
                    _montos_mesa_descargas.Add(monto);
                    _montos_descargas.Add(monto);
                    break;
                case TiposMontoCierre.ColaDescarga:
                    _montos_cola_descargas.Add(monto);
                    _montos_descargas.Add(monto);
                    break;
                case TiposMontoCierre.MesaDescargaFull:
                    if (monto.Denominacion.Moneda != Monedas.Euros)
                    {

                        if (monto.Denominacion.Moneda == Monedas.Colones)
                        {
                            if (monto.Denominacion.Valor > 500)
                            {
                                _montos_mesa_descargas_full.Add(monto);
                                _montos_descargas_full.Add(monto);
                            }
                        }
                        else
                        {
                            _montos_mesa_descargas_full.Add(monto);
                            _montos_descargas_full.Add(monto);
                        }
                    }
                    break;
                case TiposMontoCierre.ColaDescargaFull:
                    if (monto.Denominacion.Moneda != Monedas.Euros)
                    {

                        if (monto.Denominacion.Moneda == Monedas.Colones)
                        {
                            if (monto.Denominacion.Valor > 500)
                            {
                                _montos_cola_descargas_full.Add(monto);
                                _montos_descargas_full.Add(monto);
                            }
                        }
                        else
                        {
                            _montos_cola_descargas_full.Add(monto);
                            _montos_descargas_full.Add(monto);
                        }
                    }

                    
                    break;
            }

        }

        /// <summary>
        /// Quitar un monto por denominación en mesa.
        /// </summary>
        /// <param name="monto">Monto a quitar</param>
        public void quitarMontoCierre(MontoCierreATMs monto)
        {

            switch (monto.Tipo)
            {
                case TiposMontoCierre.MesaDescarga:
                    _montos_mesa_descargas.Remove(monto);
                    _montos_descargas.Remove(monto);
                    break;
                case TiposMontoCierre.ColaDescarga:
                    _montos_cola_descargas.Remove(monto);
                    _montos_descargas.Remove(monto);
                    break;
                case TiposMontoCierre.MesaDescargaFull:
                    _montos_mesa_descargas_full.Remove(monto);
                    _montos_descargas_full.Remove(monto);
                    break;
                case TiposMontoCierre.ColaDescargaFull:
                    _montos_cola_descargas_full.Remove(monto);
                    _montos_descargas_full.Remove(monto);
                    break;
            }

            
        }

        /// <summary>
        /// Recalcular los montos del cierre.
        /// </summary>
        public void recalcularMontosCierre()
        {
            // Montos de descargas

            _monto_cola_descargas_colones = 0;
            _monto_cola_descargas_dolares = 0;

            _monto_mesa_descargas_colones = 0;
            _monto_mesa_descargas_dolares = 0;

            _monto_colones_descargas = 0;
            _monto_dolares_descargas = 0;

            // Montos descargados

            foreach (DescargaATM descarga in _descargas)
            {
                _monto_colones_descargas += descarga.Monto_descarga_colones;
                _monto_dolares_descargas += descarga.Monto_descarga_dolares;
            }

            // Montos en mesa

            foreach (MontoCierreATMs monto in _montos_mesa_descargas)
            {

                switch (monto.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_mesa_descargas_colones += monto.Monto;
                        break;
                    case Monedas.Dolares:
                        _monto_mesa_descargas_dolares += monto.Monto;
                        break;
                }

            }

            // Montos en cola

            foreach (MontoCierreATMs monto in _montos_cola_descargas)
            {

                switch (monto.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_cola_descargas_colones += monto.Monto;
                        break;
                    case Monedas.Dolares:
                        _monto_cola_descargas_dolares += monto.Monto;
                        break;
                }

            }

            // Montos de descargas full

            _monto_cola_descargas_full_colones = 0;
            _monto_cola_descargas_full_dolares = 0;

            _monto_mesa_descargas_full_colones = 0;
            _monto_mesa_descargas_full_dolares = 0;

            _monto_colones_descargas_full = 0;
            _monto_dolares_descargas_full = 0;

            // Montos descargados

            foreach (DescargaATMFull descarga in _descargas_full)
            {
                _monto_colones_descargas_full += descarga.Monto_descarga_colones;
                _monto_dolares_descargas_full += descarga.Monto_descarga_dolares;
            }

            // Montos en mesa

            foreach (MontoCierreATMs monto in _montos_mesa_descargas_full)
            {

                switch (monto.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_mesa_descargas_full_colones += monto.Monto;
                        break;
                    case Monedas.Dolares:
                        _monto_mesa_descargas_full_dolares += monto.Monto;
                        break;
                }

            }

            // Montos en cola

            foreach (MontoCierreATMs monto in _montos_cola_descargas_full)
            {

                switch (monto.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_cola_descargas_full_colones += monto.Monto;
                        break;
                    case Monedas.Dolares:
                        _monto_cola_descargas_full_dolares += monto.Monto;
                        break;
                }

            }

        }

        #endregion Métodos Públicos

        #region Metodos Privados

        /// <summary>
        /// Verificar si una carga está lista.
        /// </summary>
        /// <returns>Valor que indica si las cargas están listas</returns>
        private bool cargasListas()
        {

            foreach (PedidoNiquel carga in _cargas)
                if (carga.Colaborador_verificador == null)
                    return false;

            return true;
        }

        #endregion Metodos Privados

        #region Overrides

        public override string ToString()
        {
            return _cajero.ToString();
        }

        #endregion Overrides
    }
}

//
//  @ Project : 
//  @ File Name : EsquemaManifiesto.cs
//  @ Date : 03/07/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class EsquemaManifiesto : ObjetoIndexado
    {

        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected decimal _ancho;

        public decimal Ancho
        {
            get { return _ancho; }
            set { _ancho = value; }
        }

        protected decimal _alto;

        public decimal Alto
        {
            get { return _alto; }
            set { _alto = value; }
        }

        protected EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        protected BindingList<PosicionEsquema> _posiciones = new BindingList<PosicionEsquema>();

        public BindingList<PosicionEsquema> Posiciones
        {
            get { return _posiciones; }
            set { _posiciones = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public EsquemaManifiesto(byte id = 0,
                                 EmpresaTransporte transportadora = null,
                                 decimal ancho = 0,
                                 decimal alto = 0)
        {
            this.DB_ID = id;

            _transportadora = transportadora;
            _ancho = ancho;
            _alto = alto;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una posicion al esquema.
        /// </summary>
        /// <param name="posicion">Posicion a agregar</param>
        public void agregarPosicion(PosicionEsquema posicion)
        {
            _posiciones.Add(posicion);
        }

        /// <summary>
        /// Quitar una posicion del esquema.
        /// </summary>
        /// <param name="posicion">Posicion a quitar</param>
        public void quitarPosicion(PosicionEsquema posicion)
        {
            _posiciones.Remove(posicion);
        }

        /// <summary>
        /// Obtener el punto para el id de una posición.
        /// </summary>
        /// <param name="id">Id de la posición</param>
        /// <param name="iteracion">Número de iteración del punto</param>
        /// <returns>Punto de la posición indicada</returns>
        public PointF obtenerPunto(byte id, int iteracion)
        {
            PointF punto;
            float posicion_x = 0;
            float posicion_y = 0;

            foreach (PosicionEsquema posicion in _posiciones)
            {

                if (posicion.Id_impresion == id)
                {
                    posicion_x = (float)(posicion.Posicion_x * 10) +
                                 (float)(posicion.Desplazamiento_horizontal * 10 * iteracion);
                    posicion_y = (float)posicion.Posicion_y * 10 +
                                 (float)(posicion.Desplazamiento_vertical * 10 * iteracion);
                    break;
                }

            }

            punto = new PointF(posicion_x, posicion_y);

            return punto;
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _transportadora.Nombre + " " + this.ID;
        }

        #endregion Overrides

    }

}

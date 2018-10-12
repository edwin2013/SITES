using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class ChequesProcesados : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected DateTime _fecha_registro;
        public DateTime FechaRegistro
        {
            set { _fecha_registro = value; }
            get { return _fecha_registro; }
        }

        protected Colaborador _digitador;
        public Colaborador Digitador
        {
            set { _digitador = value; }
            get { return _digitador; }
        }


        protected Colaborador _oficial_camara;
        public Colaborador OficialCamara
        {
            set { _oficial_camara = value; }
            get { return _oficial_camara; }
        }


      

        protected BindingList<CorteCheque> _cheques = new BindingList<CorteCheque>();
        public BindingList<CorteCheque> Cheques
        {
            set { _cheques = value; }
            get { return _cheques; }
        }




        protected BindingList<Cheque> _cheques_rechazados = new BindingList<Cheque>();
        public BindingList<Cheque> ChequesRechazados
        {
            set { _cheques_rechazados = value; }
            get { return _cheques_rechazados; }
        }


        protected decimal _cheques_locales_colones;
        public decimal ChequesLocalesColones
        {
            set { _cheques_locales_colones = value; }
            get { return _cheques_locales_colones; }
        }



        protected decimal _cheques_locales_dolares;
        public decimal ChequesLocalesDolares
        {
            set { _cheques_locales_dolares = value; }
            get { return _cheques_locales_dolares; }
        }



        protected decimal _cheques_exterior_colones;
        public decimal ChequesExteriorColones
        {
            set { _cheques_exterior_colones = value; }
            get { return _cheques_exterior_colones; }
        }


        protected decimal _cheques_exterior_dolares;
        public decimal ChequesExteriorDolares
        {
            set { _cheques_exterior_dolares = value; }
            get { return _cheques_exterior_dolares; }
        }


        protected decimal _cheques_nuestros_colones;
        public decimal ChequesNuestrosColones
        {
            set { _cheques_nuestros_colones = value; }
            get { return _cheques_nuestros_colones; }
        }


        protected decimal _cheques_nuestros_dolares;
        public decimal ChequesNuestrosDolares
        {
            set { _cheques_nuestros_dolares = value; }
            get { return _cheques_nuestros_dolares; }
        }



        protected decimal _cupones_combustible;
        public decimal CuponesCombustible
        {
            set { _cupones_combustible = value; }
            get { return _cupones_combustible; }
        }


        protected decimal _cupones_combustible_dolares;
        public decimal CuponesCombustibleDolares
        {
            set { _cupones_combustible_dolares = value; }
            get { return _cupones_combustible_dolares; }
        }


        protected decimal TotalCuponesCombustibleColones
        {
            get {
                decimal total = 0; 
            
                foreach(CorteCheque corte in _cheques)
                {
                    foreach(Cheque ch in corte.Cheques)
                    {
                        if(ch.TipoCheque == TipoCheque.Cupones && ch.Moneda == Monedas.Colones)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total; 
            
            
            }
        }



        protected decimal TotalCuponesCombustibleDolares
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cupones && ch.Moneda == Monedas.Dolares)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }


        protected decimal TotalAmerichekColones
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Americheck && ch.Moneda == Monedas.Colones)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }




        protected decimal TotalAmerichekDolares
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Americheck && ch.Moneda == Monedas.Dolares)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }




        protected decimal TotalChequesBACColones
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_BAC && ch.Moneda == Monedas.Colones)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }



        protected decimal TotalChequesBACDolares
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_BAC && ch.Moneda == Monedas.Dolares)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }



        protected decimal TotalChequesExteriorColones
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_Exterior && ch.Moneda == Monedas.Colones)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }



        protected decimal TotalChequesExteriorDolares
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_Exterior && ch.Moneda == Monedas.Dolares)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }



        protected decimal TotalChequesLocalesColones
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_Locales && ch.Moneda == Monedas.Colones)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }





        protected decimal TotalChequesLocalesDolares
        {
            get
            {
                decimal total = 0;

                foreach (CorteCheque corte in _cheques)
                {
                    foreach (Cheque ch in corte.Cheques)
                    {
                        if (ch.TipoCheque == TipoCheque.Cheques_Locales && ch.Moneda == Monedas.Dolares)
                        {
                            total = total + ch.Monto;
                        }
                    }
                }


                return total;


            }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ChequesProcesados(int id = 0, Colaborador digitador = null, int cantidad = 0, DateTime? fecha = null, TipoCheque tipoc = Clases.TipoCheque.Cheques_BAC,
            decimal cheques_locales_colones = 0, decimal cheques_locales_dolares = 0, decimal cheques_exterior_colones = 0, decimal cheques_exterior_dolares = 0, 
            decimal cheques_nuestros_colones = 0, decimal cheques_nuestros_dolares = 0, decimal cupones_combustible = 0, Colaborador oficial_camara = null, decimal cupones_combustible_dolares = 0)
        {
            this.DB_ID = id;
            this._cheques_locales_colones = cheques_locales_colones;
            this._cheques_locales_dolares = cheques_locales_dolares;
            this._cheques_exterior_colones = cheques_exterior_colones;
            this._cheques_nuestros_colones = cheques_exterior_colones;
            this._cheques_nuestros_dolares = cheques_exterior_colones;
            this._cupones_combustible = cupones_combustible;
            this._fecha_registro = fecha ?? DateTime.Now;
            this._digitador = digitador;
            this._oficial_camara = oficial_camara;
            this._cupones_combustible_dolares = cupones_combustible_dolares;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega un corte de cheques.
        /// </summary>
        /// <param name="corte"></param>
        public void agregarCorteCheque(CorteCheque corte)
        {
            this._cheques.Add(corte);
        }



        /// <summary>
        /// Eliminar un corte de los cheques. 
        /// </summary>
        /// <param name="corte"></param>
        public void quitarCorteCheque(CorteCheque corte)
        {
            this._cheques.Remove(corte);
        }


        /// <summary>
        /// Agregar un cheque a la lista de rechazos
        /// </summary>
        /// <param name="ch">Objeto Cheque con los datos de los cheques de rechazo</param>
        public void agregarChequeRechazado(Cheque ch)
        {
            this._cheques_rechazados.Add(ch);
        }

        /// <summary>
        /// Elimina un cheque de la lista de cheques rechazados. 
        /// </summary>
        /// <param name="ch"></param>
        public void quitarChequeRechazado(Cheque ch)
        {
            this._cheques_rechazados.Remove(ch);
        }
 
        #endregion Métodos Públicos

        #region Overrides

        //public override string ToString()
        //{
        //    return _usuario_entrega.ToString();
        //}

        #endregion Overrides

    }
}

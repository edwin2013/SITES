using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUILayer.Formularios.Blindados;
using GUILayer.Formularios.Boveda;
using GUILayer.Formularios.Bancos;
using GUILayer.Formularios.Níquel;
using GUILayer.Formularios.Facturacion;
using GUILayer.Formularios.Optimización;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmObservaciones : Form
    {

        #region Atributos

        private frmAdministracionTripulaciones _padre;
        public frmAdministracionTripulaciones Padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        private frmSucursalesPorAprobar _padre2;
        public frmSucursalesPorAprobar Padre2
        {
            get { return _padre2; }
            set { _padre2 = value; }
        }

        private frmModificacionCargaSucursal _padre3;
        public frmModificacionCargaSucursal Padre3
        {
            get { return _padre3; }
            set { _padre3 = value; }
        }

        private frmAgregarCartuchoCargaSucursal _padre4;
        public frmAgregarCartuchoCargaSucursal Padre4
        {
            get { return _padre4; }
            set { _padre4 = value; }
        }

        private frmListaCargaSucursales _padre5;
        public frmListaCargaSucursales Padre5
        {
            get { return _padre5; }
            set { _padre5 = value; }
        }


        private frmModificacionPedidoBancos _padre6;
        public frmModificacionPedidoBancos Padre6
        {
            get { return _padre6; }
            set { _padre6 = value; }
        }


        private frmAgregarCartuchoPedidoBancos _padre7;
        public frmAgregarCartuchoPedidoBancos Padre7
        {
            get { return _padre7; }
            set { _padre7 = value; }
        }



        private frmAgregarCartuchoNiquel _padre8;
        public frmAgregarCartuchoNiquel Padre8
        {
            get { return _padre8; }
            set { _padre8 = value; }
        }

        private frmModificacionPedidoNiquel _padre9;
        public frmModificacionPedidoNiquel Padre9
        {
            get { return _padre9; }
            set { _padre9 = value; }
        }

        private frmModificacionCargaTransportadora _padre10;
        public frmModificacionCargaTransportadora Padre10
        {
            get { return _padre10; }
            set { _padre10 = value; }
        }


        private frmAgregarCartuchoCargaTransportadora _padre11;
        public frmAgregarCartuchoCargaTransportadora Padre11
        {
            get { return _padre11; }
            set { _padre11 = value; }
        }


        private frmPedidosTransportadoraAprobar _padre12;
        public frmPedidosTransportadoraAprobar Padre12
        {
            get { return _padre12; }
            set { _padre12 = value; }
        }


        //private frmBandejaInconsistenciaFacturacion _padre8;
        //public frmAgregarCartuchoPedidoBancos Padre8
        //{
        //    get { return _padre8; }
        //    set { _padre8 = value; }
        //}

        String _comentario = String.Empty;

        #endregion Atributos

        #region Constructor
        public frmObservaciones()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _comentario = txtComentario.Text;

            if(_padre != null)
                _padre.asignarComentario(_comentario);
            if (_padre2 != null)
                _padre2.asignarComentario(_comentario);
            if (_padre3 != null)
                _padre3.asignarComentario(_comentario);
            if (_padre4 != null)
                _padre4.asignarComentario(_comentario);
            if (_padre5 != null)
                _padre5.asignarComentario(_comentario);
            if (_padre6 != null)
                _padre6.asignarComentario(_comentario);
            if (_padre7 != null)
                _padre7.asignarComentario(_comentario);
            if (_padre10 != null)
                _padre10.asignarComentario(_comentario);
            if (_padre11 != null)
                _padre11.asignarComentario(_comentario);
            if (_padre12 != null)
                _padre12.asignarComentario(_comentario);
        }

        #endregion Eventos

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = txtComentario.Text.Length > 0;
        }
    }
}

//
//  @ Project : 
//  @ File Name : ComboBoxBusqueda.cs
//  @ Date : 24/01/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace ImpresionManifiestos
{

    public class ComboBoxBusqueda : ComboBox
    {

        #region Atributos

        private IList _items_mostrados = null;

        [Category("Data"),
         Description("Lista de valores a Mostrar")]
        public IList ListaMostrada
        {
            set {
                _items_mostrados = value;
                this.cargarLista();
                }
            get { return _items_mostrados; }
        }
        
        #endregion Atributos

        #region Constructor

        public ComboBoxBusqueda()
        {
            // Se agregar los eventos

            this.TextUpdate += new EventHandler(this.cboCombo_TextChanged);
            this.DropDown += new EventHandler(this.ajustarLista);
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Cambiar el texto del ComboBox.
        /// </summary>
        private void cboCombo_TextChanged(object sender, EventArgs e)
        {

            // Revisar si la lista tiene items

            if (_items_mostrados != null) 
            {

                // Guardar la posicion en el cuadro de texto del la lista

                int int_posicion = this.SelectionStart;

                if (this.Text.Equals(string.Empty))
                {
                    this.cargarLista();
                }
                else
                {
                    this.Items.Clear();

                    // Agregar los valores a la lista

                    foreach (Object objeto in _items_mostrados)
                    {

                        if (objeto.ToString().ToUpper().Contains(this.Text.ToUpper()))
                            this.Items.Add(objeto);

                    }

                }

                // Si no aparece ningun resultado ocultar la lista

                if (this.Items.Count == 0)
                {
                    this.DroppedDown = false;
                }
                else
                {
                    this.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }

                // Mantener la posicion en el cuadro de texto del la lista

                this.SelectionStart = int_posicion;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Cargar los elementos en la lista.
        /// </summary>
        private void cargarLista()
        {
            this.Items.Clear();

            if (_items_mostrados != null)
            {

                foreach (object objeto in _items_mostrados)
                    this.Items.Add(objeto);

            }

        }

        private void ajustarLista(object sender, System.EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            int ancho = combo.DropDownWidth;
            Graphics manejador = combo.CreateGraphics();
            Font fuente = combo.Font;

            int vertScrollBarWidth =
                (combo.Items.Count > combo.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            int nuevo_ancho;

            foreach (object item in this.Items)
            {
                nuevo_ancho = (int)manejador.MeasureString(item.ToString(), fuente).Width + vertScrollBarWidth;
                ancho = (ancho < nuevo_ancho) ? nuevo_ancho : ancho;
            }

            combo.DropDownWidth = ancho;
        }

        #endregion Métodos Privados

    }

}
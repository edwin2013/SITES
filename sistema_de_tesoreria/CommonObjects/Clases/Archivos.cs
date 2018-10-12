using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Archivos
    {

        #region Atributos Privados
        
        private string _archivo;

        public string Archivo
        {
            get { return _archivo; }
            set { _archivo = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public Archivos(string nombreruta)
        {
            _archivo = nombreruta;
            if (System.IO.Directory.Exists(@"c:\bitacora") == false)
                System.IO.Directory.CreateDirectory(@"c:\bitacora");
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        public void writetext(String texto)
        {            
            using (StreamWriter sw = File.AppendText(Archivo))
            {
                sw.WriteLine(texto);
            }
        }        

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _archivo;
        }        

        #endregion Overrides
    }
}

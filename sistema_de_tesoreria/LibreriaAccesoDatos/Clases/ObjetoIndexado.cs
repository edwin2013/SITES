//
//  @ Project : 
//  @ File Name : ManejadorBD.cs
//  @ Date : 06/05/2012
//  @ Author : Erick Chavarría 
//

namespace LibreriaAccesoDatos
{

    public abstract class ObjetoIndexado
    {

        #region Atributos

        protected int _db_id;

        public int DB_ID
        {
            get { return _db_id; }
            set { _db_id = value; }
        }

        public bool ID_Invalido
        {
            get { return _db_id == 0; }
        }

        public bool ID_Valido
        {
            get { return _db_id != 0; }
        }

        #endregion Atributos

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            ObjetoIndexado objeto = (ObjetoIndexado)obj;

            if (this.DB_ID != objeto.DB_ID) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.DB_ID.GetHashCode();
        }

        #endregion Overrides

    }

}

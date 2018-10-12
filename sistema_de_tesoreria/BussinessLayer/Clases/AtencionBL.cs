//
//  @ Project : 
//  @ File Name : AtencionBL.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using CommonObjects;
using DataLayer;
using LibreriaMensajes;
using DataLayer.Clases;
using CommonObjects.Clases;
using System.Data;

namespace BussinessLayer
{

    /// <summary>
    /// Clase de la capa de negocios que maneja el registro de tulas y bolsas.
    /// </summary>
    public class AtencionBL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static AtencionBL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static AtencionBL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new AtencionBL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private DepositosDL _depositos = DepositosDL.Instancia;
        private TulasDL _tulas = TulasDL.Instancia;
        private ManifiestosDL _manifiestos = ManifiestosDL.Instancia;
        private ManifiestosCEFDL _manifiestos_cef = ManifiestosCEFDL.Instancia;
        private ManifiestosBovedaDL _manifiestos_boveda = ManifiestosBovedaDL.Instancia;
        private ManifiestosATMsCargasDL _manifiestos_cargas_atms = ManifiestosATMsCargasDL.Instancia;
        private ManifiestoSucursalCargaDL _manifiestos_cargas_sucursales = ManifiestoSucursalCargaDL.Instancia;
        private ManifiestoBancoPedidoDL _manifiestos_cargas_banco = ManifiestoBancoPedidoDL.Instancia;
        private ManifiestosATMsFullDL _manifiestos_atms_full = ManifiestosATMsFullDL.Instancia;
        private SegregadosDL _segregados = SegregadosDL.Instancia;
        private GruposDL _grupos = GruposDL.Instancia;
        private ClientesDL _clientes = ClientesDL.Instancia;
        private TulasDL _bolsa = TulasDL.Instancia;
        private MutiladoDL _mutilado = MutiladoDL.Instancia;
        private AsignacionAsignacionEquipoDL _asignacion_equpo = AsignacionAsignacionEquipoDL.Instancia;
        private TripulacionDL _tripulaciones = TripulacionDL.Instancia;
        private MontosBolsaSucursalesDL _montos_bolsas = MontosBolsaSucursalesDL.Instancia;
        private MontosBolsasPedidoBancoDL _montos_bolsas_bancos = MontosBolsasPedidoBancoDL.Instancia;
        private ManifiestoPedidoNiquelDL _manifiestos_niquel = ManifiestoPedidoNiquelDL.Instancia;
        private MontoBolsaNiquelDL _montos_bolsas_niquel = MontoBolsaNiquelDL.Instancia;
        private BolsaCompletaNiquelDL _bolsa_completa_niquel = BolsaCompletaNiquelDL.Instancia;
        private ChequesProcesadosDL _cheques_procesados = ChequesProcesadosDL.Instancia;
        private DocumentosDL _documentos = DocumentosDL.Instancia;

        private CajeroNiquel_DL _cajero_niquel = CajeroNiquel_DL.Instancia;		
        private ProcesamientoNiquelDL _procesamientoNiquel = ProcesamientoNiquelDL.Instancia;
        #endregion Atributos

        #region Constructor

        public AtencionBL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region Bolsas

        

        public void agregarbolsasucursalcarga(ref Bolsa b)
        {
            try
            {
                if (!_bolsa.verificarBolsaSucursal(ref b))
                {
                    _bolsa.agregarBolsaSucursal(ref b);
                }
                else
                    Mensaje.mostrarMensaje("MensajeTulayafueingresada");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarbolsasucursal(ref Bolsa b)
        {
            bool salida = false;

            try
            {
                ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)b.Manifiesto;

                salida = !_manifiestos_cargas_sucursales.verificarManifiestoSucursalCarga(ref manifiesto);

                if (salida)
                { _bolsa.agregarBolsaSucursal(ref b); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }



        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarbolsaniquel(ref BolsaNiquel b)
        {
            bool salida = false;

            try
            {
                ManifiestoNiquelPedido manifiesto = (ManifiestoNiquelPedido)b.Manifiesto;

                salida = !_manifiestos_niquel.verificarManifiestoPedidoNiquel(ref manifiesto);

                if (salida)
                { _bolsa.agregarBolsaNiquel(ref b); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }
               
        /// <summary>
        /// Listar todos las bolsas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las bolsas</param>
        /// <returns>Lista de bolsas registrados para el manifiesto indicado</returns>
        public BindingList<Bolsa>listarBolsasSucursalPorManifiesto(ManifiestoSucursalCarga m)
        {
            try
            {
                return _bolsa.listarBolsasSucursalPorManifiesto(ref m);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        ///Verifica si existe una bolsa asociada a un manifiesto.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a buscar</param>

        public bool verificarBolsaSucursal(ref Bolsa b)
        {

            try
            {
                return _bolsa.verificarBolsaSucursal(ref b);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar una bolsa ya registrada en el sistema y el manifiesto al que esta asociada la misma.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>
        /// <returns>Valor booleano que indica si el manifiesto también fue eliminado</returns>


        public bool eliminarBolsaSucursal(Bolsa b)
        {
            try
            {
                _bolsa.eliminarBolsa(b);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }



        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public void actualizarbolsasucursal(ref Bolsa b)
        {

            try
            {
                //_bolsa.actualizarBolsaSucursal(ref b);

                Bolsa copia_bolsa = new Bolsa(id: b.ID);
                _montos_bolsas.obtenerBolsaMontoSucursales(ref copia_bolsa);

                foreach (BolsaMontosSucursales bol in copia_bolsa.Cartuchos)
                    _montos_bolsas.eliminarBolsaMontoSucursal(bol);

                foreach (BolsaMontosSucursales bol in b.Cartuchos)
                {
                    BolsaMontosSucursales copia = bol;
                    copia.ID_Bolsa = b.ID;
                    _montos_bolsas.agregarBolsaMontosSucursales(ref copia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Bolsas

        #region Tulas Documentos
        
        /// <summary>
        /// Registrar una tula y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public void agregarTulaDocumento(ref Tula t)
        {
            try
            {
                _tulas.agregarTulaDocumento(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool verificarTulaDocumento(ref Tula t)
        {
            try
            {
                return _tulas.verificarTulaDocumento(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool actualizarTulaDocumento(Tula t)
        {
            try
            {
                _tulas.actualizarTulaDocumento(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public bool eliminarTulaDocumento(Tula t)
        {
            try
            {
                _tulas.eliminarTulaDocumento(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        #endregion Tulas Documentos

        #region Tulas

        /// <summary>
        /// Registrar una tula y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarTula(ref Tula t)
        {
            bool salida = false;

            try
            {
                Manifiesto manifiesto = (Manifiesto)t.Manifiesto;

                salida = !_manifiestos.verificarManifiesto(ref manifiesto);

                if (salida) _manifiestos.agregarManifiestos(ref manifiesto);

                _tulas.agregarTula(ref t);


                foreach (TulaNiquel niquel in t.Niquel)
                {
                    TulaNiquel copianiquel = niquel;
                    _tulas.agregarCantidadBolsasNiquel(ref copianiquel, t);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }

        /// <summary>
        /// Registrar una tula y su respectivo manifiesto en el sistema, del area de niquel
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarTulaNiquel(ref Tula t)
        {
            bool salida = false;

            try
            {
                Manifiesto manifiesto = (Manifiesto)t.Manifiesto;

                salida = !_manifiestos.verificarManifiestoNiquel(ref manifiesto);

                if (salida) _manifiestos.agregarManifiestoNiquel(ref manifiesto);

                _tulas.agregarTulaNiquel(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }

        /// <summary>
        /// Agregar una tula no registrada por un receptor en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <param name="c">Coordinador que registra la tula</param>
        public void agregarTula(ref Tula t, Colaborador c)
        {

            try
            {
                _tulas.agregarTula(ref t, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cambiar el manifiesto al cual pertenece una tula.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula que se actualizará</param>
        /// <param name="c">Coordinador que actualiza la tula</param>
        public void actualizarTulaManifiesto(Tula t, Colaborador c)
        {

            try
            {
                _tulas.actualizarTulaManifiesto(t, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe una tula registrada.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <returns>Valor que indica si la tula existe</returns>
        public bool verificarTula(ref Tula t)
        {

            try
            {
                return _tulas.verificarTula(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe una tula registrada en el area de niquel.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <returns>Valor que indica si la tula existe</returns>
        public bool verificarTulaNiquel(ref Tula t)
        {

            try
            {
                return _tulas.verificarTulaNiquel(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar una tula ya registrada en el sistema y el manifiesto al que esta asociada la misma.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a eliminar</param>
        /// <returns>Valor booleano que indica si el manifiesto también fue eliminado</returns>
        public bool eliminarTula(Tula t)
        {

            try
            {
                _manifiestos.eliminarManifiestoColaborador(t.Manifiesto);
                
                _tulas.eliminarTula(t);

                Manifiesto manifiesto = (Manifiesto)t.Manifiesto;
                BindingList<Tula> tulas = _tulas.listarTulasPorManifiesto(manifiesto);

                if (tulas.Count == 0)
                {
                    _manifiestos.eliminarManifiesto(manifiesto);
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Eliminar una tula ya registrada en el sistema y el manifiesto al que esta asociada la misma, en el area de niquel
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a eliminar</param>
        /// <returns>Valor booleano que indica si el manifiesto también fue eliminado</returns>
        public bool eliminarTulaNiquel(Tula t)
        {

            try
            {
                _tulas.eliminarTulaNiquel(t);

                Manifiesto manifiesto = (Manifiesto)t.Manifiesto;
                BindingList<Tula> tulas = _tulas.listarTulasPorManifiestoNiquel(manifiesto);

                if (tulas.Count == 0)
                {
                    _manifiestos.eliminarManifiestoNiquel(manifiesto);
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Eliminar una tula ya registrada en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula a eliminar</param>
        public void eliminarTulaCorrecion(Tula t)
        {

            try
            {
                if (!_tulas.verificarTula(ref t))
                    throw new Excepcion("ErrorTulaCorreccion");

                if (_tulas.verificarTulaProcesamiento(ref t))
                    throw new Excepcion("ErrorTulaCorreccionProcesamiento");

                _manifiestos.obtenerManifiestoTula(ref t);

                Manifiesto manifiesto = t.Manifiesto;

                // Eliminar la tula

                _tulas.eliminarTula(t);

                // Eliminar el manifiesto si no tiene otras tulas asociadas

                //CAmbio 13-12-2017
                //BindingList<Tula> tulas = _tulas.listarTulasPorManifiesto(manifiesto);

                //if (tulas.Count == 0) _manifiestos.eliminarManifiesto(manifiesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
          
        /// <summary>
        /// Listar todos las tulas de un manifiesto.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<Tula> listarTulasPorManifiesto(Manifiesto m)
        {
            try
            {
                return _tulas.listarTulasPorManifiesto(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Listar todas las tulas registradas entre dos determinadas fecha.
        /// </summary>
        /// <param name="i">Fecha inicial para la cual se genera la lista</param>
        /// <param name="f">Fecha final para la cual se genera la lista</param>
        /// <returns>Lista de tulas registrados entre las fechas indicadas</returns>
        public BindingList<Tula> listarTulas(DateTime i, DateTime f)
        {

            try
            {
                BindingList<Tula> tulas = _tulas.listarTulas(i, f);
                BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

                foreach (Tula tula in tulas)
                {
                    Tula copia = tula;
                    _manifiestos.obtenerManifiestoTula(ref copia);

                    // Evitar manifiestos duplicados

                    Manifiesto manifiesto = (Manifiesto)tula.Manifiesto;

                    if (manifiestos.Contains(manifiesto))
                        tula.Manifiesto = manifiestos[manifiestos.IndexOf(manifiesto)];
                    else
                        manifiestos.Add(manifiesto);

                }

                return tulas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las tulas registradas entre dos determinadas fecha. En el area de Niquel
        /// </summary>
        /// <param name="i">Fecha inicial para la cual se genera la lista</param>
        /// <param name="f">Fecha final para la cual se genera la lista</param>
        /// <returns>Lista de tulas registrados entre las fechas indicadas</returns>
        public BindingList<Tula> listarTulasNiquel(DateTime i, DateTime f)
        {

            try
            {
                BindingList<Tula> tulas = _tulas.listarTulasNiquel(i, f);
                BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

                foreach (Tula tula in tulas)
                {
                    Tula copia = tula;
                    _manifiestos.obtenerManifiestoTulaNiquel(ref copia);

                    // Evitar manifiestos duplicados

                    Manifiesto manifiesto = (Manifiesto)tula.Manifiesto;

                    if (manifiestos.Contains(manifiesto))
                        tula.Manifiesto = manifiestos[manifiestos.IndexOf(manifiesto)];
                    else
                        manifiestos.Add(manifiesto);

                }

                return tulas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las tulas que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de las tulas que se listarán</param>
        /// <returns>Lista de tulas que cumplen con el criterio de búsqueda</returns>
        public BindingList<Tula> listarTulasPorCodigo(string c)
        {

            try
            {
                return _tulas.listarTulasPorCodigo(c);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region PROA
        public void actualizarTulaCodigo(Tula t, Colaborador c)
        {

            try
            {
                _tulas.actualizarCodigoTula(t, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe una tula registrada.
        /// </summary>        
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <param name="m">Objeto Manifiesto con los datos de Manifiesto</param>
        /// <returns>Valor que indica si la tula existe</returns>
        public bool verificarTulaManifiesto(ref Tula t, ref ProcesamientoBajoVolumenManifiesto m)
        {

            try
            {
                return _tulas.verificarTula2(ref t, ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las tulas que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de las tulas que se listarán</param>
        /// <returns>Lista de tulas que cumplen con el criterio de búsqueda</returns>
        public BindingList<Tula> listarTulasPorFecha(DateTime fechaini, DateTime fechafin)
        {

            try
            {
                BindingList<Tula> tulas = _tulas.listarTulasPorFecha(fechaini, fechafin);
                BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

                foreach (Tula tula in tulas)
                {
                    Tula copia = tula;
                    _manifiestos.obtenerManifiestoTula(ref copia);

                    // Evitar manifiestos duplicados

                    Manifiesto manifiesto = (Manifiesto)tula.Manifiesto;

                    if (manifiestos.Contains(manifiesto))
                        tula.Manifiesto = manifiestos[manifiestos.IndexOf(manifiesto)];
                    else
                        manifiestos.Add(manifiesto);

                }

                return tulas;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool verificarTulaManifiesto2(ref Tula t, Manifiesto m)
        {

            try
            {
                return _tulas.verificarTula3(ref t, m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion PROA

        #endregion Tulas

        #region Grupos

        /// <summary>
        /// Actualizar el contador de cajas de un grupo.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del grupo a actualizar</param>
        public void actualizarGrupoTotales(Grupo g)
        {

            try
            {
                _grupos.actualizarGrupoTotales(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Grupos

        #region Manifiestos

        /// <summary>
        /// Agregar un nuevo manifiesto no registrado por un receptor.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del nuevo manifiesto</param>
        /// <param name="c">Coordinador que registra el manifiesto</param>
        public void agregarManifiesto(ref Manifiesto m, Colaborador c)
        {

            try
            {
                _manifiestos.agregarManifiesto(ref m, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Reiniciar los datos de un manifiesto .
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a reiniciar</param>
        public void actualizarManifiestoReiniciar(Manifiesto m)
        {

            try
            {
                _manifiestos.reiniciarManifiesto(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el código de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        /// <param name="c">Colaborador que realiza el cambio</param>
        public void actualizarCodigoManifiesto(Manifiesto m, Colaborador c)
        {

            try
            {

                if (_manifiestos.verificarManifiesto(ref m))
                    throw new Excepcion("ErrorManifiestoDuplicado");

                _manifiestos.actualizarCodigoManifiesto(m, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el grupo de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarGrupoManifiesto(Manifiesto m)
        {

            try
            {
                _manifiestos.actualizarGrupoManifiesto(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el área de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarAreaManifiesto(Manifiesto m)
        {

            try
            {
                _manifiestos.actualizarGrupoManifiesto(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar un manifiesto desmarcándolo como entregado tardiamente por la transportadora.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoDesmarcarRetraso(ref Manifiesto m)
        {

            try
            {
                m.Retraso = false;

                _manifiestos.actualizarManifiestoDesmarcarRetraso(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar un manifiesto marcándolo como entregado tardiamente por la transportadora.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoMarcarRetraso(ref Manifiesto m)
        {

            try
            {
                m.Retraso = true;

                _manifiestos.actualizarManifiestoMarcarRetraso(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<Manifiesto> listarManifiestosPorCodigo(string c)
        {

            try
            {
                return _manifiestos.listarManifiestosPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener el manifiesto al que está ligado una tula.
        /// </summary>
        /// <param name="t">Tula para la cual se obtendrá el manifiesto al que está ligada</param>
        public void obtenerManifiestoTula(ref Tula t)
        {

            try
            {
                _manifiestos.obtenerManifiestoTula(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region PROA

        public void actualizarManifiestoCodigo(ref Manifiesto m, Colaborador c)
        {

            try
            {
                _manifiestos.actualizarManifiestoCodigo(m, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<Manifiesto> listarManifiestosPorFecha(DateTime i, DateTime f)
        {

            try
            {
                return _manifiestos.listarManifiestosPorFecha(i, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener el manifiesto al que está ligado una tula.
        /// </summary>
        /// <param name="t">Tula para la cual se obtendrá el manifiesto al que está ligada</param>
        public bool VerificarManifiestoExiste(ref ProcesamientoBajoVolumenManifiesto t, Boolean pendiente)
        {

            try
            {
                return _manifiestos.verificarManifiesto2(ref t, pendiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool VerificarManifiestoExiste2(ref Manifiesto m) //Cambio GZH 31/10/2017
        {
            try
            {

                return _manifiestos.verificarManifiesto3(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion PROA 

        #endregion Manifiestos

        #region Documentos

        public void agregarDocumento(ref Manifiesto m)
        {
            try
            {
               _documentos.agregarDocumentos(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool verificarDocumento(ref Manifiesto m)
        {
            try
            {
                return _documentos.verificarDocumento(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarDocumento(Manifiesto m)
        {
            try
            {
                _documentos.actualizarDocumento(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarDocumento(Manifiesto m)
        {
            try
            {
                _documentos.eliminarDocumento(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Documentos

        #region Manifiestos del CEF

        /// <summary>
        /// Actualizar los datos de un manifiesto o manifiesto segregado del CEF.
        /// </summary>
        /// <param name="p">Objeto PlanillaCEF con los datos del manifiesto o manifiesto segregado a actualizar</param>
        /// <param name="c">Coordinador que realiza la actualización</param>
        public void actualizarPlanillaCEF(PlanillaCEF p, Colaborador c)
        {

            try
            {

                if (p is ManifiestoCEF)
                    _manifiestos_cef.actualizarManifiestoCEF((ManifiestoCEF)p, c);
                else
                    _segregados.actualizarSegregado((SegregadoCEF)p, c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos del CEF que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoCEF> listarManifiestosCEFPorCodigo(string c)
        {

            try
            {
                return _manifiestos_cef.listarManifiestosCEFPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos del cef que tienen un determinado código o parte del mismo recibidos en los últimos 2 meses.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoCEF> listarManifiestosCEFRecientes(string c)
        {

            try
            {
                BindingList<ManifiestoCEF> manifiestos = _manifiestos_cef.listarManifiestosCEFRecientes(c);

                foreach (ManifiestoCEF manifiesto in manifiestos)
                {
                    ManifiestoCEF copia = manifiesto;

                    _manifiestos_cef.obtenerDatosManifiestoCEF(ref copia);
                        
                    this.obtenerSegregados(ref copia);
                }

                return manifiestos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Metodo que permite segregar un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Manifiesto que se segregará</param>
        /// <param name="c">Número de cajeros para los cuales se segrega el manifiesto</param>
        public void segregarManifiesto(ManifiestoCEF m, int c)
        {

            try
            {
                _manifiestos.reiniciarManifiesto(m);

                for (int contador = 0; contador < c; contador++)
                {
                    SegregadoCEF nuevo = new SegregadoCEF(m);

                    _segregados.agregarSegregado(ref nuevo);

                    m.agregarSegregado(nuevo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Método que permite eliminar los segregados de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se eliminan los segregados</param>
        public void eliminarSegregadosManifiesto(ManifiestoCEF m)
        {

            try
            {
                _segregados.eliminarSegregados(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Reiniciar los datos de un manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del manifiesto segregado a reiniciar</param>
        public void reiniciarSegregado(SegregadoCEF s)
        {

            try
            {
                _segregados.reiniciarSegregado(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos segregados que son parte de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se obtienen los manifiestos segregados</param>
        public void obtenerSegregados(ref ManifiestoCEF m)
        {

            try
            {
                _segregados.obtenerSegregados(ref m);

                foreach (SegregadoCEF segregado in m.Segregados)
                {
                    SegregadoCEF copia_segregado = segregado;

                    _segregados.obtenerDatosSegregado(ref copia_segregado);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Manifiestos del CEF

        #region Manifiestos de Bóveda

        /// <summary>
        /// Actualizar los datos de un manifiesto de bóveda.
        /// </summary>
        /// <param name="m">Objeto ManifiestoBoveda con los datos del manifiesto actualizar</param>
        public void actualizarManifiesto(ManifiestoBoveda m)
        {

            try
            {
                _manifiestos_boveda.actualizarManifiestoBoveda(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos de bóveda que tienen un determinado código o parte del mismo recibidos en los últimos 2 meses.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoBoveda> listarManifiestosBovedaRecientes(string c)
        {

            try
            {
                BindingList<ManifiestoBoveda> manifiestos = _manifiestos_boveda.listarManifiestosBovedaRecientes(c);

                foreach (ManifiestoBoveda manifiesto in manifiestos)
                {
                    ManifiestoBoveda copia = manifiesto;

                    _manifiestos_boveda.obtenerDatosManifiestoBoveda(ref copia);
                }

                return manifiestos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Manifiestos de Bóveda

        #region Manifiestos de Cargas de ATM's

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del nuevo manifiesto</param>
        public void agregarManifiestoATMCarga(ref ManifiestoATMCarga m)
        {

            try
            {
                if (_manifiestos_cargas_atms.verificarManifiestoATMCarga(ref m))
                    throw new Excepcion("ErrorManifiestoATMCargaDuplicado");

                _manifiestos_cargas_atms.agregarManifiestoATMCarga(ref m);

                _manifiestos_cargas_atms.obtenerManifiestoDatos(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoATMCarga(ManifiestoATMCarga m)
        {
            try
            {
                if (_manifiestos_cargas_atms.verificarManifiestoATMCarga(ref m))
                    throw new Excepcion("ErrorManifiestoATMCargaDuplicado");

                _manifiestos_cargas_atms.actualizarManifiestoATMCarga(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoATMCarga(ManifiestoATMCarga m)
        {

            try
            {
                _manifiestos_cargas_atms.eliminarManifiestoATMCarga(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de ATM's que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoATMCarga> listarManifiestosATMsCargasPorCodigo(string c)
        {

            try
            {
                return _manifiestos_cargas_atms.listarManifiestosATMsCargasPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Manifiestos de Cargas de ATM's

        #region Manifiestos de ATM's Full

        /// <summary>
        /// Registrar un nuevo manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del nuevo manifiesto</param>
        public void agregarManifiestoATMFull(ref ManifiestoATMFull m)
        {

            try
            {
                if (_manifiestos_atms_full.verificarManifiestoATMFull(ref m))
                    throw new Excepcion("ErrorManifiestoATMFullDuplicado");

                _manifiestos_atms_full.agregarManifiestoATMFull(ref m);

                _manifiestos_atms_full.obtenerManifiestoDatos(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoATMFull(ManifiestoATMFull m)
        {

            try
            {
                if (_manifiestos_atms_full.verificarManifiestoATMFull(ref m))
                    throw new Excepcion("ErrorManifiestoATMFullDuplicado");

                _manifiestos_atms_full.actualizarManifiestoATMFull(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Eliminar los datos de un manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoATMFull(ManifiestoATMFull m)
        {

            try
            {
                _manifiestos_atms_full.eliminarManifiestoATMFull(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Obtener una lista de los manifiestos de ATM's Full que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoATMFull> listarManifiestosATMsFullPorCodigo(string c)
        {

            try
            {
                return _manifiestos_atms_full.listarManifiestosATMsFullPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Manifiestos de ATM's Full

        #region Depositos

        /// <summary>
        /// Registrar un nuevo deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito</param>
        public void agregarDeposito(ref Deposito d)
        {

            try
            {
                if (_depositos.verificarDeposito(d))
                    throw new Excepcion("ErrorDepositoDuplicado");

                _depositos.agregarDeposito(ref d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a actualizar</param>
        public void actualizarDeposito(Deposito d)
        {

            try
            {
                if (_depositos.verificarDeposito(d))
                    throw new Excepcion("ErrorDepositoDuplicado");

                _depositos.actualizarDeposito(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a eliminar</param>
        public void eliminarDeposito(Deposito d)
        {

            try
            {
                _depositos.eliminarDeposito(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<Deposito> listarDepositos(int r)
        {

            try
            {
                return _depositos.listarDepositosPorReferencia(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Depositos

        #region Manifiestos de Cargas de Sucursales

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del nuevo manifiesto</param>
        public void agregarManifiestoSucursalCarga(ref ManifiestoSucursalCarga m)
        {

            try
            {
                if (_manifiestos_cargas_sucursales.verificarManifiestoSucursalCarga(ref m))
                    throw new Excepcion("ErrorManifiestoSucursalCargaDuplicado");

                _manifiestos_cargas_sucursales.agregarManifiestoSucursalCarga(ref m);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un BAnco
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoSucursalCarga(ref CargaSucursal pedido)
        {

            try
            {
                foreach (ManifiestoSucursalCarga m in pedido.Manifiesto)
                {
                    ManifiestoSucursalCarga copia = m;
                    m.Pedido = pedido;


                    ManifiestoSucursalCarga copia_g = new ManifiestoSucursalCarga(id: m.ID);

                    copia_g.ListaBolsas = new BindingList<Bolsa>();
                    _bolsa.listarBolsasSucursalPorManifiesto(ref copia_g);


                    _manifiestos_cargas_sucursales.actualizarManifiestoSucursalCarga(ref copia);

                    foreach (Bolsa bolsa in copia.ListaBolsas)
                    {

                        Bolsa copia_tula = bolsa;
                        copia_tula.IDCargaSucursal = pedido.ID;
                        copia_tula.Manifiesto = copia;

                        if (copia_g.ListaBolsas.Contains(copia_tula)) { }
                        // copia_g.quitarBolsa(copia_tula);
                        else
                            this.agregarbolsasucursal(ref copia_tula);
                    }

                    foreach (Bolsa bolsa in copia.ListaBolsas)
                    {

                        Bolsa copia_tula = bolsa;
                        copia_tula.Manifiesto = copia;

                        Bolsa copia_borrar = new Bolsa(id: copia_tula.ID);
                        _montos_bolsas.obtenerBolsaMontoSucursales(ref copia_borrar);

                        

                        foreach (BolsaMontosSucursales monto in bolsa.Cartuchos)
                        {
                            BolsaMontosSucursales copia_cartucho = monto;

                            copia_cartucho.ID_Bolsa = copia_tula.ID;

                            if(copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada > 0)
                                _montos_bolsas.actualizarBolsaMontosSucursales(ref copia_cartucho);

                            if (copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada == 0)
                                _montos_bolsas.eliminarBolsaMontoSucursal(copia_cartucho);

                            if (copia_cartucho.ID == 0)
                                _montos_bolsas.agregarBolsaMontosSucursales(ref copia_cartucho);


                        }
                    }


                    //foreach (BolsaBanco bol in copia_g.Serie_Tula)
                    //{
                    //    BolsaBanco bolsita = bol;
                    //    _bolsa.actualizarBolsaBanco(ref bolsita);
                    //}


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualiza los datos de los montos de una determinada tula
        /// </summary>
        /// <param name="b">Objeto BolsaMontosSucursales con los datos del monto a modificar</param>
        public void actualizarMontoTulasSucursales(BolsaMontosSucursales b)
        {
            try 
            {
                _montos_bolsas.actualizarBolsaMontosSucursales(ref b);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoSucursalCarga(ManifiestoSucursalCarga m)
        {

            try
            {
                _manifiestos_cargas_sucursales.eliminarManifiestoSucursalCarga(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoSucursalCarga> listarManifiestosSucursalCargasPorCodigo(string c)
        {
            try
            {
               return  _manifiestos_cargas_sucursales.listarManifiestosSucursalesCargasPorCodigo(c);
                    }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>oo
        /// Obtener una lista de los manifiestos de cargas de Sucursales que corresponden a un determinado colaborador.
        /// </summary>
        /// <param name="colaborador">Colaborador responsable de los manifiestos que se listarán</param>
        /// <param name="fecha">fecha de ingreso de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoSucursalCarga> listarManifiestosSucursalporColaborador(DateTime fecha, Colaborador colaborador)
        {
            try
            {
                return _manifiestos_cargas_sucursales.listarManifiestosSucursalesCargasPorColaborador(fecha, colaborador);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Manifiestos de Cargas de Sucursales

        #region Manifiestos de Cargas de Bancos




        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un Banco.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del nuevo manifiesto</param>
        public void agregarManifiestoBancoPedido(ref ManifiestoPedidoBanco m)
        {

            try
            {
                //if (_manifiestos_cargas_banco.verificarManifiestoBancoPedido(ref m))
                //    throw new Excepcion("ErrorManifiestoSucursalCargaDuplicado");

                _manifiestos_cargas_banco.agregarManifiestoBancoPedido(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un BAnco
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBancoPedido(ManifiestoPedidoBanco m)
        {

            try
            {
                //if (_manifiestos_cargas_banco.verificarManifiestoBancoPedido(ref m))
                //    throw new Excepcion("ErrorManifiestoSucursalCargaDuplicado");

                _manifiestos_cargas_banco.actualizarManifiestoBancoPedido(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoPedidoBanco(ManifiestoPedidoBanco m)
        {

            try
            {
                _manifiestos_cargas_banco.eliminarManifiestoBancoPedido(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoPedidoBanco> listarManifiestosBancosPedidosPorCodigo(string c)
        {

            try
            {
                return _manifiestos_cargas_banco.listarManifiestosBancoPedidoPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualiza los datos de los montos de una determinada tula
        /// </summary>
        /// <param name="b">Objeto BolsaMontoPedidoBanco con los datos del monto a modificar</param>
        public void actualizarMontoTulasBamcps(BolsaMontoPedidoBanco b)
        {
            try
            {
                _montos_bolsas_bancos.actualizarBolsaMontosBancos(ref b);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un BAnco
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBancoPedidoCarga(ref PedidoBancos pedido)
        {

            try
            {
                foreach (ManifiestoPedidoBanco m in pedido.Manifiesto)
                {
                    ManifiestoPedidoBanco copia = m;
                    m.Pedido = pedido;


                    ManifiestoPedidoBanco copia_g = new ManifiestoPedidoBanco(id:m.ID);

                    copia_g.Serie_Tula = new BindingList<BolsaBanco>();
                    _bolsa.listarBolsasBancoPorManifiesto(ref copia_g);


                    _manifiestos_cargas_banco.actualizarManifiestoBancoPedidoPedido(ref copia);


                    


                    foreach (BolsaBanco bolsa in copia.Serie_Tula)
                    {

                        BolsaBanco copia_tula = bolsa;
                        copia_tula.Manifiesto = copia;

                        if (copia_g.Serie_Tula.Contains(copia_tula))
                            this.actualizarbolsabanco(ref copia_tula);
                        else
                            this.agregarbolsabancocarga(ref copia_tula);
                    }

                    foreach (BolsaBanco bolsa in copia.Serie_Tula)
                    {

                        BolsaBanco copia_tula = bolsa;
                        copia_tula.Manifiesto = copia;

                        BolsaBanco copia_borrar = new BolsaBanco(id: copia_tula.ID);
                        _montos_bolsas_bancos.obtenerBolsaMontoBancos(ref copia_borrar);



                        foreach (BolsaMontoPedidoBanco monto in bolsa.Cartuchos)
                        {
                            BolsaMontoPedidoBanco copia_cartucho = monto;

                            copia_cartucho.ID_Bolsa = copia_tula.ID;

                            if (copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada > 0)
                                _montos_bolsas_bancos.actualizarBolsaMontosBancos(ref copia_cartucho);

                            if (copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada == 0)
                                _montos_bolsas_bancos.eliminarBolsaMontoBanco(copia_cartucho);

                            if (copia_cartucho.ID == 0)
                                _montos_bolsas_bancos.agregarBolsaMontosBancos(ref copia_cartucho);


                        }
                    }
                    //foreach (BolsaBanco bol in copia_g.Serie_Tula)
                    //{
                    //    BolsaBanco bolsita = bol;
                    //    _bolsa.actualizarBolsaBanco(ref bolsita);
                    //}

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Manifiestos de Cargas de Bancos

        #region Manifiestos de Cargas de Sucursales

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del nuevo manifiesto</param>
        public void agregarManifiestoPedidoNiquel(ref ManifiestoNiquelPedido m)
        {

            try
            {
                if (_manifiestos_niquel.verificarManifiestoPedidoNiquel(ref m))
                    throw new Excepcion("ErrorManifiestoSucursalCargaDuplicado");

                _manifiestos_niquel.agregarManifiestoPedidoNiquel(ref m);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un BAnco
        /// </summary>
        /// <param name="m">Objeto PedidoNiquel con los datos del manifiesto a actualizar</param>
        public void  actualizarManifiestoPedidoNiquel(ref PedidoNiquel pedido)
        {

            try
            {
                foreach (ManifiestoNiquelPedido m in pedido.Manifiesto)
                {
                    ManifiestoNiquelPedido copia = m;
                    m.Pedido = pedido;
                   


                    ManifiestoNiquelPedido copia_g = new ManifiestoNiquelPedido(id: m.ID);

                    copia_g.ListaBolsas = new BindingList<BolsaNiquel>();
                    _bolsa.listarBolsasNiquelPorManifiesto(ref copia_g);


                    _manifiestos_niquel.actualizarManifiestoPedidoNiquel(ref copia);

                    foreach (BolsaNiquel bols in copia.ListaBolsas)
                    {
                        BolsaNiquel copia_tula = bols;
                        copia_tula.IDCargaSucursal = pedido.ID;
                        copia_tula.Manifiesto = copia;

                        if (copia_g.ListaBolsas.Contains(copia_tula)) { }
                            //copia_g.quitarBolsa(copia_tula);}
                        else
                            this.agregarbolsaniquel(ref copia_tula);
                    }

                    foreach (BolsaNiquel bolsa in copia.ListaBolsas)
                    {

                        BolsaNiquel copia_tula = bolsa;
                        copia_tula.Manifiesto = copia;

                        BolsaNiquel copia_borrar = new BolsaNiquel(id: copia_tula.ID);
                        _montos_bolsas_niquel.obtenerBolsaMontoNiquel(ref copia_borrar);
                             


                        foreach (BolsaMontoPedidoNiquel monto in bolsa.Cartuchos)
                        {
                            BolsaMontoPedidoNiquel copia_cartucho = monto;

                            copia_cartucho.ID_Bolsa = copia_tula.ID;

                            if (copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada > 0)
                                _montos_bolsas_niquel.actualizarBolsaMontoPedidoNiquel(ref copia_cartucho);

                            if (copia_cartucho.ID != 0 && copia_cartucho.Cantidad_asignada == 0)
                                _montos_bolsas_niquel.eliminarBolsaMontoNiquel(copia_cartucho);

                            if (copia_cartucho.ID == 0)
                                _montos_bolsas_niquel.agregarBolsaMontoPedidoNiquel(ref copia_cartucho);


                        }
                    }

                    foreach (BolsaCompletaNiquel b in copia.BolsasCompletas)
                    {
                        BolsaCompletaNiquel copia_cartucho = b;
                        copia_cartucho.Manifiesto = copia;

                       // copia_cartucho.ID_Bolsa = copia_tula.ID;

                        if (copia_cartucho.ID != 0 && copia_cartucho.CantidadBolsas > 0)
                            _bolsa_completa_niquel.actualizarBolsaCompletaNiquel(ref copia_cartucho);

                        if (copia_cartucho.ID != 0 && copia_cartucho.CantidadBolsas == 0)
                            _bolsa_completa_niquel.eliminarBolsaMontoNiquel(copia_cartucho);

                        if (copia_cartucho.ID == 0)
                            _bolsa_completa_niquel.agregarBolsaCompletaNiquel(ref copia_cartucho);
                    }


                    //foreach (BolsaBanco bol in copia_g.Serie_Tula)
                    //{
                    //    BolsaBanco bolsita = bol;
                    //    _bolsa.actualizarBolsaBanco(ref bolsita);
                    //}


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Permite actualizar una bolsa de niquel
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula</param>
        public void actualizarBolsaNiquel(ref BolsaNiquel b)
        {
            try
            {
                _bolsa.actualizarBolsaNiquel(ref b);
            }
            catch(Excepcion ex)
            {
                throw ex;
            }
            
        }


        /// <summary>
        /// Actualiza los datos de los montos de una determinada tula
        /// </summary>
        /// <param name="b">Objeto BolsaMontosSucursales con los datos del monto a modificar</param>
        public void actualizarMontoTulasNiquel(BolsaMontoPedidoNiquel b)
        {
            try
            {
                _montos_bolsas_niquel.actualizarBolsaMontoPedidoNiquel(ref b);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoPedidoNiquel(ManifiestoNiquelPedido m)
        {

            try
            {
                _manifiestos_niquel.eliminarManifiestoPedidoNiquel(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoNiquelPedido> listarManifiestosPedidoNiquelPorCodigo(string c)
        {
            try
            {
                return _manifiestos_niquel.listarManifiestosPedidoNiquelPorCodigo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>oo
        /// Obtener una lista de los manifiestos de cargas de Sucursales que corresponden a un determinado colaborador.
        /// </summary>
        /// <param name="colaborador">Colaborador responsable de los manifiestos que se listarán</param>
        /// <param name="fecha">fecha de ingreso de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoNiquelPedido> listarManifiestosNiquelporColaborador(DateTime fecha, Colaborador colaborador)
        {
            try
            {
                return _manifiestos_niquel.listarManifiestosPedidoNiquelPorColaborador(fecha, colaborador);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Manifiestos de Cargas de Sucursales

        #region Asignacion de Equipos



        /// <summary>
        /// Registrar un nueva asignacion de equipo  en el sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos de la nueva asignacion</param>
        public void agregarAsignacionEquipo(ref Tripulacion c)
        {

            try
            {

                //if (_asignacion_equpo.verificarAsignacionEquipo(ref c))
                //    throw new Excepcion("ErrorAsignacionEquipoDuplicado");

                _asignacion_equpo.agregarAsignacionEquipo(ref c);

                

                foreach (Equipo equipo in c.Asignaciones.ColaboradorAsignado.Equipos)
                {
                    Equipo copia = equipo;

                    _asignacion_equpo.agregarEquipoAsignacionEquipo(ref copia, c);
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualizar los datos de un AsignacionEquipo en el sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos del AsignacionEquipo</param>
        public void actualizarAsignacionEquipo(Tripulacion c)
        {

            try
            {

                //if (_asignacion_equpo.verificarAsignacionEquipo(ref c))
                //    throw new Excepcion("ErrorAsignacionEquipoDuplicado");

                _asignacion_equpo.actualizarAsignacionEquipo(c);

              
                Tripulacion  anterior = new Tripulacion(id:c.ID);
                anterior.Asignaciones = new AsignacionEquipo();
                anterior.Asignaciones.ID = c.Asignaciones.ID;
                //anterior.Asignaciones.ColaboradorAsignado = c.Asignaciones.ColaboradorAsignado;

                Colaborador asignado = new Colaborador();

                asignado.ID = c.Asignaciones.ColaboradorAsignado.ID;

                

                _tripulaciones.listarEquiposColaborador(ref asignado, anterior.Asignaciones.ID);

                anterior.Asignaciones.ColaboradorAsignado = asignado;

               // _asignacion_equpo.obtenerEquiposAsignacionEquipo(ref anterior);

                foreach (Equipo asignacion in c.Asignaciones.ColaboradorAsignado.Equipos)
                {

                    if (anterior.Asignaciones.Equipos.Contains(asignacion))
                    {
                        anterior.Asignaciones.ColaboradorAsignado.quitarEquipo(asignacion);
                    }
                    else
                    {
                        Equipo copia = asignacion;

                        _asignacion_equpo.agregarEquipoAsignacionEquipo(ref copia, c);
                    }

                }

                foreach (Equipo equipo in anterior.Asignaciones.ColaboradorAsignado.Equipos)
                    _asignacion_equpo.eliminarEquipoAsignacionEquipo(equipo);

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como inactivo a un AsignacionEquipo del sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos del AsignacionEquipo a marcar</param>
        public void eliminarAsignacionEquipo(AsignacionEquipo c)
        {

            try
            {
                _asignacion_equpo.eliminarAsignacionEquipo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar a los clientes del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los clientes a listar</param>
        /// <returns>Lista de los cliente registrados en el sistema</returns>
        public BindingList<AsignacionEquipo> listarAsignacionEquipo(string n)
        {

            try
            {
                BindingList<AsignacionEquipo> asignaciones = _asignacion_equpo.listarAsignacionEquipos(n);

                foreach (AsignacionEquipo cliente in asignaciones)
                {
                    AsignacionEquipo copia_cliente = cliente;

                    _asignacion_equpo.obtenerEquiposAsignacionEquipo(ref copia_cliente);
                }

                return asignaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        #endregion Asignacion de Equipos

        #region BolsasBanco


        /// <summary>
        /// Agrega una bolsa de un banco
        /// </summary>
        /// <param name="b">Objeto BolsaBanco con los datos de la bolsa de un banco</param>
        public void agregarbolsabancocarga(ref BolsaBanco b)
        {
            try
            {
                if (!_bolsa.verificarBolsaBanco(ref b))
                {
                    _bolsa.agregarBolsaBanco(ref b);
                }
                else
                    Mensaje.mostrarMensaje("MensajeTulayafueingresada");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public void actualizarbolsabanco(ref BolsaBanco b)
        {

            try
            {
                _bolsa.actualizarBolsaBanco(ref b);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar todos las bolsas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las bolsas</param>
        /// <returns>Lista de bolsas registrados para el manifiesto indicado</returns>
        public void listarBolsasBancoPorManifiesto(ref ManifiestoPedidoBanco m)
        {
            try
            {
                _bolsa.listarBolsasBancoPorManifiesto(ref m);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///Verifica si existe una bolsa asociada a un manifiesto.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a buscar</param>

        public bool verificarBolsaBanco(ref BolsaBanco b)
        {

            try
            {
                return _bolsa.verificarBolsaBanco(ref b);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar una bolsa ya registrada en el sistema y el manifiesto al que esta asociada la misma.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>
        /// <returns>Valor booleano que indica si el manifiesto también fue eliminado</returns>


        public bool eliminarBolsaBanco(BolsaBanco b)
        {
            try
            {
                _bolsa.eliminarBolsaBanco(b);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }





        #endregion BolsasBanco

        #region Bolsas Niquel
        
        /// <summary>
        /// Agrega una bolsa de Niquel
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la bolsa</param>
        public void agregarbolsaPedidoNiquel(ref BolsaNiquel b)
        {
            try
            {
                if (!_bolsa.verificarBolsaNiquel(ref b))
                {
                    _bolsa.agregarBolsaNiquel(ref b);
                }
                else
                    Mensaje.mostrarMensaje("MensajeTulayafueingresada");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarbolsaNiquel(ref BolsaNiquel b)
        {
            bool salida = false;

            try
            {
                ManifiestoNiquelPedido manifiesto = (ManifiestoNiquelPedido)b.Manifiesto;

                salida = !_manifiestos_niquel.verificarManifiestoPedidoNiquel(ref manifiesto);

                if (salida)
                { _bolsa.agregarBolsaNiquel(ref b); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }



        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public bool agregarbolsaNiquelDos(ref BolsaNiquel b)
        {
            bool salida = false;

            try
            {
                ManifiestoNiquelPedido manifiesto = (ManifiestoNiquelPedido)b.Manifiesto;

                salida = !_manifiestos_niquel.verificarManifiestoPedidoNiquel(ref manifiesto);

                if (salida)
                { _bolsa.agregarBolsaNiquel(ref b); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida;
        }

        /// <summary>
        /// Listar todos las bolsas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las bolsas</param>
        /// <returns>Lista de bolsas registrados para el manifiesto indicado</returns>
        public BindingList<BolsaNiquel> listarBolsasNiquelPorManifiesto(ManifiestoNiquelPedido m)
        {
            try
            {
                return _bolsa.listarBolsasNiquelPorManifiesto(ref m);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///Verifica si existe una bolsa asociada a un manifiesto.
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la tula a buscar</param>

        public bool verificarBolsaNiquel(ref BolsaNiquel b)
        {

            try
            {
                return _bolsa.verificarBolsaNiquel(ref b);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar una bolsa ya registrada en el sistema y el manifiesto al que esta asociada la misma.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>
        /// <returns>Valor booleano que indica si el manifiesto también fue eliminado</returns>


        public bool eliminarBolsaNiquel(BolsaNiquel b)
        {
            try
            {
                _bolsa.eliminarBolsaNiquel(b);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }



        /// <summary>
        /// Registrar una bolsa y su respectivo manifiesto en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a registrar</param>
        /// <returns>Valor que indica si el manifiesto fue registrado</returns>
        public void actualizarbolsaNiquel(ref BolsaNiquel b)
        {

            try
            {
                //_bolsa.actualizarBolsaSucursal(ref b);

                BolsaNiquel copia_bolsa = new BolsaNiquel(id: b.ID);
                _montos_bolsas_niquel.obtenerBolsaMontoNiquel(ref copia_bolsa);

                foreach (BolsaMontoPedidoNiquel bol in copia_bolsa.Cartuchos)
                    _montos_bolsas_niquel.eliminarBolsaMontoNiquel(bol);

                foreach (BolsaMontoPedidoNiquel bol in b.Cartuchos)
                {
                    BolsaMontoPedidoNiquel copia = bol;
                    copia.ID_Bolsa = b.ID;
                    _montos_bolsas_niquel.agregarBolsaMontoPedidoNiquel(ref copia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Bolsas
        
        #region ChequesProcesados

        /// <summary>
        /// Registrar un nuevo ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados</param>
        public void agregarChequesProcesados(ref ChequesProcesados d)
        {

            try
            {

                _cheques_procesados.agregarChequesProcesados(ref d);

                foreach(CorteCheque corte in d.Cheques)
                {
                    CorteCheque copiacorte = corte; 
                    _cheques_procesados.agregarCorteCheque(ref copiacorte, d);

                    foreach(Cheque ch in copiacorte.Cheques)
                    {
                        Cheque copiacheque = ch; 
                        _cheques_procesados.agregarCheque(ref copiacheque, copiacorte);
                    }
                }


                foreach(Cheque c in d.ChequesRechazados)
                {
                    Cheque copiacheque = c;
                    _cheques_procesados.agregarChequeRechazo(ref copiacheque, d);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados a actualizar</param>
        public void actualizarChequesProcesados(ChequesProcesados d)
        {

            try
            {

                _cheques_procesados.actualizarChequesProcesados(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Eliminar los datos de un ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados a eliminar</param>
        public void eliminarChequesProcesados(ChequesProcesados d)
        {

            try
            {
                _cheques_procesados.eliminarChequesProcesados(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los ChequesProcesadoss que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los ChequesProcesadoss que se listarán</param>
        /// <returns>Lista de ChequesProcesadoss que cumplen con el criterio de búsqueda</returns>
        public BindingList<ChequesProcesados> listarChequesProcesadoss(DateTime fecha, DateTime fecha_fin, Colaborador oficial, Colaborador digitador)
        {

            try
            {
                BindingList<ChequesProcesados> _lista = _cheques_procesados.listarChequesProcesadossPorReferencia(fecha, fecha_fin, oficial, digitador);

                foreach(ChequesProcesados c in _lista)
                {
                    ChequesProcesados copiachep = c; 

                    _cheques_procesados.listarCortesCheque(ref copiachep);
                    _cheques_procesados.listarChequeRechazo(ref copiachep);

                    foreach(CorteCheque corte in copiachep.Cheques)
                    {
                        CorteCheque copiacorte = corte;

                        _cheques_procesados.listarCheque(ref copiacorte);
                    }


                }
                return _lista;//_cheques_procesados.listarChequesProcesadossPorReferencia(fecha, fecha_fin, oficial, digitador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion ChequesProcesados

        #region BoletaNiqueMesa

        public bool verificarcodigoentrega(String CodigoEntrega)
        {
            try
            {
                int conteocodigo = _cajero_niquel.ObtenerverificacionCodigoBoletaNiquelEnMesa(CodigoEntrega);

                if (conteocodigo == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool cancelarcodigoentrega(String CodigoEntrega)
        {
            try
            {
                int conteocodigo = _cajero_niquel.DeleteCodigoBoletaNiquelEnMesa(CodigoEntrega);

                if (conteocodigo == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<BoletaMesaNiquel> ObtenerInfoFormularioBoletaNiquelMesa(Colaborador colaborador)
        {
            try
            {

                BindingList<BoletaMesaNiquel> boleta = _cajero_niquel.ObtenerInfoBoletaNiquelEnMesa(ref colaborador);
                return boleta;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ObtenerInfoFormularioInconsistenciasManifiesto(Colaborador colaborador)
        {
            try
            {

                DataTable formulario = _cajero_niquel.ObtenerInfoFormularioInconsistenciasManifiesto(ref colaborador);
                return formulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CerrarInfoFormularioInconsistenciasManifiesto(DataTable data)
        {
            try
            {

                int resultado = _cajero_niquel.CerrarInfoFormularioInconsistenciasManifiesto(data);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion BoletaNiqueMesa

        #region ProcesamientoNiquel

        public int registrarProcesamientoNiquel(ref ProcesamientoNiquel proceso)
        {
            return _procesamientoNiquel.agregarRegistroProcesamientoNiquel(ref proceso);
        }

        public int registrarConteoNiquel(ref ConteoNiquel conteo)
        {
            return _procesamientoNiquel.agregarInfoConteoNiquel(ref conteo);
        }

        public DataTable BusquedaInformacionNiquel(byte tipoprocesamiento, string identificador)
        {
            return _procesamientoNiquel.listarDatosVerificacionNiquel(tipoprocesamiento, identificador);
        }

        #endregion ProcesamientoNiquel

        #region PROA

        public string PROABorrarManifiesto(String codigo, int idcolaborador) //Cambio GZH 13092017
        {
            try
            {

                return _manifiestos.PROABorrarManifiesto(codigo, idcolaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void PROAReaperturarManifiesto(String codigo)
        {
            try
            {

                _manifiestos.PROAReaperturarManifiesto(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool VerificarManifiestoProcesado(String codigo)
        {
            try
            {

                return _manifiestos.verificarManifiestoProcesado(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool VerificarManifiestoReabierto(String codigo)
        {
            try
            {

                return _manifiestos.verificarManifiestoReabierto(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion PROA
        #endregion Métodos Públicos



        public object agregarbolsasucursal(BindingList<Bolsa> bolsas)
        {
            throw new NotImplementedException();
        }

 
    }

}

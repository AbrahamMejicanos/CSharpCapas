using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DataBase
{
    public class ClsDataBase
    {

        #region Variables privadas

        private SqlConnection _objSqlConnection;
        private SqlDataAdapter _objSqlDataAdapter;
        private SqlCommand _objSqlCommand;
        private DataSet _dsResultados;
        private DataTable _dtParametros;
        private string _nombreTabla, _nombreSP, _mensajeErrorDB, _valorScalar, _nombreDB;
        private bool _scalar;

        #endregion

        #region Variables publicas

        public SqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        public SqlDataAdapter ObjSqlDataAdapter { get => _objSqlDataAdapter; set => _objSqlDataAdapter = value; }
        public SqlCommand ObjSqlCommand { get => _objSqlCommand; set => _objSqlCommand = value; }
        public DataSet DsResultados { get => _dsResultados; set => _dsResultados = value; }
        public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorDB { get => _mensajeErrorDB; set => _mensajeErrorDB = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }

        #endregion

        #region Constructores

        public ClsDataBase() {
            DtParametros = new DataTable("SpParametros");
            DtParametros.Columns.Add("Nombre");
            DtParametros.Columns.Add("TipoDato");
            DtParametros.Columns.Add("Valor");

            NombreDB = "DB_BasePruebas";
        }

        #endregion

        #region Metodos privados
        private void CrearConexionBaseDatos(ref ClsDataBase objDataBase) {
            switch (objDataBase.NombreDB) {
                case "DB_BasePruebas":

                    objDataBase.ObjSqlConnection = new SqlConnection(Properties.Settings.Default.cadenaConexion_DB_BasePruebas);
                    
                    break;
                default:
                    break;
            }
        }

        private void ValidarConexionBaseDatos(ref ClsDataBase objDataBase) {

            if (objDataBase.ObjSqlConnection.State == ConnectionState.Closed){
                
                objDataBase.ObjSqlConnection.Open();

            }
            else{

                objDataBase.ObjSqlConnection.Close();
                objDataBase.ObjSqlConnection.Dispose();

            }

        }

        private void AgregarParametros(ref ClsDataBase objDataBase) {

            if (objDataBase.DtParametros != null) {

                SqlDbType tipoDatoSQL = new SqlDbType();

                foreach (DataRow i in objDataBase.DtParametros.Rows) {

                    switch (i[1]) {

                        case "1":
                            tipoDatoSQL = SqlDbType.Bit;
                            break;
                        case "2":
                            tipoDatoSQL = SqlDbType.TinyInt;
                            break;
                        case "3":
                            tipoDatoSQL = SqlDbType.SmallInt;
                            break;
                        case "4":
                            tipoDatoSQL = SqlDbType.Int;
                            break;
                        case "5":
                            tipoDatoSQL = SqlDbType.BigInt;
                            break;
                        case "6":
                            tipoDatoSQL = SqlDbType.Decimal;
                            break;
                        case "7":
                            tipoDatoSQL = SqlDbType.SmallMoney;
                            break;
                        case "8":
                            tipoDatoSQL = SqlDbType.Money;
                            break;
                        case "9":
                            tipoDatoSQL = SqlDbType.Float;
                            break;
                        case "10":
                            tipoDatoSQL = SqlDbType.Real;
                            break;
                        case "11":
                            tipoDatoSQL = SqlDbType.Date;
                            break;
                        case "12":
                            tipoDatoSQL = SqlDbType.Time;
                            break;
                        case "13":
                            tipoDatoSQL = SqlDbType.SmallDateTime;
                            break;
                        case "14":
                            tipoDatoSQL = SqlDbType.Date;
                            break;
                        case "15":
                            tipoDatoSQL = SqlDbType.Char;
                            break;
                        case "16":
                            tipoDatoSQL = SqlDbType.NChar;
                            break;
                        case "17":
                            tipoDatoSQL = SqlDbType.VarChar;
                            break;
                        case "18":
                            tipoDatoSQL = SqlDbType.NVarChar;
                            break;
                        default:
                            break;
                    
                    }

                    if (objDataBase.Scalar) {

                        if (i[2].ToString().Equals(string.Empty)) {

                            objDataBase.ObjSqlCommand.Parameters.Add(i[0].ToString(), tipoDatoSQL).Value = DBNull.Value;

                        }else {
                            objDataBase.ObjSqlCommand.Parameters.Add(i[0].ToString(), tipoDatoSQL).Value = i[2].ToString();
                        }

                    }else {

                        if (i[2].ToString().Equals(string.Empty)) {

                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(i[0].ToString(), tipoDatoSQL).Value = DBNull.Value;

                        }else {

                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(i[0].ToString(), tipoDatoSQL).Value = i[2].ToString();

                        }

                    }

                }

            }

        }

        private void PrepararConexionBaseDatos(ref ClsDataBase objDataBase) {
            
            CrearConexionBaseDatos(ref objDataBase);
            ValidarConexionBaseDatos(ref objDataBase);

        }

        private void EjecutarDataAdapter(ref ClsDataBase objDataBase) {

            try {
                PrepararConexionBaseDatos(ref objDataBase);

                objDataBase.ObjSqlDataAdapter = new SqlDataAdapter(objDataBase.NombreSP, objDataBase.ObjSqlConnection);

                objDataBase.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                AgregarParametros(ref objDataBase);

                objDataBase.DsResultados = new DataSet();

                objDataBase.ObjSqlDataAdapter.Fill(objDataBase.DsResultados, objDataBase.NombreTabla);
            }
            catch (Exception ex) {
                objDataBase.MensajeErrorDB = ex.Message.ToString();
            }
            finally {
                if (objDataBase.ObjSqlConnection.State == ConnectionState.Closed) {

                    objDataBase.ObjSqlConnection.Open();

                }
                else {

                    objDataBase.ObjSqlConnection.Close();
                    objDataBase.ObjSqlConnection.Dispose();

                }
            }

        }

        private void EjecutarCommand(ref ClsDataBase objDataBase)
        {
            try {

                PrepararConexionBaseDatos(ref objDataBase);
                objDataBase.ObjSqlCommand = new SqlCommand(objDataBase.NombreSP, objDataBase.ObjSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AgregarParametros(ref objDataBase);

                if (objDataBase.Scalar){

                    objDataBase.ValorScalar = objDataBase.ObjSqlCommand.ExecuteScalar().ToString().Trim();

                }
                else {

                    objDataBase.ObjSqlCommand.ExecuteNonQuery();

                }

            } catch (Exception ex) {

                objDataBase.MensajeErrorDB = ex.Message.ToString();
            
            } finally {

                if (objDataBase.ObjSqlConnection.State == ConnectionState.Open) {

                    ValidarConexionBaseDatos(ref objDataBase);
                
                }

            }

        }

        #endregion

        #region Metodos publicos

        public void CRUD(ref ClsDataBase objDataBase) {

            if (objDataBase.Scalar) {

                EjecutarCommand(ref objDataBase);

            }
            else {
                EjecutarDataAdapter(ref objDataBase);
            }
        
        }

        #endregion

    }
}

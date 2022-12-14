using AccesoDatos.DataBase;
using Entidades.Usuario;
using System;
using System.Data;

namespace LogicaNegocio.Usuario
{
    public class ClsUsuarioLn
    {

        #region Variables privadas
        private ClsDataBase objDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUsuario objUsuario)
        {

            objDataBase = new ClsDataBase()
            {

                NombreTabla = "Usuarios",
                NombreSP = "[SCH_GENERAL].[SP_Usuario_Index]",
                Scalar = false,

            };

            Ejecutar(ref objUsuario);

        }
        #endregion

        #region CRUD usuario

        public void Create(ref ClsUsuario objUsuario)
        {

            objDataBase = new ClsDataBase()
            {

                NombreTabla = "Usuarios",
                NombreSP = "[SCH_GENERAL].[SP_Usuario_Create]",
                Scalar = true,

            };

            objDataBase.DtParametros.Rows.Add(@"@NUTUX", "17", objUsuario.NUTUX);
            objDataBase.DtParametros.Rows.Add(@"@PATUX", "17", objUsuario.PATUX);
            objDataBase.DtParametros.Rows.Add(@"@SATUX", "17", objUsuario.SATUX);
            objDataBase.DtParametros.Rows.Add(@"@NTUXX", "17", objUsuario.NTUXX);

            Ejecutar(ref objUsuario);

        }

        public void Read(ref ClsUsuario objUsuario)
        {

            objDataBase = new ClsDataBase()
            {

                NombreTabla = "Usuarios",
                NombreSP = "[SCH_GENERAL].[SP_Usuario_Read]",
                Scalar = false,

            };
            objDataBase.DtParametros.Rows.Add(@"@IDTUX", 2, objUsuario.IDTUX);
            Ejecutar(ref objUsuario);

        }

        public void Update(ref ClsUsuario objUsuario)
        {

            objDataBase = new ClsDataBase()
            {

                NombreTabla = "Usuarios",
                NombreSP = "[SCH_GENERAL].[SP_Usuario_Update]",
                Scalar = true,

            };

            objDataBase.DtParametros.Rows.Add(@"@IDTUX", 2, objUsuario.IDTUX);
            objDataBase.DtParametros.Rows.Add(@"@NUTUX", "17", objUsuario.NUTUX);
            objDataBase.DtParametros.Rows.Add(@"@PATUX", "17", objUsuario.PATUX);
            objDataBase.DtParametros.Rows.Add(@"@SATUX", "17", objUsuario.SATUX);
            objDataBase.DtParametros.Rows.Add(@"@NTUXX", "17", objUsuario.NTUXX);

            Ejecutar(ref objUsuario);

        }

        public void Delete(ref ClsUsuario objUsuario)
        {

            objDataBase = new ClsDataBase()
            {

                NombreTabla = "Usuarios",
                NombreSP = "[SCH_GENERAL].[SP_Usuario_Delete]",
                Scalar = true,

            };
            objDataBase.DtParametros.Rows.Add(@"@IDTUX", 2, objUsuario.IDTUX);
            Ejecutar(ref objUsuario);

        }
        #endregion

        #region Metodos privados
        private void Ejecutar(ref ClsUsuario objUsuario)
        {

            objDataBase.CRUD(ref objDataBase);

            if (objDataBase.MensajeErrorDB == null)
            {

                if (objDataBase.Scalar == true)
                {

                    objUsuario.ValorScalar = objDataBase.ValorScalar;

                }
                else
                {

                    objUsuario.DtResultado = objDataBase.DsResultados.Tables[0];

                    if (objUsuario.DtResultado.Rows.Count == 1)
                    {

                        foreach (DataRow i in objUsuario.DtResultado.Rows)
                        {

                            objUsuario.IDTUX = Convert.ToByte(i["IDTUX"].ToString());
                            objUsuario.NUTUX = i["NUTUX"].ToString();
                            objUsuario.PATUX = i["PATUX"].ToString();
                            objUsuario.SATUX = i["SATUX"].ToString();
                            objUsuario.NTUXX = i["NTUXX"].ToString();

                        }

                    }

                }

            }
            else
            {

                objUsuario.MensajeError = objDataBase.MensajeErrorDB;

            }

        }
        #endregion
    }
}

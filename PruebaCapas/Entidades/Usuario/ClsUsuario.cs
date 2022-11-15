using System;
using System.Data;

namespace Entidades.Usuario
{
    public class ClsUsuario
    {

        #region Atributos privados
        private byte _IDTUX;
        private string _NUTUX, _PATUX, _SATUX;
        private DateTime _FNTUX;
        private bool _ETUXX;
        private string _NTUXX;

        //atributos de manejo de la base de datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultado;

        #endregion

        #region Atributos publicos
        public byte IDTUX { get => _IDTUX; set => _IDTUX = value; }
        public string NUTUX { get => _NUTUX; set => _NUTUX = value; }
        public string PATUX { get => _PATUX; set => _PATUX = value; }
        public string SATUX { get => _SATUX; set => _SATUX = value; }
        public DateTime FNTUX { get => _FNTUX; set => _FNTUX = value; }
        public bool ETUXX { get => _ETUXX; set => _ETUXX = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultado { get => _dtResultado; set => _dtResultado = value; }
        public string NTUXX { get => _NTUXX; set => _NTUXX = value; }
        #endregion
    }
}

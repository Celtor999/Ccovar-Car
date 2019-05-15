using Ccovar.DataModel;
using Ccovar.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.Manager
{
    public sealed class ManagerSQL
    {
        private const string SQL_Login = @"SELECT * FROM usuarios WHERE usuario = @usuario AND password = @password";
        private const string SQL_Autos = @"SELECT autos.*,marcas.marca FROM autos JOIN marcas ON marcas.id = autos.id_marca";
        private const string SQL_Marcas = @"SELECT id,marca,nacionalidad FROM marcas";
        private const string SQL_Clientes = @"SELECT * FROM clientes";
        private const string PARM_USUARIO = "@usuario";
        private const string PARM_PASS = "@password";

        private const string PARM_ID = "@id";
        private const string PARM_MARCA = "@marca";
        private const string PARM_NACIONALIDAD = "@nacionalidad";
        private const string SQL_INSERT_MARCA = @"INSERT INTO marcas (marca,nacionalidad) VALUES (@marca,@nacionalidad)";
        private const string SQL_INSERT_AUTOS = @"INSERT INTO autos (id_marca,modelo,año,color,tipo,capacidad,disponibilidad,razon_disponibilidad,fecha_disponibilidad,kilometraje,folio_segro,observaciones,renta_fija,renta_dia) VALUES (@modelo,@año,@color,@tipo,@capacidad,@disponibilidad,@razon_disponibilidad,@fecha_disponibilidad,@kilometraje,@folio_segro,@observaciones,@renta_fija,@renta_dia)";
        private const string SQL_INSERT_CLIENTE = @"INSERT INTO clientes (nombre,apellido_paterno,apellido_materno,calle,numero,colonia,codigo_postal,ciudad,estado,pais,numero_liciencia,nacionalidad,telefono) VALUE (@nombre,@apellido_paterno,@apellido_materno,@calle,@numero,@codigo_postal,@ciudad,@codigo_postal,@ciudad,@estado,@pais,@numero_liciencia,@nacionalidad,@telefono)";
        private const string PARM_NOMBRE = "@nombre";
        private const string PARM_PATERNO = "@paterno";
        private const string PARM_MATERNO = "@materno";
        private const string PARM_CALLE = "@calle";
        private const string PARM_NUMERO = "@numero";
        private const string PARM_COLONIA = "@colonia";
        private const string PARM_CODPOSTAL = "@codigo_postal";
        private const string PARM_CIUDAD = "@ciudad";
        private const string PARM_ESTADO = "@estado";
        private const string PARM_PAIS = "@pais";
        private const string PARM_NUMLIC = "@numero_liciencia";
        private const string PARM_TELEFONO = "@telefono";

        private const string SQL_UPDATE_MARCA = @"UPDATE marcas SET marca = @marca,nacionalidad = @nacionalidad WHERE id = @id";

        public Usuarios Login(String usuario, String password)
        {
            Usuarios usu = new Usuarios();
            SqlParameter[] ConsultaParms = SQLHelper.GetCacheParameters(SQL_Login);
            if (ConsultaParms == null)
            {
                ConsultaParms = new SqlParameter[]
                {
                    new SqlParameter(PARM_USUARIO,DbType.String),
                    new SqlParameter(PARM_PASS, DbType.String)
                };
                SQLHelper.CacheParameters(SQL_Login, ConsultaParms);
            }
            ConsultaParms[0].Value = usuario;
            ConsultaParms[1].Value = password;
            SqlDataReader Reader = SQLHelper.ExecuteReader(null, CommandType.Text, SQL_Login, ConsultaParms);
            string json_string = Program.ToJson(Reader, "Usuarios");
            usu = JsonConvert.DeserializeObject<Usuarios>(json_string);
            Reader.Close();
            return usu;
        }

        public DataModel.Autos ObtenerAutos()
        {
            DataModel.Autos autos = new DataModel.Autos();
            SqlDataReader Reader = SQLHelper.ExecuteReader(null, CommandType.Text, SQL_Autos);
            string json_string = Program.ToJson(Reader, "Autos");
            autos = JsonConvert.DeserializeObject<DataModel.Autos>(json_string);
            Reader.Close();
            return autos;
        }

        public DataModel.Clientes ObtenerClientes()
        {
            DataModel.Clientes clientes = new DataModel.Clientes();
            SqlDataReader Reader = SQLHelper.ExecuteReader(null, CommandType.Text, SQL_Clientes);
            string json_string = Program.ToJson(Reader, "Clientes");
            clientes = JsonConvert.DeserializeObject<DataModel.Clientes>(json_string);
            Reader.Close();
            return clientes;
        }

        public void UpdateMarca(string marca, string nacionalidad,int id)
        {
            try
            {
                SqlParameter[] ConsultaParms = UpdateParametersMarca();
                ConsultaParms[0].Value = marca;
                ConsultaParms[1].Value = nacionalidad;
                ConsultaParms[2].Value = id;
                SQLHelper.ExecuteScalar(null, CommandType.Text, SQL_UPDATE_MARCA, ConsultaParms);
            }
            catch (Exception err)
            {
                string error = err.ToString();
                throw;
            }
        }

        private SqlParameter[] UpdateParametersMarca()
        {
            SqlParameter[] parms = SQLHelper.GetCacheParameters(SQL_UPDATE_MARCA);
            if (parms == null)
            {
                parms = new SqlParameter[]
                {
                    new SqlParameter(PARM_MARCA, DbType.String),
                    new SqlParameter(PARM_NACIONALIDAD, DbType.String),
                    new SqlParameter(PARM_ID,DbType.Int32)
                };
                SQLHelper.CacheParameters(SQL_UPDATE_MARCA, parms);
            }
            return parms;
        }

        public void InsertarMarca(string marca, string nacionalidad)
        {
            try
            {
                SqlParameter[] ConsultaParms = InsertParametersMarca();
                ConsultaParms[0].Value = marca;
                ConsultaParms[1].Value = nacionalidad;
                SQLHelper.ExecuteScalar(null, CommandType.Text, SQL_INSERT_MARCA, ConsultaParms);
            }
            catch (Exception err)
            {
                string error = err.ToString();
                throw;
            }
        }

        private SqlParameter[] InsertParametersMarca()
        {
            SqlParameter[] parms = SQLHelper.GetCacheParameters(SQL_INSERT_MARCA);
            if (parms == null)
            {
                parms = new SqlParameter[]
                {
                    new SqlParameter(PARM_MARCA, DbType.String),
                    new SqlParameter(PARM_NACIONALIDAD, DbType.String),
                };
                SQLHelper.CacheParameters(SQL_INSERT_MARCA, parms);
            }
            return parms;
        }

        public DataModel.Marcas ObtenerMarcas()
        {
            DataModel.Marcas marcas = new DataModel.Marcas();
            SqlDataReader Reader = SQLHelper.ExecuteReader(null, CommandType.Text, SQL_Marcas);
            string json_string = Program.ToJson(Reader, "Marcas");
            marcas = JsonConvert.DeserializeObject<DataModel.Marcas>(json_string);
            Reader.Close();
            return marcas;
        }

        public void InsertarAutos(string id_marca, string modelo,string año,string color,string tipo,string capacidad,string disponibilidad,string razon_disponibilidad,string fecha_disponibilidad,string kilometraje,string folio_segro,string observaciones,string renta_fija,string renta_dia)
        {
            try
            {
                SqlParameter[] ConsultaParms = InsertParametersAutos();
                ConsultaParms[0].Value = id_marca;
                ConsultaParms[1].Value = modelo;
                ConsultaParms[2].Value = año;
                ConsultaParms[3].Value = color;
                ConsultaParms[4].Value = tipo;
                ConsultaParms[5].Value = capacidad;
                ConsultaParms[6].Value = disponibilidad;
                ConsultaParms[7].Value = razon_disponibilidad;
                ConsultaParms[8].Value = fecha_disponibilidad;
                ConsultaParms[9].Value = kilometraje;
                ConsultaParms[10].Value = folio_segro;
                ConsultaParms[11].Value = observaciones;
                ConsultaParms[12].Value = renta_fija;
                ConsultaParms[13].Value = renta_dia;
                SQLHelper.ExecuteScalar(null, CommandType.Text, SQL_INSERT_AUTOS, ConsultaParms);
            }
            catch (Exception err)
            {
                string error = err.ToString();
                throw;
            }
        }

        private SqlParameter[] InsertParametersAutos()
        {
            SqlParameter[] parms = SQLHelper.GetCacheParameters(SQL_INSERT_AUTOS);
            if (parms == null)
            {
                parms = new SqlParameter[]
                {
                    new SqlParameter(PARM_MARCA, DbType.String),
                    new SqlParameter(PARM_NACIONALIDAD, DbType.String),
                };
                SQLHelper.CacheParameters(SQL_INSERT_MARCA, parms);
            }
            return parms;
        }

        public void InsertarCliente(string nombre,string apellido_paterno,string apellido_materno,string calle,string numero,string colonia,string cod_postal,string ciudad,string estado,string pais,string numero_liciencia,string nacionalidad,string telefono)
        {
            try
            {
                SqlParameter[] ConsultaParms = InsertParametersCliente();
                ConsultaParms[0].Value = nombre;
                ConsultaParms[1].Value = apellido_paterno;
                ConsultaParms[2].Value = apellido_materno;
                ConsultaParms[3].Value = calle;
                ConsultaParms[4].Value = numero;
                ConsultaParms[5].Value = colonia;
                ConsultaParms[6].Value = cod_postal;
                ConsultaParms[7].Value = ciudad;
                ConsultaParms[8].Value = estado;
                ConsultaParms[9].Value = pais;
                ConsultaParms[10].Value = numero_liciencia;
                ConsultaParms[11].Value = nacionalidad;
                ConsultaParms[12].Value = telefono;
                SQLHelper.ExecuteScalar(null, CommandType.Text, SQL_INSERT_CLIENTE, ConsultaParms);
            }
            catch (Exception err)
            {
                string error = err.ToString();
                throw;
            }
        }

        private SqlParameter[] InsertParametersCliente()
        {
            SqlParameter[] parms = SQLHelper.GetCacheParameters(SQL_INSERT_CLIENTE);
            if (parms == null)
            {
                parms = new SqlParameter[]
                {
                    new SqlParameter(PARM_NOMBRE, DbType.String),
                    new SqlParameter(PARM_PATERNO, DbType.String),
                    new SqlParameter(PARM_MATERNO, DbType.String),
                    new SqlParameter(PARM_CALLE, DbType.String),
                    new SqlParameter(PARM_NUMERO, DbType.String),
                    new SqlParameter(PARM_COLONIA, DbType.String),
                    new SqlParameter(PARM_CODPOSTAL, DbType.String),
                    new SqlParameter(PARM_CIUDAD, DbType.String),
                    new SqlParameter(PARM_ESTADO, DbType.String),
                    new SqlParameter(PARM_PAIS, DbType.String),
                    new SqlParameter(PARM_NUMLIC, DbType.String),
                    new SqlParameter(PARM_NACIONALIDAD, DbType.String),
                    new SqlParameter(PARM_TELEFONO, DbType.String)
                };
                SQLHelper.CacheParameters(SQL_INSERT_CLIENTE, parms);
            }
            return parms;
        }
    }
}

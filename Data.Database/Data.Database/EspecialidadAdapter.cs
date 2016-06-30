using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter:Adapter
    {
        public List<Especialidad> GetAll() {

            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad es = new Especialidad();
                    es.ID = (int)drEspecialidades["id_especialidad"];
                    es.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(es);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las especialidades",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad es = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                   
                    es.ID = (int)drEspecialidades["id_especialidad"];
                    es.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo conectar a la base de datos",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return es;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se puede eliminar, usuario malintencionado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {

            if (especialidad.State == BusinessEntity.States.New)
            {
                try
                {
                    this.Insert(especialidad);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;

        }

        public void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("update especialidades set desc_especialidad = @descripcion "+
                    "where id_especialidad = @id", SqlConn);
                cmdEspecialidad.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Decimal).Value = esp.ID;
                cmdEspecialidad.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo actualizar la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Especialidad es)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert especialidades (desc_especialidad) values (@descripcion) select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = es.Descripcion;
                es.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo crear nueva especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}

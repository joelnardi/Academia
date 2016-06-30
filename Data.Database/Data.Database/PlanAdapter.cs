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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> pl = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes", SqlConn);
                SqlDataReader drPlanes = cmdPlan.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pla = new Plan();
                    pla.ID = (int)drPlanes["id_plan"];
                    pla.Descripcion = (string)drPlanes["desc_plan"];
                    pla.Especialidad = (new EspecialidadAdapter()).GetOne((int)drPlanes["id_especialidad"]); 
                    pl.Add(pla);
                }
            }
            catch (Exception e)
            {
                Exception ExManejada = new Exception("No se pudo acceder a la base de datos", e);
                throw ExManejada;
            }
            finally
            {
                this.CloseConnection();
                SqlConn = null;
            }
            return pl;
        }
        public Plan GetOne(int ID)
        {
            Plan pl = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes where @id = id_plan", SqlConn);
                cmdPlan.Parameters.Add("id", SqlDbType.Decimal).Value = ID;
                SqlDataReader drPlanes = cmdPlan.ExecuteReader();
                if (drPlanes.Read())
                {
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.Especialidad = (new EspecialidadAdapter()).GetOne((int)drPlanes["id_especialidad"]);

                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo recuperar de la base de datos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
                SqlConn = null;
            }
            return pl;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("delete planes where @id=id_plan", SqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("No se pudo borrar de la base de datos", Ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
                SqlConn = null;
            }
        }
        public void Save(Plan pl)
        {
            if (Business.Entities.BusinessEntity.States.New == pl.State)
            {
                try
                {
                    this.Insert(pl);
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
            else if (BusinessEntity.States.Deleted == pl.State)
            {
                try
                {
                    this.Delete(pl.ID);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else if (BusinessEntity.States.Modified == pl.State)
            {
                try
                {
                    this.Update(pl);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else pl.State = BusinessEntity.States.Unmodified;
        }

    
        public void Update(Plan pl)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("update planes set id_plan = @id, desc_plan = @descripcion, " +
                    "id_especialidad = @id_especialidad", SqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = pl.ID;
                cmdPlan.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = pl.Descripcion;
                cmdPlan.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = pl.Especialidad.ID;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception newException = new Exception("No se pudo actualizar en la base de datos", Ex);
                throw newException;
            }
            finally
            {
                this.CloseConnection();
                SqlConn = null;
            }
        }
        public void Insert(Plan pl)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("insert into planes (desc_plan, id_especialidad) values(@descripcion, @id_esp) select @@identity", SqlConn);
                cmdPlan.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = pl.Descripcion;
                cmdPlan.Parameters.Add("@id_esp", SqlDbType.Decimal).Value =  pl.Especialidad.ID;
                pl.ID = Decimal.ToInt32((decimal)cmdPlan.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ex = new Exception("No se pudo insertar en la base de datos", e);
                throw ex;
            }
            finally
            {
                this.CloseConnection();
                SqlConn = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Negocio
{
    public class EspecialidadLogic : Negocio
    {
        public EspecialidadAdapter EspecialidadData
        {
            get;
            set;
        }

        public EspecialidadLogic() 
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll() 
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception Ex) 
            {
                throw Ex;
            }
        }

        public Especialidad GetOne(int ID)
        {
            try
            {
                return EspecialidadData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
    }
}

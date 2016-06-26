using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Negocio
{
    class PlanLogic : Negocio
    {
        #region Properties
        public PlanAdapter PlanData
        {
            get; set;
        }
        #endregion
        #region Constructores
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        #endregion
        #region Acceso a datos
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                planes = PlanData.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                plan = PlanData.GetOne(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                PlanData.Delete(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Plan pl)
        {
            try
            {
                PlanData.Save(pl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

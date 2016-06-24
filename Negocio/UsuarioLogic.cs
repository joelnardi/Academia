using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Negocio
{
    public class UsuarioLogic : Negocio
    {


        public UsuarioAdapter UsuarioData
        {
            get;
            set;
        }

        public UsuarioLogic() 
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();

            }
            catch (Exception e) 
            {
                throw e;
            }
        }
        public Usuario GetOne(int id) 
        {
            return UsuarioData.GetOne(id);
        }

        public void Delete(int id) 
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usr)
        {
            UsuarioData.Save(usr);
        }

    }
}

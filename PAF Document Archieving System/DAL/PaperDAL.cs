using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAF.DAS.Service.DAL
{
    public class PaperDAL : IPaperDAL
    {
        private IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public PaperDAL()
        {

        }

        public Paper Add(Paper paper)
        {
            throw new NotImplementedException();
        }

        public Paper Get(Guid ID)
        {
            throw new NotImplementedException();
        }

        public List<Paper> GetAll()
        {
            return Dapper.SimpleCRUD.GetList<Paper>(dbConnection).ToList();
        }

        public Paper Update(Paper modifiedPaper)
        {
            throw new NotImplementedException();
        }
    }
}

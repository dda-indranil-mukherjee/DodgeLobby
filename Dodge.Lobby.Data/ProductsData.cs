using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace Dodge.Lobby.Data
{
    public class ProductsData
    {
        string _connectionString = string.Empty;
        OracleConnection _con;
        OracleCommand _cmd;
        OracleDataAdapter _oda;

        public ProductsData() { }
        public ProductsData(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DataTable GetProducts(int userId)
        {
            try
            {
                DataTable dt = null; ;

                _con = new OracleConnection(_connectionString);
                _cmd = new OracleCommand(@"select lpu.product_abbrv, cou.cou_sys_id
                                              from cou_common_user cou
                                             inner join sac_system_access sac on cou.cou_sys_id = sac.cou_sys_id
                                             inner join lpu_license_prod_user lpu on lpu.user_id = sac.sys_user_name
                                             where lpu.delete_ind = 'N' and cou.cou_sys_id=@id", _con);

                OracleParameter pId = new OracleParameter("@id", OracleType.Number, 15);
                pId.Value = userId;

                _cmd.Parameters.Add(pId);

                _oda = new OracleDataAdapter(_cmd);
                if (_con.State != ConnectionState.Open) _con.Open();
                DataSet ds = new DataSet();
                _oda.Fill(ds);

                if(ds.Tables.Count>0)
                {
                    dt = new DataTable();
                    dt = ds.Tables[0];
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

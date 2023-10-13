using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductServices
    {
        private static string db_source = "priappserver.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Admin@123";
        private static string db_database = "ProductDb";

        private SqlConnection GetConnection()
        {
           var _builder = new  SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProduct()
        {
            SqlConnection con = GetConnection();
            List<Product> products = new List<Product>();
            string query = "select * from Products";
           
            using(SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = Convert.ToString(dr["ProductName"]),
                        Quantity = Convert.ToInt32(dr["quantity"])
                    });
                }
                con.Close();
            }
            return products;
        }
    }
}

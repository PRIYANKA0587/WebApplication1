using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductServices : IProductServices
    {
        private IConfiguration _configuration;
        public string connectionString = string.Empty;
        public ProductServices(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Sqlconnection");


        }


        public List<Product> GetProduct()
        {
            SqlConnection con = new SqlConnection(connectionString);
            List<Product> products = new List<Product>();
            string query = "select * from Products";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
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

using DTO;
using System.Data;

namespace DAL
{
    public class DAL_Product
    {
        DTO_Product p;
        public DAL_Product(string mid, string mname, string series, string storage, float price)
        {
            p = new DTO_Product(mid, mname, series, storage, price);
        }

        public DataTable selectQuery()
        {
            string s = "select * from Product";
            return Connection.selectQuery(s);
        }
    }
}

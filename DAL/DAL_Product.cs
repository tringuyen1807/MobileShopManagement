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

        public void addQuery()
        {
            string query = "insert into Product values ('" + p._MID + "', '" + p._MName + "', '" + p._Series + "', '" + p._Storage + "', " + p._Price + ")";
            Connection.actionQuery(query);
        }

        public void updateQuery()
        {
            string query = "update Product set MobileName = '" + p._MName + "', Series = '" + p._Series + "', Storage = '" + p._Storage + "', Price = " + p._Price + " where MobileID = '" + p._MID + "'";
            Connection.actionQuery(query);
        }

        public void deleteQuery(string mobileID)
        {
            string query = "delete from Product where MobileID = '" + mobileID + "'";
            Connection.actionQuery(query);
        }

        public DataTable selectQuery()
        {
            string s = "select * from Product";
            return Connection.selectQuery(s);
        }
    }
}

using DTO;
using System.Data;

namespace DAL
{
    public class DAL_Customer
    {
        DTO_Customer c;
        public DAL_Customer(string cid, string cname, string gender, string purchased, float bill)
        {
            c = new DTO_Customer(cid, cname, gender, purchased, bill);
        }

        public void addQuery()
        {
            string query = "insert into Customer values ('" + c._CID + "', N'" + c._CName + "', '" + c._Gender + "', '" + c._Purchased + "', " + c._Bill + ")";
            Connection.actionQuery(query);
        }

        public void updateQuery()
        {
            string query = "update Customer set CustomerName = N'" + c._CName + "', Gender = '" + c._Gender + "', PurchasedMobile = '" + c._Purchased + "', Bill = " + c._Bill + " where CustomerID = '" + c._CID + "'";
            Connection.actionQuery(query);
        }

        public void deleteQuery(string customerID)
        {
            string query = "delete from Customer where CustomerID = '" + customerID + "'";
            Connection.actionQuery(query);
        }

        public DataTable selectQuery()
        {
            string s = "select * from Customer";
            return Connection.selectQuery(s);
        }

        public DataTable select1ID(string customerID)
        {
            string query = "select * from Customer where CustomerID = '" + customerID + "'";
            return Connection.selectQuery(query);
        }
    }
}

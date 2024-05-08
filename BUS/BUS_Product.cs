using DAL;
using System.Data;

namespace BUS
{
    public class BUS_Product
    {
        DAL_Product p;
        public BUS_Product(string mid, string mname, string series, string storage, float price)
        {
            p = new DAL_Product(mid, mname, series, storage, price);
        }

        public void addQuery()
        {
            p.addQuery();
        }

        public void updateQuery()
        {
            p.updateQuery();
        }

        public void deleteQuery(string mobileID)
        {
            p.deleteQuery(mobileID);
        }


        public DataTable selectQuery()
        {
            return p.selectQuery();
        }
    }
}
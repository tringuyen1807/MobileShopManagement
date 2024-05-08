using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Customer
    {
        DAL_Customer c;
        public BUS_Customer(string cid, string cname, string gender, string purchased, float bill)
        {
            c = new DAL_Customer(cid, cname, gender, purchased, bill);
        }

        public void addQuery()
        {
            c.addQuery();
        }

        public void updateQuery()
        {
            c.updateQuery();
        }

        public void deleteQuery(string customerID)
        {
            c.deleteQuery(customerID);
        }

        public DataTable selectQuery()
        {
            return c.selectQuery();
        }

        public DataTable select1ID(string selectedID)
        {
            return c.select1ID(selectedID);
        }
    }
}

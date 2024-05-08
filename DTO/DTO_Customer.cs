
namespace DTO
{
    public class DTO_Customer
    {
        private string CID, CName, Gender, Purchased;
        private float Bill;

        public string _CID
        {
            get { return CID; }
            set { CID = value; }
        }

        public string _CName
        {
            get { return CName; }
            set { CName = value; }
        }

        public string _Gender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public string _Purchased
        {
            get { return Purchased; }
            set { Purchased = value; }
        }

        public float _Bill
        {
            get { return Bill; }
            set { Bill = value; }
        }

        public DTO_Customer(string CID, string CName, string Gender, string Purchased, float Bill)
        {
            this.CID = CID;
            this.CName = CName;
            this.Gender = Gender;
            this.Purchased = Purchased;
            this.Bill = Bill;
        }
    }
}

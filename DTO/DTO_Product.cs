namespace DTO
{
    public class DTO_Product
    {
        private string MID, MName, Series, Storage;
        private float Price;

        public string _MID
        {
            get { return MID; }
            set { MID = value; }
        }

        public string _MName
        {
            get { return MName; }
            set { MName = value; }
        }

        public string _Series
        {
            get { return Series; }
            set { Series = value; }
        }

        public string _Storage
        {
            get { return Storage; }
            set { Storage = value; }
        }

        public float _Price
        {
            get { return Price; }
            set { Price = value; }
        }

        public DTO_Product(string MID, string MName, string Series, string Storage, float Price)
        {
            this.MID = MID;
            this.MName = MName;
            this.Series = Series;
            this.Storage = Storage;
            this.Price = Price;
        }
    }
}
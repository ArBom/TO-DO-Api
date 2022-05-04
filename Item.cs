namespace TO_DO_Api
{
    public class Item
    {
        public readonly int Id;

        public DateTime? Expiry { get; set; }

        private string title;
        public string? Title
        {
            get { return title; }
            set
            {
                if (value != null)
                    title = value;
                else
                    title = "Item " + Id.ToString();
            }
        }

        public string? Description { get; set; }

        private ushort percent = 0;

        public ushort Percent
        {
            get { return percent; }
            set
            {
                if (value <= 0)
                    percent = 0;
                else if (value >= 100)
                    percent = 100;
                else
                    percent = (ushort)value;
            }
        }
    }
}
namespace Phone_Seller_AspNetCore6.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int ID
        {
            get; set;
        }

        public int TotalPages => 
            (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
    }
}
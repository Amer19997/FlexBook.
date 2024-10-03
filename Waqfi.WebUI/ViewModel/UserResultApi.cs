namespace WebUI.ViewModel;

public class UserResultApi
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public DateTime registerAt { get; set; }
        public int status { get; set; }
        public List<Role> roles { get; set; }
    }

    public class Name
    {
        public string descriptionAr { get; set; }
        public string descriptionEn { get; set; }
        public string description { get; set; }
    }

    public class Result
    {
        public List<Item> items { get; set; }
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int totalPages { get; set; }
        public bool hasPreviousPage { get; set; }
        public bool hasNextPage { get; set; }
    }

    public class Role
    {
        public Name name { get; set; }
        public bool isAcive { get; set; }
        public DateTime created { get; set; }
        public object createdBy { get; set; }
        public object lastModified { get; set; }
        public object lastModifiedBy { get; set; }
        public Validator validator { get; set; }
        public string id { get; set; }
    }

    public class Root
    {
        public Result result { get; set; }
        public bool success { get; set; }
        public List<object> errors { get; set; }
    }

    public class Validator
    {
    }

}

   //Entities, ViewModel, DTO , Model
   public partial class ResponseData
    {
        public long statusCode { get; set; }
        public string message { get; set; }
        public List<StoreDTO> content { get; set; }
        public DateTimeOffset dateTime { get; set; }
    }

    public partial class StoreDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string latitude { get; set; }
        public string longtitude { get; set; }
        public string description { get; set; }
        public Uri image { get; set; }
        public bool deleted { get; set; }
    }
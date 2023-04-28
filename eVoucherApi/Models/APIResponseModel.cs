namespace eVoucherApi.Models
{
    public class APIResponseModel
    {
        public APIResponseModel() { }

        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public int TotalRecords { get; set; }
        public IDictionary<string, string> ExtendedData { get; set; }
        public APIResponseModel(string message, object data) : this(true, 200, message, data, 0, null)
        {

        }

        public APIResponseModel(bool isSuccess, int statusCode, string message) : this(isSuccess, statusCode, message, null, 0, null)
        {

        }

        public APIResponseModel(bool isSuccess, int statusCode, string message, object data)
        {
            Success = isSuccess;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

        public APIResponseModel(bool isSuccess, int statusCode, string message, object data, int totalRecords, IDictionary<string, string> extendedData)
        {
            Success = isSuccess;
            Message = message;
            StatusCode = statusCode;
            Data = data;
            TotalRecords = totalRecords;
            ExtendedData = extendedData;
        }
    }
}

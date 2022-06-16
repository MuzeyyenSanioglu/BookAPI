using Fleskup.WebApi.Enums;

namespace BookAPI.BLL.APIResponse
{
    public class APIResponse
    {
        
        public bool IsSuccessful { get; set; } 
        public string StatusMessage { get; set; }
        public ApiStatusCode StatusCode { get; set; }

        public void SetFailureStatus(ApiStatusCode apiStatus,string errorMessage ="")
        {
            this.StatusMessage = $"{apiStatus.ToString()} Hata Mesajı : { errorMessage}";
            this.IsSuccessful = false;
            this.StatusCode = apiStatus;
        }
        public void SetSuccessStatus(ApiStatusCode apiStatus = ApiStatusCode.Success)
        {
            this.StatusMessage = apiStatus.ToString();
            this.IsSuccessful = true;
            this.StatusCode = apiStatus;
        }
    }
    public class APIResponse<T> : APIResponse
    {
        public T? Data { get; set; } = default(T);
        public void SetData(T data)
        {
            this.Data = data;
            this.IsSuccessful = true;
            this.StatusCode =ApiStatusCode.Success;
        }
    }
}
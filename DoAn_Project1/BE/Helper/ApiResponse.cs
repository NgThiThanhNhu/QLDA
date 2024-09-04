using Newtonsoft.Json;
namespace BE.Helper
{
  public class ApiResponse
	{
		[JsonProperty("success")]
		public bool Success { get; }

		[JsonProperty("code")]
		public int StatusCode { get; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "message")]
		public string Message { get; }

		public ApiResponse(bool success, int statusCode, string message = null)
		{
			Success = success;
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}

		public string GetDefaultMessageForStatusCode(int statusCode)
		{
			switch (statusCode)
			{
				case 404:
					return "Not Found";
				case 500:
					return "Internal Server Error";
				default:
					return null;
			}
		}
	}
}

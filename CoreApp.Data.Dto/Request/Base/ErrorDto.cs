namespace Common.Dto.Base
{
    public class ErrorDto
    {
        #region property

        public string Code { get; set; }

        public string Message { get; set; }

        #endregion property

        #region contructor

        public ErrorDto(string code)
        {
            this.Message = string.Empty;
            this.Code = code;
        }

        public ErrorDto(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        #endregion contructor
    }
}

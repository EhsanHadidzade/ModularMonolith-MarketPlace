namespace _0_Framework.Utilities
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public long Id { get; set; }
        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult SucceddedWithId(string message = "عملیات با موفقیت انجام شد",long id=0)
        {
            IsSuccedded = true;
            Message = message;
            Id = id;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}

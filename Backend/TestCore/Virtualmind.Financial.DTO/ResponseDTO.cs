using System;
using System.Collections.Generic;

namespace Virtualmind.Financial.DTO
{
    public class ResponseDTO<T>
    {
        private ResponseDTO() { }

        private ResponseDTO(bool succeeded, int code, T result, IEnumerable<string> errors) : base()
        {
            Succeeded = succeeded;
            Code = code;
            Result = result;
            Errors = errors;
        }

        public bool Succeeded { get; set; }

        public int Code { get; set; }

        public T Result { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static ResponseDTO<T> Success(int code, T result)
        {
            return new ResponseDTO<T>(true, code, result, new List<string>());
        }

        public static ResponseDTO<T> Success200(T result)
        {
            return Success(200, result);
        }

        public static ResponseDTO<T> Failure(int code, IEnumerable<string> errors)
        {
            return new ResponseDTO<T>(false, code, default, errors);
        }
    }
}

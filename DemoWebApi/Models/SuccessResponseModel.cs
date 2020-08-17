using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public class SuccessResponseModel : ResponseModel
    {
        public SuccessResponseModel()
        {
            IsSuccess = true;
            Code = 0;
            Message = "";
        }
    }
    public class SuccessResponseModel<T>: SuccessResponseModel
    {
        
        public SuccessResponseModel(T data) 
        {
            Data = data;
        }
        public T Data { get; set; }
    }

   
}
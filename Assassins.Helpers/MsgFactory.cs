using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Assassins.Helpers
{
    public static class MsgFactory
    {
        public static object Info(string text)
        {
            return new
            {
                Type = MessageType.Info,
                Text = text
            };
        }
        public static object Success(string text = null)
        {
            return new
            {
                Type = MessageType.Success,
                Text = text
            };
        }
        public static object Error(Exception ex)
        {

            var Text = "Exception:  " + ex.Message;
            if (ex.InnerException != null)
                Text += Environment.NewLine + "   Inner Exception:  " + ex.InnerException;
            return new
            {
                Type = MessageType.Error,
                Text
            };
        }
        public static object Error(string message)
        {
            return new
            {
                Type = MessageType.Error,
                Text = message
            };
        }
        public static object Error(ModelStateDictionary modelState)
        {
            return new
            {
                Type = MessageType.Error,
                Text = ModelStateHelpers.AggregateErrors(modelState)
            };
        }

    }
    internal enum MessageType
    {
        Info,
        Error,
        Success
    }
}

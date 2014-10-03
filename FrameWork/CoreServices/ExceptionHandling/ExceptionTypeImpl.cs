using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.ExceptionHandling.Handlers;
using Gobbi.CoreServices.ExceptionHandling.Instrumentation;
using Gobbi.CoreServices.Properties;

namespace Gobbi.CoreServices.ExceptionHandling
{
    class ExceptionTypeImpl
    {
        private string name;
        private IExceptionHandler[] handlers;

        private Type exceptionType;
        private PostHandlingAction postHandlingAction;

        public PostHandlingAction PostHandlingAction
        {
            get { return postHandlingAction; }
        }
        public Type ExceptionType
        {
            get { return exceptionType; }
        }

        public string Name
        {
            get { return name; }
        }

        public ExceptionTypeImpl(string name, Type exceptionType, IExceptionHandler[] handlers, PostHandlingAction postHandlingAction)
        {
            this.name = name;
            this.exceptionType = exceptionType;
            this.handlers = handlers;
            this.postHandlingAction = postHandlingAction;

        }

        public bool HandleException(EvaException ex)
        {
            EvaException EvaExceptionToThrow = null;
            foreach (IExceptionHandler iExceptionHandler in this.handlers)
            {
                EvaExceptionToThrow = iExceptionHandler.HandleException(ex);
                InstrumentationProvider.ExceptionHandlerExecuted();

            }

            if (postHandlingAction == PostHandlingAction.ThrowNewException)
            {
                if (EvaExceptionToThrow == null)
                {
                    InstrumentationProvider.ExceptionHandlingErrorOccurredInvalidConfiguration();
                    throw new GobbiTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                        string.Format(Resources.ERROR_EXCEPTIONTYPEIMPL_EXCEPTIONTOTHROWNOTFOUND, this.name)));
                }
                throw EvaExceptionToThrow;
            }
            return this.PostHandlingAction == PostHandlingAction.NotifyRethrow;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.ExceptionHandling.Instrumentation;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling
{
    class ExceptionPolicyImpl
    {
        private string name;
        private ExceptionTypeImpl[] exceptionTypeImpls = null;
     


        public ExceptionPolicyImpl(string name, ExceptionTypeImpl[] exceptionTypeImpls)
        {
            this.name = name;
            this.exceptionTypeImpls = exceptionTypeImpls;
        }

	public string Name
	{
	  get { return this.name;}
	}


        public bool HandleException(EvaException ex)
        {

            foreach (ExceptionTypeImpl exceptionTypeImpl in this.exceptionTypeImpls)
            {
                 if ( ex.GetType() == exceptionTypeImpl.ExceptionType || ex.GetType().IsSubclassOf(exceptionTypeImpl.ExceptionType) )
                 {
                     exceptionTypeImpl.HandleException(ex);
                     InstrumentationProvider.ExceptionHandled();
                     return exceptionTypeImpl.PostHandlingAction == PostHandlingAction.NotifyRethrow;

                 }
            }
            //TODO: Ver como indico el error
                throw new EvaTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                    string.Format(Resources.ERROR_EXCEPTIONPOLICYIMPL_NOTHANDLERDEFINED, this.name,
                                  ex.GetType())));
        }
    }
}

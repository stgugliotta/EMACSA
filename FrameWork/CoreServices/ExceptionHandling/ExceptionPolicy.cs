using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.ExceptionHandling.Configuration;
using Gobbi.CoreServices.ExceptionHandling.Handlers;
using Gobbi.CoreServices.Properties;

namespace Gobbi.CoreServices.ExceptionHandling
{
    ///<summary>
    /// <para> Aplica las políticas a las excepciones.</para>
    /// <remarks> En la configuración se define las políticas predeterminadas para
    /// <see cref="EvaBusinessException"/> y para <see cref="GobbiTechnicalException"/> 
    /// o cualquier otro de excepción que herede de <see cref="EvaException"/>.
    /// </remarks>
    ///</summary>
    public static class ExceptionPolicy
    {
        private static object syncObject = new object();
        static Dictionary<string, ExceptionPolicyImpl> policies = null;
        static ExceptionPolicy()
        {
            lock (syncObject)
            {
                Init();
            }
        }

        private static void Init()
        {
            ExceptionHandlingConfigurationSection ehcs = ExceptionHandlingConfigurationSection.GetInstance();
            if (ehcs != null && policies == null)
                DoInit(ehcs);
        }

        private static void DoInit(ExceptionHandlingConfigurationSection ehcs)
        {
            policies = new Dictionary<string, ExceptionPolicyImpl>();

            foreach (ExceptionPolicyConfiguration epc in ehcs.ExceptionPolicies)
            {
                ExceptionPolicyImpl epi = CreatePolicyImpl(epc);
                policies.Add(epi.Name, epi);
            }
        }

        private static ExceptionPolicyImpl CreatePolicyImpl(ExceptionPolicyConfiguration epc)
        {
            List<ExceptionTypeImpl> exceptionTypeImpls = new List<ExceptionTypeImpl>();
                            foreach(ExceptionTypeConfiguration etc in epc.ExceptionTypes)
                {
                    ExceptionTypeImpl eti = CreateTypeImpl(etc);
                    exceptionTypeImpls.Add(eti);
                }
            return new ExceptionPolicyImpl(epc.Name, exceptionTypeImpls.ToArray());
        }

        private static ExceptionTypeImpl CreateTypeImpl(ExceptionTypeConfiguration etc)
        {
            List<IExceptionHandler> iExceptionHandlers = new List<IExceptionHandler>();
            foreach (ExceptionHandlerConfiguration ehc in etc.ExceptionHandlers)
            {
                IExceptionHandler iExceptionHandler =
                    (IExceptionHandler) ConfigurableObjectFactory.Create(ehc.Type, ehc);
                iExceptionHandlers.Add(iExceptionHandler);
            }
            return new ExceptionTypeImpl(etc.Name, etc.Type, iExceptionHandlers.ToArray(), etc.PostHandlingAction);
    }

        ///<summary>
        /// <para>Aplica la política indicada a la <see cref="EvaException"/> dada. </para>
        ///</summary>
        ///<param name="exceptionToHandle">
        /// <para> La <see cref="EvaException"/> a manejar.</para>
        /// </param>
        ///<param name="policyName">
        /// <para> El nombre de la política a implementar.
        /// Debe estar definida en la configuración.</para>
        /// </param>
        ///<returns>
        /// <para> True si debe hacer throw de la excepción actual.</para>
        /// </returns>
        public static bool HandleException(EvaException exceptionToHandle, string policyName)
        {
            if (policies == null || policies.Count == 0)
                throw new GobbiTechnicalException ("", new  ConfigurationErrorsException(Resources.ERROR_EXCEPTIONPOLICY_NOTPOLICIESDEFINED));
            ExceptionPolicyImpl epi;
            try
            {
                 epi = policies[policyName];
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(string.Format(Resources.ERROR_EXCEPTIONPOLICY_POLICYNOTFOUND, policyName), ex);
            }
  
            return epi.HandleException(exceptionToHandle);
        }

        
        ///<summary>
        /// <para>Aplica la política predeterminada a la <see cref="EvaException"/> dada. </para>
        ///</summary>
        ///<param name="exceptionToHandle">
        /// <para> La <see cref="EvaException"/> a manejar.</para>
        /// </param>
        ///<returns>
        /// <para> True si debe hacer throw de la excepción actual.</para>
        /// </returns>
        public static bool HandleException(EvaException exceptionToHandle)
        {
            ExceptionHandlingConfigurationSection ehcs = ExceptionHandlingConfigurationSection.GetInstance();
            if (ehcs == null)
                throw new GobbiTechnicalException ("", new  ConfigurationErrorsException(
                    string.Format(Resources.ERROR_EXCEPTIONPOLICY_CONFIGURATIONNOTFOUND,
                                  Constants.ExceptionHandlingConfigurationSectionName)));
            return HandleException(exceptionToHandle, ehcs.DefaultPolicy);
        }
    }
}

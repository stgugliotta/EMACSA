using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management.Instrumentation;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ar.com.telecom.eva.CoreServices.Security.Principal;
using ar.com.telecom.eva.CoreServices.Context;

namespace ar.com.telecom.eva.CoreServices.Logging
{
    ///<summary>
    /// <para> Representa un mensaje de log. Contiene las propiedades.
    /// Contiene propiedades comunes para todos los mensajes. </para>
    ///</summary>
    [Serializable]
    [XmlRoot("LogEntry")]
    public class LogEntry
    {
        private string message = string.Empty;
        private string title = string.Empty;
        private List<string> categories = new List<string>(0);
        private int priority = -1;
        private int eventId = 0;
        private Guid activityId;
        private Guid? relatedActivityId;
        private TraceEventType severity = TraceEventType.Information;

        private StringBuilder errorMessages;
        private SerializableDictionary<string, object> extendedProperties;

        private string machineName = string.Empty;
        private DateTime timeStamp = DateTime.MaxValue;

        private string appDomainName;
        private string processId;
        private string processName;
        private string threadName;
        private string win32ThreadId;
        private string userName;
        private string surName;
        private string givenName;

        /// <summary>
        /// <para> Iniciailiza una nueva instancia de la clase <see cref="LogEntry"/>. </para>
        /// </summary>
        public LogEntry()
        {
            CollectIntrinsicProperties();
        }

        private static Guid GetActivityId()
        {
            return Trace.CorrelationManager.ActivityId;
        }

        private static string GetCurrentProcessId()
        {
            return NativeMethods.GetCurrentProcessId().ToString(NumberFormatInfo.InvariantInfo);
        }

        private static string GetCurrentThreadId()
        {
            return NativeMethods.GetCurrentThreadId().ToString(NumberFormatInfo.InvariantInfo);
        }

        /// <summary>
        /// Configura las propiedades intrínsicas.
        /// </summary>
        private void CollectIntrinsicProperties()
        {
            this.TimeStamp = DateTime.UtcNow;

            if (Tracer.IsTracingAvailable())
            {
                try
                {
                    this.ActivityId = GetActivityId();
                }
                catch (Exception)
                {
                    this.ActivityId = Guid.Empty;
                }
            }
            else
            {
                this.ActivityId = Guid.Empty;
            }

            // do not try to avoid the security exception, as it would only duplicate the stack walk
            try
            {
                MachineName = Environment.MachineName;
            }
            catch (Exception e)
            {
                this.MachineName = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
            }

            try
            {
                appDomainName = AppDomain.CurrentDomain.FriendlyName;
            }
            catch (Exception e)
            {
                appDomainName = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
            }

            // check whether the unmanaged code permission is available to avoid three potential stack walks
            bool unmanagedCodePermissionAvailable = false;
            SecurityPermission unmanagedCodePermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            // avoid a stack walk by checking for the permission on the current assembly. this is safe because there are no
            // stack walk modifiers before the call.
            if (SecurityManager.IsGranted(unmanagedCodePermission))
            {
                try
                {
                    unmanagedCodePermission.Demand();
                    unmanagedCodePermissionAvailable = true;
                }
                catch (SecurityException)
                { }
            }

            if (unmanagedCodePermissionAvailable)
            {
                try
                {
                    processId = GetCurrentProcessId();
                }
                catch (Exception e)
                {
                    processId = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
                }

                try
                {
                    processName = GetProcessName();
                }
                catch (Exception e)
                {
                    processName = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
                }

                try
                {
                    win32ThreadId = GetCurrentThreadId();
                }
                catch (Exception e)
                {
                    win32ThreadId = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
                }
            }
            else
            {
                processId = String.Format(Properties.Resources.Culture,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPPROPERTYNOUNMANAGEDCODEPERMISSION);
                processName = String.Format(Properties.Resources.Culture,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPPROPERTYNOUNMANAGEDCODEPERMISSION);
                win32ThreadId = String.Format(Properties.Resources.Culture,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY,
                    Properties.Resources.ERROR_LOGENTRY_INTRINSICPPROPERTYNOUNMANAGEDCODEPERMISSION);
            }

            try
            {
                threadName = Thread.CurrentThread.Name;
            }
            catch (Exception e)
            {
                threadName = String.Format(Properties.Resources.Culture, Properties.Resources.ERROR_LOGENTRY_INTRINSICPROPERTY, e.Message);
            }

            // agrego los campos del principal al log
            EvaPrincipal principal = EvaContext.GetPrincipal();
            if (principal != null)
            {                 
                userName = ((EvaIdentity)principal.Identity).Name;
                surName = ((EvaIdentity)principal.Identity).Sn;
                givenName = ((EvaIdentity)principal.Identity).GivenName;
            }

        }

        ///<summary>
        /// <para> Cuerpo del mensaje a registrar en el Log</para>
        ///</summary>
        [XmlElement("Message")]
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        ///<summary>
        /// <para> Nombre de las categorías utilizado para rutear la entrada de log a los distintos almacenamientos.</para>
        ///</summary>
        [XmlArray("Categories")]
        [XmlArrayItem(typeof(string))]
        public List<string> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

        ///<summary>
        /// <para> Importancia del mensaje.</para>
        ///</summary>
        [XmlElement("Priority")]
        public int Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }

        ///<summary>
        /// <para> Número de evento o identificador.</para>
        ///</summary>
        [XmlElement("EventId")]
        public int EventId
        {
            get
            {
                return this.eventId;
            }
            set
            {
                this.eventId = value;
            }
        }

        ///<summary>
        /// <para> Severidad de la entrada de Log. Una opción de la enumeration <see cref="Severity"/> (Unspecified, Information, Warning or Error) </para>
        ///</summary>
        [IgnoreMember]
        public TraceEventType Severity
        {
            get { return this.severity; }
            set { this.severity = value; }
        }

        ///<summary>
        /// <para> Obtiene la cadena de texto que representa la <see cref="Severity"/> de la entrada de log.</para>
        ///</summary>
        [XmlElement("Severity")]
        public string LoggedSeverity
        {
            get
            {
                return this.severity.ToString();
            }
        }

        ///<summary>
        /// <para> Descripción adicional para la entrada de log.</para>
        ///</summary>
        [XmlElement("Title")]
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        /// <summary>
        /// Diccionario de clave/valor para guardar como información adicional.
        /// </summary>
        [IgnoreMember]
        [XmlElement("ExtendedProperties")]
        public SerializableDictionary<string, object> ExtendedProperties
        {
            get
            {
                if (extendedProperties == null)
                {
                    extendedProperties = new SerializableDictionary<string, object>();
                }
                return this.extendedProperties;
            }
            set { this.extendedProperties = value; }

        }

        ///<summary>
        /// <para> Fecha y hora de la entrada de log.</para>
        ///</summary>
        public DateTime TimeStamp
        {
            get { return this.timeStamp; }
            set { this.timeStamp = value; }
        }

        ///<summary>
        /// <para > Nombre de la computadora.</para>
        ///</summary>
        [XmlElement("MachineName")]
        public string MachineName
        {
            get { return this.machineName; }
            set { this.machineName = value; }
        }

        ///<summary>
        /// <para> El <see cref="AppDomain"/> en el cual el programa está corriendo.</para>
        ///</summary>
        [XmlElement("AppDomainName")]
        public string AppDomainName
        {
            get { return this.appDomainName; }
            set { this.appDomainName = value; }
        }

        ///<summary>
        /// <para> El ID de proceso de Win32 corriendo. </para>
        ///</summary>
        [XmlElement("ProcessId")]
        public string ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }

        ///<summary>
        /// <para> Nombre del proceso corriendo.</para>
        ///</summary>        
        [XmlElement("ProcessName")]
        public string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        ///<summary>
        /// <para> Nombre del usuario.</para>
        ///</summary>        
        [XmlElement("UserName")]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        ///<summary>
        /// <para> El nombre de Hilo de Ejecución .Net actual.</para>
        ///</summary>
        [XmlElement("ManagedThreadName")]
        public string ManagedThreadName
        {
            get { return threadName; }
            set { threadName = value; }
        }

        ///<summary>
        /// <para> El ID de Hilo de Ejecución de Win32 actual. </para>
        ///</summary>
        [XmlElement("Win32ThreadId")]
        public string Win32ThreadId
        {
            get { return win32ThreadId; }
            set { win32ThreadId = value; }
        }

        ///<summary>
        /// <para> Propiedad de solo lectura, retorna un <see cref="TimeStamp"/> con el formato de la cultura actual.</para>
        ///</summary>
        [XmlElement("TimeStamp")]
        public string TimeStampString
        {
            get { return TimeStamp.ToString(CultureInfo.CurrentCulture); }
        }

        ///<summary>
        /// <para> El ID de la actividad de Tracing.</para>
        ///</summary>
        [IgnoreMember]
        public Guid ActivityId
        {
            get { return this.activityId; }
            set { this.activityId = value; }
        }

        ///<summary>
        /// <para> ID de actividad relacionada.</para>
        ///</summary>
        [IgnoreMember]
        [XmlElement("RelatedActivityId")]
        public Guid? RelatedActivityId
        {
            get { return this.relatedActivityId; }
            set { this.relatedActivityId = value; }
        }

        ///<summary>
        /// <para> Crea una nueva instancia de <see cref="LogEntry"/> el cual es una copia de la actual.</para>
        ///</summary>
        /// <remarks>
        /// Si el dictionario contiene en <see cref="ExtendedProperties"/> implementa <see cref="ICloneable"/>, la nueva
        /// <see cref="LogEntry"/> tendrá las propiedades llamando a <c>Clone()</c>. De lo contrario el
        /// <see cref="LogEntry"/> resultante no tendrá las propiedades.
        /// </remarks>
        /// <implements>ICloneable.Clone</implements>
        ///<returns>
        /// <para> Una nueva <c>LogEntry</c> copia de la instancia actual.</para>
        /// </returns>
        public object Clone()
        {
            LogEntry result = new LogEntry();

            result.Message = this.Message;
            result.EventId = this.EventId;
            result.Title = this.Title;
            result.Severity = this.Severity;
            result.Priority = this.Priority;

            result.TimeStamp = this.TimeStamp;
            result.MachineName = this.MachineName;
            result.AppDomainName = this.AppDomainName;
            result.ProcessId = this.ProcessId;
            result.ProcessName = this.ProcessName;
            result.UserName = this.UserName;
            result.ManagedThreadName = this.ManagedThreadName;
            result.ActivityId = this.ActivityId;

            // clona categorias
            result.Categories = new List<string>(this.Categories);

            // clona extended properties
            if (this.extendedProperties != null)
                result.ExtendedProperties = new SerializableDictionary<string, object>(this.extendedProperties);

            // clona error messages
            if (this.errorMessages != null)
            {
                result.errorMessages = new StringBuilder(this.errorMessages.ToString());
            }

            return result;
        }

        ///<summary>
        /// <para> Agrega un mensaje advertencia o error a la entrada de log. </para>
        ///</summary>
        ///<param name="message">
        /// <para>Mensaje a agregar.</para>
        /// </param>
        public virtual void AddErrorMessage(string message)
        {
            if (errorMessages == null)
            {
                errorMessages = new StringBuilder();
            }
            errorMessages.Insert(0, Environment.NewLine);
            errorMessages.Insert(0, Environment.NewLine);
            errorMessages.Insert(0, message);
        }

        /// <summary>
        /// <para> Retorna los mensajes de error con la <see cref="LogEntry"/>. </para>
        /// </summary>
        [XmlElement("ErrorMessages")]
        public string ErrorMessages
        {
            get
            {
                if (errorMessages == null)
                    return null;
                else
                    return errorMessages.ToString();
            }
        }


        ///<summary>
        /// Retorna el nombre de proceso actual.
        ///</summary>
        ///<returns>
        /// <para>El Nombre del proceso actual.</para>
        /// </returns>
        public static string GetProcessName()
        {
            StringBuilder buffer = new StringBuilder(1024);
            int length = NativeMethods.GetModuleFileName(NativeMethods.GetModuleHandle(null), buffer, buffer.Capacity);
            return buffer.ToString();
        }

    }
}

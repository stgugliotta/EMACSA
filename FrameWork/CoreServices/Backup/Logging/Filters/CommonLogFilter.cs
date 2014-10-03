using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.Logging.Filters
{
    /// <summary>
    /// Representa un filtro que permite evaluar la prioridad, severidad y categorias de una entrada de Log.
    /// </summary>
    /// <remarks>Como éste se pueden realizar nuevos filtros.</remarks>
    public class CommonLogFilter : LogFilter
    {
        /// <summary>
        /// inicializa la instancia.
        /// </summary>
        /// <param name="name">Nombre de la instancia.</param>
        public CommonLogFilter(string name)
            :base(name)
        {

        }
        private ICollection<string> categories = new List<string>();

        /// <summary>
        /// Categorias a evaluar.
        /// </summary>
        public ICollection<string> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        private int? minimunPriority;

        /// <summary>
        /// Prioridad mínima a registrar.
        /// </summary>
        public int? MinimunPriority
        {
            get { return minimunPriority; }
        }

        private int? maximunPriority;

        /// <summary>
        /// Prioridad máxima a registrar.
        /// </summary>
        public int? MaximunPriority
        {
            get { return maximunPriority; }
        }

        private bool logEnabled;

        /// <summary>
        /// Indica si las condiciones se deben evaluar.
        /// </summary>
        public bool LogEnabled
        {
            get { return logEnabled; }
        }

        private CategoryFilterMode categoryFilterMode;

        /// <summary>
        /// Uno de los valores de de <see cref="CategoryFilterMode"/>.
        /// </summary>
        public CategoryFilterMode CategoryFilterMode
        {
            get { return this.categoryFilterMode; }
        }

        /// <summary>
        /// Verifica que el <see cref="LogEntry"/> verifico con el criterio del filtro. 
        /// </summary>
        /// <param name="log">Entrada de log a evaluar.</param>
        /// <returns><b>true</b>si el mensaje de almacenarse.</returns>
        public override bool Filter(LogEntry log)
        {
            if (LogEnabled)
                return DoFilter(log);
            return false;
        }

        private bool DoFilter(LogEntry log)
        {
            bool matchCriteria = (!this.minimunPriority.HasValue || log.Priority >= this.minimunPriority.Value) &&
                                 (this.maximunPriority.HasValue || log.Priority <= this.maximunPriority.Value) &&
                                 (this.categories.Count > 0 && this.MatchCategories(log.Categories));

            return matchCriteria;

        }

        private bool MatchCategories(ICollection<string> categoriesLog)
        {
            foreach(string categoryFilter in this.Categories)
            {
                foreach (string categoryLog in categoriesLog)
                {
                    if (string.Compare(categoryLog, categoryFilter, true) == 0)
                        return this.categoryFilterMode== CategoryFilterMode.DenyAllExceptAllowed;
                }
            }
            return this.CategoryFilterMode == CategoryFilterMode.AllowAllExceptDenied;
        }

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public override void Configure(ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement) element;

            string sMinimunPriority = dce.GetPropertyValue("minimunPriority");
            if (!string.IsNullOrEmpty(sMinimunPriority))
            {
                this.minimunPriority = Convert.ToInt32(sMinimunPriority);
            }

            string sMaximunPriority = dce.GetPropertyValue("maximunPriority");
            if (!string.IsNullOrEmpty(sMaximunPriority))
            {
                this.maximunPriority = Convert.ToInt32(sMaximunPriority);
            }

            this.logEnabled = Convert.ToBoolean(dce.GetPropertyValue("logEnabled"));

            string sCategoryFilterMode = dce.GetPropertyValue("categoryFilterMode");
            this.categoryFilterMode = (CategoryFilterMode) Enum.Parse(typeof (CategoryFilterMode), sCategoryFilterMode);
            
            GenericConfigurationElementCollection<ConfigurationNamedElement> categoriesElement = 
                (GenericConfigurationElementCollection<ConfigurationNamedElement>)dce.GetElement (
                    "categories", 
                    typeof(GenericConfigurationElementCollection<ConfigurationNamedElement>));
            if (categoriesElement != null)
            {
                foreach(ConfigurationNamedElement cne in categoriesElement)
                {
                    
                    this.categories.Add(cne.Name);
                }
            }
        }
    }

    /// <summary>
    /// Define si el criterio es incluyente o excluyente.
    /// </summary>
    public enum CategoryFilterMode
    {
        /// <summary>
        /// Permite el procesamiento todas las entredas que no concuerdan con el criterio.
        /// </summary>
        AllowAllExceptDenied,

        /// <summary>
        /// Permite el procesamiento todas las entredas que concuerdan con el criterio.
        /// </summary>
        DenyAllExceptAllowed,
    }
}

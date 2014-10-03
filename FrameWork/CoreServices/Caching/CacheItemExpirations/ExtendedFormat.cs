using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Representa el formato extendido para la cache.
    /// </summary>    
    /// <remarks>
    /// Sintaxis de extended format : <br/><br/>
    /// 
    /// Minuto           - 0-59 <br/>
    /// Hora             - 0-23 <br/>
    /// Día del mes      - 1-31 <br/>
    /// Mes              - 1-12 <br/>
    /// Día de la semana - 0-6 (Domingo es 0) <br/>
    /// Comodín           - * significa corre todos <br/>
    /// Ejemplos: <br/>
    /// * * * * *    - vence cada minuto<br/>
    /// 5 * * * *    - vence el 5to minuto de cada hora <br/>
    /// * 21 * * *   - vence cada minuto de la hora 21 de cada día<br/>
    /// 31 15 * * *  - vence 3:31 PM cada día <br/>
    /// 7 4 * * 6    - vence Sabado 4:07 AM <br/>
    /// 15 21 4 7 *  - vence 9:15 PM el 4 de Julio <br/>
    ///	Entonces 6 6 6 6 1 significa:
    ///	•	hemos entrado/pasado al 6to minuto Y <br/>
    ///	•	hemos entrado/pasado al 6ta hora Y <br/>
    ///	•	hemos entrado/pasado al 6to día Y <br/>
    ///	•	hemos entrado/pasado al 6to mes Y <br/>
    ///	•	hemos entrado/pasado al  A LUNES? <br/>
    ///
    ///	Estos casos muestran ese comportamiento: <br/>
    ///
    ///	getTime = DateTime.Parse( "02/20/2003 04:06:55 AM" ); <br/>
    ///	nowTime = DateTime.Parse( "06/07/2003 07:07:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 1", getTime, nowTime );<br/>
    ///	TRUE, en todos hemos entrado/pasado<br/>
    ///			<br/>
    ///	getTime = DateTime.Parse( "02/20/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/07/2003 07:07:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 5", getTime, nowTime );<br/>
    ///	TRUE<br/>
    ///			<br/>
    ///	getTime = DateTime.Parse( "02/20/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2003 06:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 *", getTime, nowTime );<br/>
    ///	TRUE<br/>
    ///	<br/>
    ///	getTime = DateTime.Parse( "06/05/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2003 06:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 5", getTime, nowTime );<br/>
    ///	TRUE<br/>
    ///						<br/>
    ///	getTime = DateTime.Parse( "06/05/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2005 05:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 1", getTime, nowTime );<br/>
    ///	TRUE<br/>
    ///						<br/>
    ///	getTime = DateTime.Parse( "06/05/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2003 05:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 1", getTime, nowTime );<br/>
    ///	FALSE:  no hemos pasado/entrado la 6ta hora, no hemos pasado/entrado el lunes.<br/>
    ///						<br/>
    ///	getTime = DateTime.Parse( "06/05/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2003 06:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 5", getTime, nowTime );<br/>
    ///	TRUE, hemos pasado/entrado Viernes.<br/>
    ///<br/>
    ///
    ///	getTime = DateTime.Parse( "06/05/2003 04:06:55 AM" );<br/>
    ///	nowTime = DateTime.Parse( "06/06/2003 06:06:00 AM" );<br/>
    ///	isExpired = ExtendedFormatHelper.IsExtendedExpired( "6 6 6 6 1", getTime, nowTime );<br/>
    ///	FALSE:  no hemos pasado el Lunes pero todas las demas condiciones están satisfechas.<br/>
    /// </remarks>
    public class ExtendedFormat
    {
        private readonly string format;

        private static readonly char argumentDelimiter = Convert.ToChar(",", CultureInfo.CurrentUICulture);
        private static readonly char wildcardAll = Convert.ToChar("*", CultureInfo.CurrentUICulture);
        private static readonly char refreshDelimiter = Convert.ToChar(" ", CultureInfo.CurrentUICulture);

        private int[] minutes;
        private int[] hours;
        private int[] days;
        private int[] months;
        private int[] daysOfWeek;

        /// <summary>
        /// Valida el formato.
        /// </summary>
        /// <param name="timeFormat">
        /// El formato a validar.
        /// </param>
        public static void Validate(string timeFormat)
        {
            ExtendedFormat ef = new ExtendedFormat(timeFormat);
            ef.Initialize();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExtendedFormat"/> con un formato.
        /// </summary>
        /// <param name="format">El formato de fecha y hora extendido.</param>
        public ExtendedFormat(string format)
        {
            if (format == null)
            {
                throw new GobbiTechnicalException("", new ArgumentNullException("format"));
            }
            this.format = format;
            Initialize();
        }

        private void Initialize()
        {
            string[] parsedFormat = format.Trim().Split(refreshDelimiter);
            if (parsedFormat.Length != 5)
            {
                throw new GobbiTechnicalException("", new ArgumentOutOfRangeException(Resources.ERROR_EXTENDEDFORMATINVALIDARGUMENTS));
            }
            ParseMinutes(parsedFormat);
            ParseHours(parsedFormat);
            ParseDays(parsedFormat);
            ParseMonths(parsedFormat);
            ParseDaysOfWeek(parsedFormat);
        }

        /// <summary>
        /// Obtiene el formato extendido.
        /// </summary>
        /// <value>
        /// El formato extendido.
        /// </value>
        public string Format
        {
            get { return this.format; }
        }

        /// <summary>
        /// Obtiene los minutos a expirar.
        /// </summary>
        /// <value>
        /// Los minutos a expirar.
        /// </value>
        /// <returns>
        /// Devuelve una copia del arreglo de enteros con los minutos a expirar.
        /// </returns>
        public int[] GetMinutes()
        {
            return (int[])minutes.Clone();
        }

        /// <summary>
        /// Obtiene las horas a expirar.
        /// </summary>
        /// <value>
        /// Las horas a expirar.
        /// </value>
        /// <returns>
        /// Devuelte una copia del arreglo de enteros con las horas a expirar.
        /// </returns>
        public int[] GetHours()
        {
            return (int[])hours.Clone();
        }

        /// <summary>
        /// Obtiene los días a expirar.
        /// </summary>
        /// <value>
        /// Los días a expirar.
        /// </value>
        /// <returns>
        /// Devuelve una copia del arreglo de enteros con los días a expirar.
        /// </returns>
        public int[] GetDays()
        {
            return (int[])days.Clone();
        }

        /// <summary>
        /// Obtiene los meses del año a vencer.
        /// </summary>
        /// <value>
        /// Los meses del año a vencer.
        /// </value>
        /// <returns>
        /// Devuelve una copia del arreglo de enteros con los meses a vencer.
        /// </returns>
        public int[] GetMonths()
        {
            return (int[])months.Clone();
        }

        /// <summary>
        /// Obtiene los días de la semana a vencer.
        /// </summary>
        /// <value>
        /// Los días de la semana a vencer.
        /// </value>
        /// <returns>
        /// Devuelve una copia del arreglo de enteros con los días de la semana a vencer.
        /// </returns>
        public int[] GetDaysOfWeek()
        {
            return (int[])daysOfWeek.Clone();
        }

        /// <summary>
        /// Determina si debe vencer cada minuto.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si debe vencer cada minuto; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool ExpireEveryMinute
        {
            get { return this.minutes[0] == -1; }
        }

        /// <summary>
        /// Determina si debe vencer cada día.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si debe vencer cada día; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool ExpireEveryDay
        {
            get { return this.days[0] == -1; }
        }

        /// <summary>
        /// Determina si debe vencer cada hora.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si debe vencer cada hora; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool ExpireEveryHour
        {
            get { return this.hours[0] == -1; }
        }

        /// <summary>
        /// Determina si debe vencer cada mes.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si debe vencer cada mes; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool ExpireEveryMonth
        {
            get { return this.months[0] == -1; }
        }

        /// <summary>
        /// Determina si debe vencer cada día de la semana.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si debe vencer cada día de la semana; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool ExpireEveryDayOfWeek
        {
            get { return this.daysOfWeek[0] == -1; }
        }

        private void ParseMinutes(string[] parsedFormat)
        {
            this.minutes = ParseValueToInt(parsedFormat[0]);
            foreach (int minute in this.minutes)
            {
                if ((minute > 59) || (minute < -1))
                {
                    throw new GobbiTechnicalException("",  new ArgumentOutOfRangeException("format", Resources.ERROR_EXTENDEDFORMATRANGEMINUTES));
                }
            }
        }

        private void ParseHours(string[] parsedFormat)
        {
            this.hours = ParseValueToInt(parsedFormat[1]);
            foreach (int hour in this.hours)
            {
                if ((hour > 23) || (hour < -1))
                {
                    throw new GobbiTechnicalException("", new ArgumentOutOfRangeException("format", Resources.ERROR_EXTENDEDFORMATRANGEHOURS));
                }
            }
        }

        private void ParseDays(string[] parsedFormat)
        {
            this.days = ParseValueToInt(parsedFormat[2]);
            foreach (int day in this.days)
            {
                if ((day > 31) || (day < -1))
                {
                    throw new GobbiTechnicalException("",  new ArgumentOutOfRangeException("format", Resources.ERROR_EXTENDEDFORMATRANGEDAYS));
                }
            }
        }

        private void ParseMonths(string[] parsedFormat)
        {
            this.months = ParseValueToInt(parsedFormat[3]);
            foreach (int month in this.months)
            {
                if ((month > 12) || (month < -1))
                {
                    throw new GobbiTechnicalException("",  new ArgumentOutOfRangeException("format", Resources.ERROR_EXTENDEDFORMATRANGEMONTHS));
                }
            }
        }

        private void ParseDaysOfWeek(string[] parsedFormat)
        {
            this.daysOfWeek = ParseValueToInt(parsedFormat[4]);
            foreach (int dayOfWeek in this.daysOfWeek)
            {
                if ((dayOfWeek > 6) || (dayOfWeek < -1))
                {
                    throw new GobbiTechnicalException("", new ArgumentOutOfRangeException("format", Resources.ERROR_EXTENDEDFORMATRANGEDAYS));
                }
            }
        }

        private static int[] ParseValueToInt(string value)
        {
            int[] result;

            if (value.IndexOf(wildcardAll) != -1)
            {
                result = new int[1];
                result[0] = -1;
            }
            else
            {
                string[] values = value.Split(argumentDelimiter);
                result = new int[values.Length];
                for (int index = 0; index < values.Length; index++)
                {
                    result[index] = int.Parse(values[index], CultureInfo.CurrentUICulture);
                }
            }
            return result;
        }

        /// <summary>
        /// Determina si el tiempo ha expirado.
        /// </summary>
        /// <param name="getTime">El fecha y hora a comparar.</param>
        /// <param name="nowTime">Fecha y hora actual.</param>
        /// <returns>
        /// <see langword="true"/> si el tiempo ha expirado; de lo contrario, <see langword="false"/>.
        /// </returns>
        public bool IsExpired(DateTime getTime, DateTime nowTime)
        {
            // Removes the seconds to provide better precission on calculations
            getTime = getTime.AddSeconds(getTime.Second * -1);
            nowTime = nowTime.AddSeconds(nowTime.Second * -1);
            if (nowTime.Subtract(getTime).TotalMinutes < 1)
            {
                return false;
            }
            foreach (int minute in minutes)
            {
                foreach (int hour in hours)
                {
                    foreach (int day in days)
                    {
                        foreach (int month in months)
                        {
                            // Set the expiration date parts
                            int expirMinute = minute == -1 ? getTime.Minute : minute;
                            int expirHour = hour == -1 ? getTime.Hour : hour;
                            int expirDay = day == -1 ? getTime.Day : day;
                            int expirMonth = month == -1 ? getTime.Month : month;
                            int expirYear = getTime.Year;

                            // Adjust when wildcards are set
                            if ((minute == -1) && (hour != -1))
                            {
                                expirMinute = 0;
                            }
                            if ((hour == -1) && (day != -1))
                            {
                                expirHour = 0;
                            }
                            if ((minute == -1) && (day != -1))
                            {
                                expirMinute = 0;
                            }
                            if ((day == -1) && (month != -1))
                            {
                                expirDay = 1;
                            }
                            if ((hour == -1) && (month != -1))
                            {
                                expirHour = 0;
                            }
                            if ((minute == -1) && (month != -1))
                            {
                                expirMinute = 0;
                            }

                            if (DateTime.DaysInMonth(expirYear, expirMonth) < expirDay)
                            {
                                //								if (expirMonth == 12) 
                                //								{
                                //									expirMonth = 1;
                                //									expirYear++;
                                //								} 
                                //								else 
                                //								{
                                expirMonth++;
                                //								}
                                expirDay = 1;
                            }

                            // Create the date with the adjusted parts
                            DateTime expTime = new DateTime(
                                expirYear, expirMonth, expirDay,
                                expirHour, expirMinute, 0);

                            // Adjust when expTime is before getTime
                            if (expTime < getTime)
                            {
                                if ((month != -1) && (getTime.Month >= month))
                                {
                                    expTime = expTime.AddYears(1);
                                }
                                else if ((day != -1) && (getTime.Day >= day))
                                {
                                    expTime = expTime.AddMonths(1);
                                }
                                else if ((hour != -1) && (getTime.Hour >= hour))
                                {
                                    expTime = expTime.AddDays(1);
                                }
                                else if ((minute != -1) && (getTime.Minute >= minute))
                                {
                                    expTime = expTime.AddHours(1);
                                }
                            }

                            // Is Expired?
                            if (ExpireEveryDayOfWeek)
                            {
                                if (nowTime >= expTime)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                // Validate WeekDay								
                                foreach (int weekDay in daysOfWeek)
                                {
                                    DateTime tmpTime = getTime;
                                    tmpTime = tmpTime.AddHours(-1 * tmpTime.Hour);
                                    tmpTime = tmpTime.AddMinutes(-1 * tmpTime.Minute);
                                    while ((int)tmpTime.DayOfWeek != weekDay)
                                    {
                                        tmpTime = tmpTime.AddDays(1);
                                    }
                                    if ((nowTime >= tmpTime) && (nowTime >= expTime))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}

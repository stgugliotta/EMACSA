using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa un temporizador de control de vencimientos.
    /// </summary>
    public sealed class ExpirationPollTimer : IDisposable
    {
        private Timer pollTimer;

        /// <summary>
        /// Incializa una nueva instancia.
        /// </summary>
        public ExpirationPollTimer()
        {

        }
        /// <summary>
        /// Inicia el temporizador.
        /// </summary>
        /// <param name="callbackMethod">Método a llamar cuando termina un ciclo.</param>
        /// <param name="pollCycleInMilliseconds">Tiempo en milisegundos entre cada llamada.</param>
        public void StartPolling(TimerCallback callbackMethod, int pollCycleInMilliseconds)
        {
            if (callbackMethod == null)
            {
                throw new GobbiTechnicalException ("", new ArgumentNullException("callbackMethod"));
            }
            if (pollCycleInMilliseconds <= 0)
            {
                throw new GobbiTechnicalException ("", new  ArgumentException(Resources.ERROR_EXPIRATIONPOLLTIMER_INVALIDTIME, "pollCycleInMilliseconds"));
            }

            pollTimer = new Timer(callbackMethod, null, pollCycleInMilliseconds, pollCycleInMilliseconds);
        }

        /// <summary>
        /// Detiene el temporizador.
        /// </summary>
        public void StopPolling()
        {
            if (pollTimer == null)
            {
                throw new GobbiTechnicalException ("", new  InvalidOperationException(Resources.ERROR_EXPIRATIONPOLLTIMER_INVALIDSTOPOPERATION));
            }

            pollTimer.Dispose();
            pollTimer = null;
        }

        void IDisposable.Dispose()
        {
            if (pollTimer != null) pollTimer.Dispose();
        }
    }
}

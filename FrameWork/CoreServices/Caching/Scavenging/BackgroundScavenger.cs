using System;
using System.Threading;
using Gobbi.CoreServices.Caching.Instrumentation;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa un basurero de cache que corre en un hilo de ejecución de segundo plano.
    /// </summary>
    public class BackgroundScavenger : ICacheScavenger
    {
        private ProducerConsumerQueue inputQueue = new ProducerConsumerQueue();
        private Thread inputQueueThread;
        private ExpirationTask expirer;
        private ScavengerTask scavenger;
        private bool isActive;
        private bool running;

        /// <summary>
        /// Inicializa un nueva instancia de <see cref="BackgroundScavenger"/> con una <see cref="ExpirationTask"/> 
        /// y una <see cref="ScavengerTask"/>.
        /// </summary>
        /// <param name="expirer">La tarea de vencimiento a usar.</param>
        /// <param name="scavenger">La tarea de limpieza a usar.</param>
        public BackgroundScavenger(ExpirationTask expirer, ScavengerTask scavenger)
        {
            this.expirer = expirer;
            this.scavenger = scavenger;

            ThreadStart queueReader = new ThreadStart(QueueReader);
            inputQueueThread = new Thread(queueReader);
            inputQueueThread.IsBackground = true;
        }

        /// <summary>
        /// Inicia el basurero limepieza.
        /// </summary>
        public void Start()
        {
            running = true;
            inputQueueThread.Start();
        }

        /// <summary>
        /// Detiene el basurero.
        /// </summary>
        public void Stop()
        {
            running = false;
            inputQueueThread.Interrupt();
        }

        /// <summary>
        /// Indica si el basurero está activado.
        /// </summary>
        /// <value>
        /// <see langword="true"/> si el basurero está activo; de lo contrario, <see langword="false"/>.
        /// </value>
        public bool IsActive
        {
            get { return isActive; }
        }

        /// <summary>
        /// Encola un mensaje indicando que debe realizarse una nueva limpieza.
        /// </summary>
        /// <param name="notUsed">Ignorado.</param>
        public void ExpirationTimeoutExpired(object notUsed)
        {
            inputQueue.Enqueue(new ExpirationTimeoutExpiredMsg(this));
        }

        /// <summary>
        /// Inicia el proceso de limpieza.
        /// </summary>
        public void StartScavenging()
        {
            inputQueue.Enqueue(new StartScavengingMsg(this));
        }

        internal void DoStartScavenging()
        {
            scavenger.DoScavenging();
        }

        internal void DoExpirationTimeoutExpired()
        {
            expirer.DoExpirations();
        }

        private void QueueReader()
        {
            isActive = true;
            while (running)
            {
                IQueueMessage msg = inputQueue.Dequeue() as IQueueMessage;
                try
                {
                    if (msg == null)
                    {
                        continue;
                    }

                    msg.Run();
                }
                catch (ThreadInterruptedException)
                {
                }
                catch 
                {
                    InstrumentationProvider.CacheFailed();
                }
            }
            isActive = false;
        }
    }
}

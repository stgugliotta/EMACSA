using System;
using System.Collections;
using System.Threading;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa una cola sincronizada.
    /// </summary>	
    public class ProducerConsumerQueue
    {
        private object lockObject = new Object();
        private Queue queue = new Queue();

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public ProducerConsumerQueue()
        {

        }

        /// <summary>
        /// Obtiene la cantidad de elementos en la cola.
        /// </summary>
        /// <value>
        /// La cantidad de elementos en la cola.
        /// </value>
        public int Count
        {
            get { return queue.Count; }
        }

        /// <summary>
        /// Devuelve y elimina el primer objeto de la cola.
        /// </summary>
        /// <returns>
        /// El primer objeto de la cola.
        /// </returns>
        public object Dequeue()
        {
            lock (lockObject)
            {
                while (queue.Count == 0)
                {
                    if (WaitUntilInterrupted())
                    {
                        return null;
                    }
                }

                return queue.Dequeue();
            }
        }


        /// <summary>
        /// Agrega el objeto al final de la cola.
        /// </summary>		
        /// <param name="queueItem">Objeto a agregar.</param>
        public void Enqueue(object queueItem)
        {
            lock (lockObject)
            {
                queue.Enqueue(queueItem);
                Monitor.Pulse(lockObject);
            }
        }

        private bool WaitUntilInterrupted()
        {
            try
            {
                Monitor.Wait(lockObject);
            }
            catch (ThreadInterruptedException)
            {
                return true;
            }

            return false;
        }
    }
}

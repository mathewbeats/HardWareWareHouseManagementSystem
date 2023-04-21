using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseManagementSystemsApi
{
    // Declaración del delegado genérico QueueEventHandler
    public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);

    // Clase genérica CustomQueue
    public class CustomQueue<T> where T : IEntityPrimaryPorperties, IEntityAdiccionalPropperties
    {
        // Cola interna para almacenar elementos de tipo T
        Queue<T> _queue = null;

        // Evento CustomQueueEvent que utiliza el delegado QueueEventHandler
        public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

        // Constructor que inicializa la cola interna
        public CustomQueue()
        {
            _queue = new Queue<T>();
        }

        // Propiedad que devuelve el número de elementos en la cola interna
        public int QueueLenght
        {
            get { return _queue.Count; }
        }

        // Método para agregar un elemento a la cola y generar un mensaje de evento
        public void AddItem(T item)
        {
            _queue.Enqueue(item);

            QueueEventArgs queueEventArgs = new QueueEventArgs
            {
                Message = $"Datetime: {DateTime.Now.ToString(Constants.DateFormat)}, Id ({item.Id}), Name ({item.name}),Type ({item.Type}), Quantity {item.Quantity}, has been added to the queue."
            };

            // Llama al método OnQueueChanged para activar el evento CustomQueueEvent
            OnQueueChanged(queueEventArgs);
        }

        // Método que, en teoría, debería recuperar un elemento de la cola
        public T GetItem()
        {
            T item = _queue.Dequeue();

            QueueEventArgs queueEventArgs = new QueueEventArgs
            {
                Message = $"Datetime: {DateTime.Now.ToString(Constants.DateFormat)}, Id ({item.Id}), Name ({item.name}),Type ({item.Type}), Quantity {item.Quantity}, has been processed."


            };

            OnQueueChanged(queueEventArgs);

            return item;
        }

        // Método que dispara el evento CustomQueueEvent con los argumentos proporcionados
        protected virtual void OnQueueChanged(QueueEventArgs a)
        {
           
                CustomQueueEvent(this, a);
            
        }

        // Método que devuelve un enumerador para iterar sobre los elementos de la cola interna
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }

    // Clase QueueEventArgs que hereda de System.EventArgs y contiene una propiedad Message
    public class QueueEventArgs : System.EventArgs
    {
        public string Message { get; set; }
    }
}

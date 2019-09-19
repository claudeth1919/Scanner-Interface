using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;


namespace CommunicationsLibrary.Services.P2PCommunicationsScheme.Common
{
    internal sealed class SocketAsyncEventArgsPool
    {
        Stack<SocketAsyncEventArgs> pool;    
      
        internal SocketAsyncEventArgsPool(Int32 capacity)
        {     
            this.pool = new Stack<SocketAsyncEventArgs>(capacity);
        }

        // The number of SocketAsyncEventArgs instances in the pool.         
        internal Int32 Count
        {
            get { return this.pool.Count; }
        }      
                
        internal SocketAsyncEventArgs Pop()
        {
            lock (this.pool)
            {
                return this.pool.Pop();
            }
        }

        internal void Push(SocketAsyncEventArgs item)
        {
            if (item == null) 
            { 
                throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); 
            }
            lock (this.pool)
            {
                this.pool.Push(item);
            }
        }        
   }
}

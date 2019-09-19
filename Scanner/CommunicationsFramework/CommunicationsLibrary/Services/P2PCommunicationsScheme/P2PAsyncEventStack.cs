using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme
	{

        internal class P2PAsyncEventStack : IDisposable
        {

            #region < DATA MEMBERS >

                private Stack<SocketAsyncEventArgs> _socketstack;

            #endregion

            #region < CONSTRUCTORS >

            internal P2PAsyncEventStack(int maxCapacity)
            {
                _socketstack = new Stack<SocketAsyncEventArgs>(maxCapacity);
            }

            #endregion

            #region < PUBLIC METHODS  >

            // Pop an asyncEvtArgs off of the top of the stack
            internal SocketAsyncEventArgs Pop()
            {
                //We are locking the stack, but we could probably use a ConcurrentStack if
                // we wanted to be fancy
                lock (_socketstack)
                {
                    if (_socketstack.Count > 0)
                    {
                        return _socketstack.Pop();
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            // Push an asyncEvtArgs onto the top of the stack
            internal void Push(SocketAsyncEventArgs item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("Cannot add null object to socket stack");
                }

                lock (_socketstack)
                {
                    _socketstack.Push(item);
                }
            }

            #endregion


            public void Dispose()
            {
                try
                {
                    SocketAsyncEventArgs item;
                    item = this.Pop();
                    while (item != null)
                    {
                        item.Dispose();
                        item = this.Pop();
                    }
                                                           
                }
                catch (Exception ex)
                { }
            }
        }

    }
}

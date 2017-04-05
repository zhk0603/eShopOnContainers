using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Ordering.API.Application.Commands
{
    // DDD and CQRS patterns comment: Note that it is recommended to implement immutable Commands
    // In this case, its immutability is achieved by having all the setters as private
    // plus only being able to update the data just once, when creating the object through its constructor.
    // References on Immutable Commands:  
    // http://cqrs.nu/Faq
    // https://docs.spine3.org/motivation/immutability.html 
    // http://blog.gauffin.org/2012/06/griffin-container-introducing-command-support/
    // https://msdn.microsoft.com/en-us/library/bb383979.aspx

    [DataContract]
    public class ProcessOrderCommand
        : IAsyncRequest<bool>
    {
        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public int OrderId { get; private set; }

        public ProcessOrderCommand(Guid requestId, int orderId)
        {
            RequestId = requestId;
            OrderId = orderId;
        }        
    }
}

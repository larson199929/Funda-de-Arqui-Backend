using MediatR;

namespace Customer.Service.EventHandlers.Commands
{
    public class ParentCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Dni { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
    }
}

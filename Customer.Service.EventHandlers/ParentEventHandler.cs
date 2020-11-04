using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class ParentEventHandler :
        INotificationHandler<ParentCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ParentEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ParentCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Parent {
                Name = notification.Name
            });

            await _context.SaveChangesAsync();
        }
    }
}

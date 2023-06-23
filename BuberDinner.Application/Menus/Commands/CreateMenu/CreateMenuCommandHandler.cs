using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            // create menu
            var menu = Menu.Create(
                hostId: HostId.Create(request.HostId), 
                name: request.Name, 
                description: request.Description, 
                menuSections: request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name, section.Description, section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name, item.Description)))));

            // persist menu

            // return menu
            return default!;
        }
    }
}

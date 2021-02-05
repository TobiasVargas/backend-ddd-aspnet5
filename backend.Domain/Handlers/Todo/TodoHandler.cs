using backend.Domain.Commands;
using backend.Domain.Commands.Contracts;
using backend.Domain.Commands.Todo;
using backend.Domain.Entities.Todo;
using backend.Domain.Handlers.Contracts;
using backend.Domain.Repositories.Todo;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Handlers.Todo
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);

            TodoItem todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
    }
}

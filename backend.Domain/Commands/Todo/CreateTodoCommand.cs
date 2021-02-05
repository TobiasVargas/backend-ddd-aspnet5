using backend.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace backend.Domain.Commands.Todo
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        // semelhante a um dto ou viewmodel
        public CreateTodoCommand() { }
        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}

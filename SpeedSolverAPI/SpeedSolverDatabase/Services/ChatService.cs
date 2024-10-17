using SpeedSolverAPI.DTO.Chat;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Services.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Services
{
    public class ChatService: Service<InProjectMessage>
    {

        public static ChatService Create() => new ChatService();
        private ChatService()
        {
            this._repository = new ChatRepository();
        }

        public async Task<bool> InsertMessage(ProjectMessageCreateDto msg)
        {
            try
            {
                _repository.Insert(new InProjectMessage
                {
                    UserId = msg.UserId,
                    Content = msg.Content,
                    ProjectId = msg.ProjectId,
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

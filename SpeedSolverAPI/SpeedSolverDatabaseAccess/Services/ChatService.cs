﻿using Microsoft.EntityFrameworkCore;
using SpeedSolverAPI.DTO.Chat;
using SpeedSolverCore.DTO.Chat;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo;
using SpeedSolverDatabaseAccess.Services.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabaseAccess.Services
{
    public class ChatService: Service<InProjectMessageEntity>
    {

        public static ChatService Create() => new ChatService();
        private ChatService()
        {
            this._repository = new ChatRepository();
        }

        public async Task<List<MessageHistoryDto>> GetMessageHistory(int projectId)
        {
            var data = _repository.Filtered(x => x.ProjectId == projectId).Include(c => c.User).ToList();

            List<MessageHistoryDto> result = new();

            data.ForEach(elem =>
            {
                result.Add(new MessageHistoryDto
                {
                    Author = new MessageAuthor
                    {
                        Name = elem.User.Name is null ? string.Empty : elem.User.Name,
                        Surname = elem.User.Name is null ? string.Empty : elem.User.Surname,
                        Patronymic = elem.User.Name is null ? string.Empty : elem.User.Patronymic
                    },
                    Content = elem.Content,
                    CreatedAt = elem.SendedAt
                });
            });

            return result;
        }

    }
}

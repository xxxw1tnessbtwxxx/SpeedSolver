import asyncio
from typing import Final
import websockets
import sqlite3
import json

from models.msg import Message
from utils.postmessage import save_message

connected_users = {

}

async def handler(connection, path):
    current_project = int(path.split("/")[1])

    if current_project not in connected_users:
        connected_users[current_project] = set()
    connected_users[current_project].add(connection)

    try:
        async for json_msg in connection:
            data = json.loads(json_msg)
            
            # await save_message(current_project, Message (
            #     content=data['content'],
            #     user_id=int(data['user_id'])
            # ))

            for client in connected_users[current_project]:
                    if client != connection:
                        await client.send(json_msg)
    finally:
        # Удаляем клиента из списка при закрытии соединения
        connected_users[current_project].remove(connection)
        if not connected_users[current_project]:
            del connected_users[current_project]


port: Final = 8765
async def main():
    start_server = websockets.serve(handler, "0.0.0.0", port)
    await start_server
    await asyncio.Future()  # Бесконечный цикл для поддержания работы сервера

if __name__ == "__main__":
    asyncio.run(main())
import requests
from models.msg import Message
async def save_message(msg: Message):
    print(f"saving message: \nuser_id: {msg.user_id}\ncontent: {msg.content}")
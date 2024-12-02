import requests
from models.msg import Message
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


async def save_message(project: int, msg: Message):
    result = requests.post(url=f"https://localhost:7278/api/v1/inprojectchats/postMessage", json = {
        "content": msg.content,
        "userId": msg.user_id,
        "projectId": project
    }, verify=False)

    print(result.status_code)


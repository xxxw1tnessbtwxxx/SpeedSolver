FROM python:3.10 AS prod

WORKDIR /pythonserver/websocket 
COPY pyproject.toml poetry.lock /pythonserver/websocket/

RUN apt-get update && apt-get install -y \
  gcc \
  && rm -rf /var/lib/apt/lists/* && \
  pip install poetry==1.4.2 && \
  poetry config virtualenvs.create false && \
  poetry install --only main && \
  apt-get purge -y \
  && rm -rf /var/lib/apt/lists/*

COPY . /pythonserver/websocket/

EXPOSE 8765

CMD ["/usr/local/bin/python", "-m", "WebSocket"]

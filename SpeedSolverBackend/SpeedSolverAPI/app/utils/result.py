
from typing import Generic, TypeVar, Optional

T = TypeVar('T')

class Result(Generic[T]):
    def __init__(self, success: bool, value: T | None = None, error: str | None = None):
        self.success = success
        self.value = value
        self.error = error
import bcrypt


def hash_password(password: str) -> str:
    password_bytes = password.encode('utf-8')

    hashed_password = bcrypt.hashpw(password_bytes, bcrypt.gensalt(5))

    hashed_password_str = hashed_password.decode('utf-8')

    return hashed_password_str
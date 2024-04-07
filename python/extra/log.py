import logging
from functools import wraps


FILEMODE = 'w'
FORMAT = '{levelname} - {asctime} - {message}'
LEVEL = 'NOTSET'

logging.basicConfig(filename='logs.log', filemode=FILEMODE, format=FORMAT, style='{', level=LEVEL)
logger = logging.getLogger(__name__)


def logging_function(func):
    @wraps(func)
    def wrapper(*args, **kwargs):
        try:
            result = func(*args, **kwargs)
        except Exception as e:
            logger.critical(f'Результатом выполнения {func.__qualname__} с аргумантами {args}, было исключение {e}')
            raise e
        logger.info(f'Результат выполнения {func.__qualname__} с аргумантами {args} - {result}')
        return result
    return wrapper


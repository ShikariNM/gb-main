from time import time
from functools import wraps


def time_decorator(full_program=True):
    def middle(func):
        @wraps(func)
        def wrapper(*args, **kwargs):
            start_time = time()
            result = func(*args, **kwargs)
            execution_time = time() - start_time
            text = f'The program was executed for {execution_time:.4f} seconds' if full_program else \
                   f'{result} was downloaded for {execution_time:.4f} seconds'
            print(text)
        return wrapper
    return middle


def async_time_decorator(full_program=True):
    def middle(func):
        @wraps(func)
        async def wrapper(*args, **kwargs):
            start_time = time()
            result = await func(*args, **kwargs)
            execution_time = time() - start_time
            text = f'The program was executed for {execution_time:.4f} seconds' if full_program else \
                   f'{result} was downloaded for {execution_time:.4f} seconds'
            print(text)
        return wrapper
    return middle

from abc import ABC


class IdIncrementor(ABC):
    _static_id: int = 0

    def __new__(cls, *args, **kwargs):
        cls._static_id += 1
        return super().__new__(cls)

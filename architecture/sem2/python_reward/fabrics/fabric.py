from abc import ABC, abstractmethod


class Fabric(ABC):
    @abstractmethod
    def create_item(self):
        ...

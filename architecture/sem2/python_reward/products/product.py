from abc import ABC, abstractmethod


class Product(ABC):
    @abstractmethod
    def open_reward(self):
        ...

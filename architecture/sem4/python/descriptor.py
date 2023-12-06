class Descriptor:

    def __init__(self, is_constant: bool = False):
        self.is_constant = is_constant

    def __set_name__(self, owner, name):
        self.name = "__" + name

    def __get__(self, instance, owner):
        return getattr(instance, self.name)

    def __set__(self, instance, value):
        if self.is_constant and getattr(instance, self.name, None):
            raise AttributeError("Нельзя изменить значение атрибута")
        setattr(instance, self.name, value)


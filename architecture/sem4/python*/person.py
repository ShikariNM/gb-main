from descriptor import Descriptor


class Person:

    login = Descriptor(is_constant=True)
    hash_pass = Descriptor()
    full_name = Descriptor()
    card_number = Descriptor()

    def __init__(self, login: str, hash_pass: int, full_name: str, card_number: int) -> None:
        self.login = login
        self.hash_pass = hash_pass
        self.full_name = full_name
        self.card_number = card_number
        self.tickets = dict()

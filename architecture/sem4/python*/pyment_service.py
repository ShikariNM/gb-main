from bank_account import BankAccount


class PaymentService:
    def __init__(self, business_account: BankAccount):
        self.business_account = business_account

    def card_pay(self, card_number: int) -> bool:
        # Перевод денег с карточного счета на счет компании
        ...

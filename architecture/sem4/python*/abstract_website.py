from abstract_database import AbstractDataBase
from bank_account import BankAccount
from person import Person
from pyment_service import PaymentService
from ticket import Ticket

from datetime import datetime as dt


class AbstractWebSite:
    def __init__(self):
        self.database = AbstractDataBase()
        self.payment_service = PaymentService(BankAccount())
        self.logined_users = list()

    def register(self):
        unique_login = False
        while not unique_login:
            login = input("Чтобы выйти, введите 'q'.\nВведите логин: ")
            if login == 'q':
                return
            elif login in self.database.persons:
                print("Пользователь с таким именем уже существует. Попробуйте еще раз.")
            else:
                unique_login = True
        hash_pass = self.__get_hash_pass(input("Введите пароль: "))
        full_name = input("Введите полное имя: ")
        card_number = int(input("Введите номер банковской карты без пробелов: "))
        new_person = Person(login, hash_pass, full_name, card_number)
        self.database.persons[login] = new_person

    def user_login(self):
        user_exist = False
        while not user_exist:
            login = input("Чтобы выйти, введите 'q'.\nВведите логин: ")
            found_person = self.database.persons.get(login)
            if login == 'q':
                return
            elif not found_person:
                print("Пользователь не найден. Попробуйте еще раз.")
            else:
                user_exist = True

        pass_is_correct = False
        while not pass_is_correct:
            hash_pass = self.__get_hash_pass(input("Чтобы выйти, введите 'q'.\nВведите пароль: "))
            if login == 'q':
                return
            elif not hash_pass == found_person.hash_pass:
                print("Неверный пароль. Попробуйте еще раз.")
            else:
                self.logined_users.append(login)
                print("Вход выполнен успешно")


    def user_logout(self, person: Person):
        self.logined_users.remove(person.login)
        print("Всего хорошего!")

    def buy_ticket(self, person: Person):
        if person.login not in self.logined_users:
            print("Чтобы купить билет, нужно пройти авторизацию")
            return
        trip_date = input("Введите желаемую дату поездки в формате YYYY-mm-dd HH:MM: ")
        trip_date = dt.strptime(trip_date, '%Y-%m-%d %H:%M:%S.%f')
        seat = int(input("Введите номер места: "))
        is_luggage = 'y' == input("Введите 'y' если поедете с багажом, иначе пропустите: ")

        # Выбор маршрута и остановок оставлю в таком виде.
        # Подразумевается выбор из предложенных списков из базы данных.
        bus_route = input("Выберете номер маршрута: ")
        start_station = input("Выберете начальную остановку: ")
        finish_station = input("Выберете конечную остановку: ")

        ticket = Ticket(person, trip_date, bus_route, seat, is_luggage, start_station, finish_station)
        print(f"Стоимость билета составляет {ticket.price}")
        if 'y' == input("Введите 'y' чтобы оплатить или нажмите 'Enter' чтобы отменить покупку: "):
            payment_result = self.payment_service.card_pay(person.card_number)
            if payment_result:
                self.database.tickets[ticket.ID] = ticket
                person.tickets[ticket.ID] = ticket
                print("Билет успешно приобритен.")
            else:
                print("Во время оплаты произошла ошибка, попробуйте еще раз.")
        print("Всего хорошего!")

    @staticmethod
    def __get_hash_pass(password: str) -> int:
        return hash(password)


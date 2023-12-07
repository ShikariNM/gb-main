from datetime import datetime as dt

from descriptor import Descriptor
from bus_route import BusRoute
from bus_stop import BusStop
from id_incrementor import IdIncrementor
from person import Person


class Ticket(IdIncrementor):

    ID = Descriptor(is_constant=True)
    buy_date = Descriptor(is_constant=True)
    price = Descriptor(is_constant=True)
    person = Descriptor(is_constant=True)
    trip_date = Descriptor()
    bus_route = Descriptor()
    seat = Descriptor()
    is_luggage = Descriptor()
    start_station = Descriptor()
    finish_station = Descriptor()

    def __init__(self, person: Person, trip_date: dt, bus_route: BusRoute, seat: int, is_luggage: bool,
                 start_station: BusStop, finish_station: BusStop) -> None:
        self.ID = self._static_id
        self.person = person
        self.buy_date = dt.now()
        self.trip_date = trip_date
        self.bus_route = bus_route
        self.seat = seat
        self.is_luggage = is_luggage
        self.start_station = start_station
        self.finish_station = finish_station
        self.price = self.__count_price()

    def __count_price(self) -> int:
        # расчет стоимости билета исходя из маршрута и продолжительности пути
        return 0

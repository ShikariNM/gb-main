from datetime import datetime as dt

from descriptor import Descriptor
from bus_route import BusRoute
from bus_stop import BusStop
from id_incrementor import IdIncrementor


class Ticket(IdIncrementor):

    ID = Descriptor(is_constant=True)
    date = Descriptor(is_constant=True)
    price = Descriptor(is_constant=True)
    bus_route = Descriptor()
    seat = Descriptor()
    start_station = Descriptor()
    finish_station = Descriptor()

    def __init__(self, bus_route: BusRoute, seat: int, start_station: BusStop, finish_station: BusStop) -> None:
        self.ID = self._static_id
        self.date = dt.now()
        self.bus_route = bus_route
        self.seat = seat
        self.start_station = start_station
        self.finish_station = finish_station
        self.price = self.__count_price()

    def __count_price(self) -> int:
        # расчет стоимости билета исходя из маршрута и продолжительности пути
        return 0

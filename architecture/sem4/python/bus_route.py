from id_incrementor import IdIncrementor
from descriptor import Descriptor
from bus_stop import BusStop


class BusRoute(IdIncrementor):

    ID = Descriptor(is_constant=True)
    description = Descriptor()
    bus_stops = Descriptor()

    def __init__(self, description: str, bus_stops: list[BusStop]):
        self.ID = self._static_id
        self.description = description
        self.bus_stops = bus_stops

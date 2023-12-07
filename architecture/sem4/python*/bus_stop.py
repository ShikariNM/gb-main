from id_incrementor import IdIncrementor
from descriptor import Descriptor


class BusStop(IdIncrementor):

    ID = Descriptor(is_constant=True)
    name = Descriptor()
    latitude = Descriptor()
    longitude = Descriptor()

    def __init__(self, name: str, latitude: float, longitude: float) -> None:
        self.ID = self._static_id
        self.name = name
        self.latitude = latitude
        self.longitude = longitude

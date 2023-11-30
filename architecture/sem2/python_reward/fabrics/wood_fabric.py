from fabrics.fabric import Fabric
from products.wood import Wood


class WoodFabric(Fabric):
    def create_item(self):
        return Wood()

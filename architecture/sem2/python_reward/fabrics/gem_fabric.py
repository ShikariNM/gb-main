from fabrics.fabric import Fabric
from products.gem import Gem


class GemFabric(Fabric):
    def create_item(self):
        return Gem()

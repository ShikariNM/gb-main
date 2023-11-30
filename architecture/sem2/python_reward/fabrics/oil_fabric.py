from fabrics.fabric import Fabric
from products.oil import Oil


class OilFabric(Fabric):
    def create_item(self):
        return Oil()

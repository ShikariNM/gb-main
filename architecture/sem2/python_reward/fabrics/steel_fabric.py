from fabrics.fabric import Fabric
from products.steel import Steel


class SteelFabric(Fabric):
    def create_item(self):
        return Steel()

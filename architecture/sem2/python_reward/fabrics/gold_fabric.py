from fabrics.fabric import Fabric
from products.gold import Gold


class GoldFabric(Fabric):
    def create_item(self):
        return Gold()

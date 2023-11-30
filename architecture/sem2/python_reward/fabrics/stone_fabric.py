from fabrics.fabric import Fabric
from products.stone import Stone


class StoneFabric(Fabric):
    def create_item(self):
        return Stone()

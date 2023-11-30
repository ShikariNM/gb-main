from fabrics.fabric import Fabric
from products.coal import Coal


class CoalFabric(Fabric):
    def create_item(self):
        return Coal()

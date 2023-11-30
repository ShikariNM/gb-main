package Fabrics;

import Products.Steel;
import Products.Product;

public class SteelFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Steel();
    }

}

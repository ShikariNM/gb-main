package Fabrics;

import Products.Coal;
import Products.Product;

public class CoalFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Coal();
    }

}

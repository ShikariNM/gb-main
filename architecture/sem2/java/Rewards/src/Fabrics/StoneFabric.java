package Fabrics;

import Products.Stone;
import Products.Product;

public class StoneFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Stone();
    }

}

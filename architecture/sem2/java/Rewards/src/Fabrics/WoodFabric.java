package Fabrics;

import Products.Wood;
import Products.Product;

public class WoodFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Wood();
    }

}

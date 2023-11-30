package Fabrics;

import Products.Oil;
import Products.Product;

public class OilFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Oil();
    }
}

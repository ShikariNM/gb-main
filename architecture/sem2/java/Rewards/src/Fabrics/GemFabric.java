package Fabrics;

import Products.Gem;
import Products.Product;

public class GemFabric extends Fabric {

    @Override
    public Product createProduct() {
        return new Gem();
    }
    
}

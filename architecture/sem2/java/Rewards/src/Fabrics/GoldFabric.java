package Fabrics;

import Products.Gold;
import Products.Product;

public class GoldFabric extends Fabric {
   
    @Override
    public Product createProduct() {
        return new Gold();
    }

}

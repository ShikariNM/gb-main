import java.util.List;
import java.util.Arrays;
import java.util.Random;

import Fabrics.CoalFabric;
import Fabrics.Fabric;
import Fabrics.GemFabric;
import Fabrics.GoldFabric;
import Fabrics.OilFabric;
import Fabrics.SteelFabric;
import Fabrics.StoneFabric;
import Fabrics.WoodFabric;

public class App {
    public static void main(String[] args) throws Exception {
        List<Fabric> fabrics = Arrays.asList(new CoalFabric(),
                                             new OilFabric(),
                                             new SteelFabric(),
                                             new StoneFabric(),
                                             new WoodFabric(),
                                             new GoldFabric(),
                                             new GemFabric());

        for (int i = 0; i < 10; i++) {
            int max_num = (fabrics.size() - 2) * 10 + 4;
            int num = new Random().nextInt(max_num);
            int res;
            if (num == 53) res = fabrics.size() - 1;
            else if (num < max_num - 4) res = num / 10;
            else res = fabrics.size() - 2;
            System.out.println(num + " " + res);
            fabrics.get(res).createProduct().open();
        }
    }
}

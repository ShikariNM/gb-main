from fabrics import CoalFabric, GemFabric, GoldFabric, OilFabric,\
                    SteelFabric, StoneFabric, WoodFabric
from random import randrange


if __name__ == '__main__':
    fabrics = [CoalFabric, OilFabric, SteelFabric, StoneFabric,
               WoodFabric, GoldFabric, GemFabric]

    for i in range(10):
        max_num = (len(fabrics) - 2) * 10 + 4
        num = randrange(max_num)
        res = num // 10 if num < max_num - 4 else (-1 if num == max_num - 1 else -2)
        fabrics[res]().create_item().open_reward()

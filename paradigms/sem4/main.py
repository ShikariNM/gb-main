from math import sqrt

def pearson_correlation(data1: list, data2: list) -> int:
    avg1 = sum(data1)/len(data1)
    avg2 = sum(data2)/len(data2)

    return (sum(x * y for x, y in zip(map(lambda el: el - avg1, data1), map(lambda el: el - avg2, data2))) /
            sqrt(sum(map(lambda el: (el - avg1)**2, data1)) * sum(map(lambda el: (el - avg2)**2, data2))))

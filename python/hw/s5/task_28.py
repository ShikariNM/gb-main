# Напишите рекурсивную функцию sum(a, b), возвращающую сумму двух целых
# неотрицательных чисел. Из всех арифметических операций допускаются только
# +1 и -1. Также нельзя использовать циклы.
# 2 2
# 4

def sum1(a, b):
    if a == 0:
        if b == 1:
            return b
        return sum1(a, b - 1) + 1
    return sum1(a - 1, b) + 1

def sum2(a, b):
    if a == b == 1:
        return 1 + 1
    if a >= b:
        return sum2(a - 1, b) + 1
    if b > a:
        return sum2(a, b - 1) + 1


a = int(input())
b = int(input())
print(sum1(a, b))
print(sum2(a, b))

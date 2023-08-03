# Даны два массива чисел. Требуется вывести те уникальные элементы первого массива (в том порядке,
# в каком они идут в первом массиве), которых нет во втором массиве. Элементы обоих массивов вводятся
# в две строки через пробел.

# Пример:
# 1 2 3 4 5 6
# 4 5 6 7 8 -> 1 2 3

from random import randint

num1 = int(input())
num2 = int(input())
a = [randint(1, 10) for i in range(num1)]
b = [randint(1, 10) for i in range(num2)]
print(a)
print(b)

c = []
for ela in a:
    if ela not in b:
        c.append(ela)
print(c)

print([el for el in a if el not in b])

i = 0
while i < len(a):
    if a[i] in b:
        a.remove(a[i])
    else:
        i += 1
print(a)

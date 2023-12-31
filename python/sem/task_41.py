# Дан массив, состоящий из целых чисел. Напишите программу, которая в данном массиве определит количество элементов,
# у которых два соседних и, при этом, оба соседних элемента меньше данного. Массив чисел вводится в одну строку
# через пробел. Массив состоит из целых чисел.

# Пример:
# 5 1 3 7 9 6 -> 1
# 3 4 3 6 5 8 7 -> 3 

from random import randint

num = int(input())
l = [randint(1, 10) for i in range(num)]
print(l)

res = 0
for i in range(1, len(l)-1):
    if l[i] > l[i-1] and l[i] > l[i+1]:
        res += 1
print(res)
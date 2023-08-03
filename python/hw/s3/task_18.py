# Задача 18: Требуется найти в массиве A[1..N] самый близкий по величине элемент
# к заданному числу X. Пользователь в первой строке вводит натуральное
# число N – количество элементов в массиве. В последующих  строках записаны N целых чисел Ai.
# Последняя строка содержит число X
# *Пример:*

# 5
# 1 2 3 4 5
# 6
#     -> 5
from random import randint

N = int(input())
A = [randint(1, 10) for i in range(N)]
print(A)
X = int(input())
nearest = A[0]
for el in A:
    if abs(el-X) < abs(nearest-X):
        nearest = el
print(nearest)

print(min(A, key=lambda y: abs(y - X)))

# Дан массив, состоящий из целых чисел. Напишите программу, которая подсчитает количество
# элементов массива, больших предыдущего (элемента с предыдущим номером)
# Input: [0, -1, 5, 2, 3]
# Output: 2 (-1 < 5, 2 < 3)

from random import randint

l = [randint(1, 10) for i in range(20)]
count = 0
for i in range(1, len(l)):
    if l[i] > l[i-1]:
        count += 1
print(l)
print(count)

result = [l[i] for i in range(1, len(l)) if l[i] > l[i-1]]
print(len(result))
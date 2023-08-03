# Дан список чисел. Определите, сколько в нем встречается различных чисел.
# Input: [1, 1, 2, 0, -1, 3, 4, 4]
# Output: 6

from random import randint

num = int(input())
l = [randint(0, 9) for i in range(num)]
print(l)
set = set(l)
print(len(set))
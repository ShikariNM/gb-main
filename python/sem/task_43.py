# Дан список чисел. Посчитайте, сколько в нем пар элементов, равных друг другу.Считается, что любые два элемента,
# равные друг другу образуют одну пару, которую необходимо посчитать. 
# Вводится список чисел. Все числа списка находятся на одной строке через пробел.
# 1 2 1 3 4 5 3 4 -> 3
# 1 2 1 3 4 3 1 -> 2

from random import randint

num = int(input())
l = [randint(1, 10) for i in range(num)]
print(l)


ax_dict = {}
for el in l:
    if el not in ax_dict:
        ax_dict[el] = 1
    else:
        ax_dict[el] += 1
res = 0
for val in ax_dict.values():
    res += val//2
print(res)

res = 0
for el in set(l):
    res += l.count(el)//2
print(res)

print(sum(l.count(el)//2 for el in set(l)))

res = 0
i = 0
while i < len(l):
    j = i + 1
    while j < len(l):
        if l[i] == l[j]:
            res += 1
            del l[j]
            break
        j += 1
    i += 1
print(res)
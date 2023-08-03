# Даны два неупорядоченных набора целых чисел (может быть, с повторениями).
# Выдать без повторений в порядке возрастания все те числа,
# которые встречаются в обоих наборах.
# Пользователь вводит в строку первый список затем на следующией строке второй список.

# from random import randint

# set_1 = set([randint(0, 9) for i in range(20)])
# set_2 = set([randint(0, 9) for i in range(20)])
# print(set_1)
# print(set_2)

set_1 = set([el for el in input().split()])
set_2 = set([el for el in input().split()])

print(set_1.intersection(set_2))
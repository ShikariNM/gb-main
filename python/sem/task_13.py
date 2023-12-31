# 1. Уставшие от необычно теплой зимы, жители решили узнать,
# действительно ли это самая длинная оттепель за всю историю
# наблюдений за погодой. Они обратились к синоптикам, а те,
# в свою очередь, занялись исследованиями статистики за прошлые годы.
# Их интересует, сколько дней длилась самая длинная оттепель.
# Оттепелью они называют период, в который среднесуточная
# температура ежедневно превышала 0 градусов Цельсия. Напишите
# программу, помогающую синоптикам в работе.

# Пользователь вводит число N – общее количество рассматриваемых дней
# (1 ≤ N ≤ 100). В следующих строках располагается N целых чисел.

# Каждое число – среднесуточная температура в соответствующий день.
# Температуры – целые числа и лежат в диапазоне от –50 до 50
# -1 1 1 1 -1 1 1 -> 3
from random import randint

num = int(input())
l = [randint(-50, 50) for i in range(num+1)]
res = -1
count = 0
for i in l:
    if i > 0:
        count += 1
    else:
        if count != 0 and count > res:
            res = count
        count = 0
if count != 0 and count > res:
    res = count
# print(l)
print(res)
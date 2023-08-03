# Определить индексы элементов массива (списка), значения которых принадлежат заданному
# диапазону (т.е. не меньше заданного минимума и не больше заданного максимума)

# Input:
# 1, 3, 7, 10, 5, 8
# 4
# 8
# Output:
# 2(7), 4(5), 5(8)

def get_els_by_range(list, range_min, range_max):
    res = ''
    for i in range(len(list)):
        if list[i] in range(range_min, range_max+1):
            res += f'{i}({list[i]}) '
    return res

l = list(map(int, input().split(', ')))
min = int(input())
max = int(input())
print(get_els_by_range(l, min, max))